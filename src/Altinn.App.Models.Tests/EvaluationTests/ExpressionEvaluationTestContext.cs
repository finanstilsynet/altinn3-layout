using Altinn.App.Models;
using Altinn.App.LayoutExpressionEvaluator;

namespace Altinn.App.Models.Tests.EvaluationTests;

public class ExpressionEvaluationTestContext
{
    public ExpressionEvaluator ExprEval { get; init; }
    public Mock<IDataModelAccessor> DataModel { get; init; }

    public Mock<IInstanceContextAccessor> InstanceContext { get; init; }

    public ExpressionEvaluationTestContext()
    {
        DataModel = new();
        InstanceContext = new();
        var functions = new List<IFunctionImplementation>
        {
            new FunctionEquals(),
        };
        ExprEval = new ExpressionEvaluator(functions, DataModel.Object, InstanceContext.Object);
    }
}