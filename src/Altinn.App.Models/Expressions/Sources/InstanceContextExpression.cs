namespace Altinn.App.Models;

public class InstanceContextExpression : ILayoutDynamicsExpr
{
    [JsonPropertyName("instanceContext")]
    public string InstanceContext { get; set; } = null!;
}