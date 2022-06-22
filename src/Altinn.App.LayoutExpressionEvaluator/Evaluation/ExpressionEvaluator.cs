namespace Altinn.App.LayoutExpressionEvaluator;

using Altinn.App.Models;

public class ExpressionEvaluator
{
    private readonly Dictionary<string, IFunctionImplementation> _functions;
    public ExpressionEvaluator(IEnumerable<IFunctionImplementation> functions)
    {
        _functions = functions.ToDictionary(f => f.FunctionName);
        // TODO: Consider injecting ServiceProvider
        // TODO: Inject getters for datamodell/layoutModel/appsettings....
        //       so we can evaluate expressions with references
    }

    public bool Evaluate(BooleanLayoutDynamicsExprWrapper expression)
    {
        if(expression.Root == null)
        {
            return expression.Value ?? false;
        }
        return (Evaluate(expression.Root) as bool?) ?? false;
    }
    public object? Evaluate(ILayoutDynamicsExpr expression)
    {
        return expression switch
        {
            FunctionExpression f => EvaluateFunction(f),
            LiteralValueExpression f => f.Value,
            _ => throw new ArgumentException($"Can't evaluate unknown expression {expression?.GetType().Name}")
        };
    }
    public object? EvaluateFunction(FunctionExpression f)
    {
        var args = f.Args.Select(arg => Evaluate(arg)).ToList();
        var function = _functions[f.Function];
        return function.Evaluate(args);
    }
}