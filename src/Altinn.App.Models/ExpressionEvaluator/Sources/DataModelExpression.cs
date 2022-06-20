namespace Altinn.App.Models;

public class DataModelExpression : ILayoutDynamicsExpr
{
    [JsonPropertyName("dataModel")]
    public string DataModel { get; set; } = null!;
}