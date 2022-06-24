using Altinn.App.Models;

namespace Altinn.App.LayoutExpressionEvaluator;

public class LayoutEvaluator
{
    public Layout EvaluateLayout(Layout input)
    {
        var exprEval = new ExpressionEvaluator(new List<IFunctionImplementation>{new FunctionEquals()});
        return input with {
            Data = input.Data with
            {
                Layout = input.Data.Layout.Select(c=>
                {
                    var hidden = exprEval.Evaluate(c.Hidden)??false;
                    return c with {
                        Hidden = hidden,
                        ReadOnly = exprEval.Evaluate(c.ReadOnly) ?? false,
                        Required = !hidden || (exprEval.Evaluate(c.Required) ?? false),
                    };
                }
                ).ToList()
                
            }
        };
    }

}