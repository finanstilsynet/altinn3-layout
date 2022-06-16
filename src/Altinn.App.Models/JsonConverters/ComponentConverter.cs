using System.Reflection;
using Altinn.App.Models.LayoutModels;

namespace Altinn.App.Models.JsonConverters;

public class ComponentConverter : JsonConverter<BaseComponent>
{
    public static IReadOnlyDictionary<string, Type> ComponentClasses = 
        Assembly
            .GetAssembly(typeof(BaseComponent))
            ?.GetTypes()
            .Where(typ=>typeof(BaseComponent) != typ && typeof(BaseComponent).IsAssignableFrom(typ))
            .ToDictionary(typ=>typ.Name)
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
        if (!componentDocument.RootElement.TryGetProperty("type", out var typeProperty))
        {
            throw new JsonException("Missing field \"type\" in layout component");
        }
        var typeName = typeProperty.GetString()!;
        if(!ComponentClasses.TryGetValue(typeName, out var type))
        {
            throw new JsonException($"\"type\": \"{typeName}\" is invalid in layout component");
        }
        return (BaseComponent)componentDocument.Deserialize(type, options)!;

    }

    public override void Write(Utf8JsonWriter writer, BaseComponent value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)value, options);
    }
}