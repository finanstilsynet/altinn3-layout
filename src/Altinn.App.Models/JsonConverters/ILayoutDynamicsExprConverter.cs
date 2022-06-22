using System.Reflection;

namespace Altinn.App.Models;

public class ILayoutDynamicsExprConverter : JsonConverter<ILayoutDynamicsExpr>
{
//     public override bool CanConvert(Type typeToConvert) =>
//         typeof(ILayoutDynamicsExpr).IsAssignableFrom(typeToConvert);

    public override ILayoutDynamicsExpr? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.String => new LiteralValueExpression(reader.GetString()!),
            JsonTokenType.Number => new LiteralValueExpression(reader.GetDouble()),
            JsonTokenType.True => new LiteralValueExpression(true),
            JsonTokenType.False => new LiteralValueExpression(false),
            JsonTokenType.Null => new LiteralValueExpression(null),
            JsonTokenType.StartObject => ReadDynamicsObject(ref reader, typeToConvert, options),
            _ => throw new JsonException(),
        };
    }
    public ILayoutDynamicsExpr ReadDynamicsObject(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var componentDocument = JsonDocument.ParseValue(ref reader);

        if(componentDocument.RootElement.TryGetProperty("function", out var function))
        {
            return (ILayoutDynamicsExpr)componentDocument.Deserialize<FunctionExpression>(options)!;
        }
        if(componentDocument.RootElement.TryGetProperty("dataModel", out var dataModel))
        {
            return (ILayoutDynamicsExpr)componentDocument.Deserialize<DataModelExpression>(options)!;
        }
        // TODO: Add more expression types
        // "applicationSettings"
        // "component"
        // "instanceContext"

        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, ILayoutDynamicsExpr value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)value, options);
    }
}