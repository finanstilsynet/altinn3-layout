namespace Altinn.App.Models;

[JsonConverter(typeof(ILayoutDynamicsExprConverter))]
public interface ILayoutDynamicsExpr
{
}
