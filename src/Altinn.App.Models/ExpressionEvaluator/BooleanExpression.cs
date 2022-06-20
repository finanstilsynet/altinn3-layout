namespace Altinn.App.Models;

[JsonConverter(typeof(BooleanLayoutDynamicsExprConverter))]
public class BooleanLayoutDynamicsExprWrapper
{
    public bool? Value { get; set; }
    public ILayoutDynamicsExpr? Root { get; set; }
    public static implicit operator bool(BooleanLayoutDynamicsExprWrapper e) => e.Value ?? throw new ArgumentException();
    public static implicit operator BooleanLayoutDynamicsExprWrapper(bool t) => new() { Value = t };
}