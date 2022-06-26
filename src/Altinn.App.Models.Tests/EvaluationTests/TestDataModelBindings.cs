namespace Altinn.App.Models.Tests.EvaluationTests;

public class TestDataModelBindings
{
    private readonly ExpressionEvaluationTestContext _context = new();

    [Fact]
    public void ModelBindings_BindingValueAndStaticValueMatches_ReturnsTrue()
    {
        _context.DataModel.Setup(d => d.GetModelProperty("model.path")).Returns("MyModelValue");

        var booleanExpressionString = @"{""function"":""equals"",""args"":[{""dataModel"":""model.path""}, ""MyModelValue""]}";
        var expression = JsonSerializer.Deserialize<BooleanLayoutDynamicsExprWrapper>(booleanExpressionString)!;
        var result = _context.ExprEval.Evaluate(expression);

        result.Should().BeTrue();
    }

    [Fact]
    public void ModelBindings_BindingValueAndStaticValueMatches_ReturnsFalse()
    {
        _context.DataModel.Setup(d => d.GetModelProperty("model.path")).Returns("MyModelValue");

        var booleanExpressionString = @"{""function"":""equals"",""args"":[{""dataModel"":""model.path""}, ""Not EqualModelValue""]}";
        var expression = JsonSerializer.Deserialize<BooleanLayoutDynamicsExprWrapper>(booleanExpressionString)!;
        var result = _context.ExprEval.Evaluate(expression);

        result.Should().BeFalse();
    }
}