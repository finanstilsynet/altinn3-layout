namespace Altinn.App.Models;

public class ComponentExpression : ILayoutDynamicsExpr
{
    [JsonPropertyName("component")]
    public string ComponentId { get; set; } = null!;
}