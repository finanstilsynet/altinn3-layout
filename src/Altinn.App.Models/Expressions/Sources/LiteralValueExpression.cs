namespace Altinn.App.Models;

[JsonConverter(typeof(LiteralValueExpressionConverter))]
public class LiteralValueExpression : ILayoutDynamicsExpr
{
    public LiteralValueExpression(object? value)
    {
        Value = value;
    }

    public object? Value { get; set; }
}