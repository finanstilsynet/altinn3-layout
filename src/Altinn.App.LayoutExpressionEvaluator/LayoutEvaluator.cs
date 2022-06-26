using Altinn.App.Models;

namespace Altinn.App.LayoutExpressionEvaluator;

public class LayoutEvaluator
{
    private readonly ExpressionEvaluator _exprEval;

    public LayoutEvaluator(ExpressionEvaluator expressionevaluator)
    {
        _exprEval = expressionevaluator;
    }

    public Layout EvaluateLayout(Layout input)
    {
        return input with
        {
            Data = input.Data with
            {
                Layout = input.Data.Layout.Select(c =>
                {
                    var hidden = _exprEval.Evaluate(c.Hidden) ?? false;
                    return c with
                    {
                        Hidden = hidden,
                        ReadOnly = _exprEval.Evaluate(c.ReadOnly) ?? false,
                        Required = !hidden || (_exprEval.Evaluate(c.Required) ?? false),
                    };
                }
                ).ToList()
            }
        };
    }

}