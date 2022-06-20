using System.Reflection;

namespace Altinn.App.Models;

public class ILayoutDynamicsExprConverter : JsonConverter<ILayoutDynamicsExpr>
{
    public override bool CanConvert(Type typeToConvert) =>
        typeof(ILayoutDynamicsExpr).IsAssignableFrom(typeToConvert);

    public override ILayoutDynamicsExpr? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }
        using var componentDocument = JsonDocument.ParseValue(ref reader);

        if(componentDocument.RootElement.TryGetProperty("function", out var function))
        {
            return (ILayoutDynamicsExpr?)componentDocument.Deserialize<FunctionExpression>(options);
        }
        // TODO: Add more expression types

        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, ILayoutDynamicsExpr value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)value, options);
    }
}