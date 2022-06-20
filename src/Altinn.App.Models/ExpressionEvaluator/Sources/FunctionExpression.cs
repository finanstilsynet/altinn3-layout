namespace Altinn.App.Models;

public class FunctionExpression : ILayoutDynamicsExpr
{
    [JsonPropertyName("function")]
    public string Function { get; set; } = null!;
    [JsonPropertyName("args")]
    public List<ILayoutDynamicsExpr> Args { get; set; } = new();
}