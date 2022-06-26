namespace Altinn.App.LayoutExpressionEvaluator;

using Altinn.App.Models;

public class ExpressionEvaluator
{
    private readonly Dictionary<string, IFunctionImplementation> _functions;
    private readonly IDataModelAccessor _dataModel;
    private readonly IInstanceContextAccessor _instanceContext;
    public ExpressionEvaluator(
        IEnumerable<IFunctionImplementation> functions,
        IDataModelAccessor dataModel,
        IInstanceContextAccessor instanceContextAccessor)
    {
        _functions = functions.ToDictionary(f => f.FunctionName);
        _dataModel = dataModel;
        _instanceContext = instanceContextAccessor;
    }

    public bool? Evaluate(BooleanLayoutDynamicsExprWrapper? expression)
    {
        if (expression == null)
        {
            return null;
        }
        if (expression.Root == null)
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
            DataModelExpression d => EvaluateDataModel(d),
            InstanceContextExpression ic => EvaluateInstanceContext(ic),
            _ => throw new ArgumentException($"Can't evaluate unknown expression {expression?.GetType().Name}")
        };
    }
    public object? EvaluateFunction(FunctionExpression f)
    {
        var args = f.Args.Select(arg => Evaluate(arg)).ToList();
        var function = _functions[f.Function];
        return function.Evaluate(args);
    }

    public object? EvaluateDataModel(DataModelExpression d)
    {
        return _dataModel.GetModelProperty(d.DataModel);
    }

    public object? EvaluateInstanceContext(InstanceContextExpression ic)
    {
        return _instanceContext.GetInstanceContextProperty(ic.InstanceContext);
    }
}