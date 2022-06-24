namespace Altinn.App.LayoutExpressionEvaluator;

public class FunctionEquals : IFunctionImplementation
{
    public string FunctionName => "equals";
    public object Evaluate(IEnumerable<object?> args)
    {
        var first = args.FirstOrDefault();
        return args.All(arg => first?.Equals(arg) ?? (arg == null));
    }
}