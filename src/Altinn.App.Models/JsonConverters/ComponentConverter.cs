using System.Reflection;

namespace Altinn.App.Models;

public class ComponentConverter : JsonConverter<BaseComponent>
{
    public static IReadOnlyDictionary<string, Type> ComponentClasses =
        Assembly
            .GetAssembly(typeof(BaseComponent))
            ?.GetTypes()
            .Where(typ => typeof(BaseComponent) != typ && typeof(BaseComponent).IsAssignableFrom(typ))
            .ToDictionary(typ => typ.Name)
            ?? throw new Exception("Failed to load derived classes from assembly");
    public override bool CanConvert(Type typeToConvert) =>
        typeof(BaseComponent).IsAssignableFrom(typeToConvert);

    public override BaseComponent? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }
        
        using var componentDocument = JsonDocument.ParseValue(ref reader);
        if (!componentDocument.RootElement.TryGetProperty("type", out var typeProperty) || (typeProperty.ValueKind != JsonValueKind.String))
        {
            throw new JsonException("Missing field \"type\" in layout component");
        }

        var typeName = typeProperty.GetString()!;
        if (ComponentClasses.TryGetValue(typeName, out var type))
        {
            // component property "type" matches one of the registrerd types. Use that!
            return (BaseComponent)componentDocument.Deserialize(type, options)!;
        }
        
        if(componentDocument.RootElement.TryGetProperty("dataModelBindings", out _ ))
        {
            // Component is unknown, but has dataModelBindings
            return (BaseComponent)componentDocument.Deserialize<BaseDataComponent>(options)!;
        }

        if (componentDocument.RootElement.TryGetProperty("textResourceBindings", out _ ))
        {
            // Component is unknown, but has textResourceBindings
            return (BaseComponent)componentDocument.Deserialize<BaseTextComponent>(options)!;
        }
        // Component is unknown and don't have dataModelBindings, nor textResourceBindings
        return componentDocument.Deserialize<BaseComponent>(options);
    }

    public override void Write(Utf8JsonWriter writer, BaseComponent value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)value, options);
    }
}