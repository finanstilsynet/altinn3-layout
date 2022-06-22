namespace Altinn.App.Models;

public class LiteralValueExpressionConverter : JsonConverter<LiteralValueExpression>
{
    public override LiteralValueExpression? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Reading of LiteralValueExpression is implemented directly on superclass ILayoutDynamicsExpr
        // And nobody is likely to directly deserialize the subtype.
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, LiteralValueExpression value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Value, options);
    }
}