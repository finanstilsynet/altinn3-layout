namespace Altinn.App.Models;

public class BooleanLayoutDynamicsExprConverter : JsonConverter<BooleanLayoutDynamicsExprWrapper>
{
    public override BooleanLayoutDynamicsExprWrapper? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.StartObject => ReadObject(ref reader, typeToConvert, options),
            JsonTokenType.False => new() { Value = false },
            JsonTokenType.True => new() { Value = true },
            _ => throw new JsonException("Reading BooleanExpressionFailed")
        };
    }
    public BooleanLayoutDynamicsExprWrapper ReadObject(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var componentDocument = JsonDocument.ParseValue(ref reader);
        return new BooleanLayoutDynamicsExprWrapper
        {
            Root = componentDocument.Deserialize<ILayoutDynamicsExpr>()
        };
    }

    public override void Write(Utf8JsonWriter writer, BooleanLayoutDynamicsExprWrapper value, JsonSerializerOptions options)
    {
        if (value.Root != null)
        {
            JsonSerializer.Serialize(writer, (object?)(value.Root), options);
        }
        else
        {
            JsonSerializer.Serialize(writer, (object?)(value.Value), options);
        }
    }
}