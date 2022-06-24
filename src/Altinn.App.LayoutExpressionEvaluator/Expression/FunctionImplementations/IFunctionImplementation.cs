namespace Altinn.App.LayoutExpressionEvaluator;

public interface IFunctionImplementation
{
    string FunctionName { get; }

    object Evaluate(IEnumerable<object?> args);
}