namespace Altinn.App.Models;

public class ApplicationSettingsExpression : ILayoutDynamicsExpr
{
    [JsonPropertyName("applicationSettings")]
    public string ApplicationSettings { get; set; } = null!;
}