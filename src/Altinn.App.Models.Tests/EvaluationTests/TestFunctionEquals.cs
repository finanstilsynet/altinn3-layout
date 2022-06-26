using Altinn.App.Models;
using Altinn.App.LayoutExpressionEvaluator;

namespace Altinn.App.Models.Tests.EvaluationTests;

public class TestFunctionEquals
{
    private readonly ExpressionEvaluationTestContext _context = new();


    [Fact]
    public void TestFunctionEquals_returnsTrue()
    {
        var booleanExpressionString = @"{""function"":""equals"",""args"":[""a"", ""a""]}";
        var expression = JsonSerializer.Deserialize<BooleanLayoutDynamicsExprWrapper>(booleanExpressionString)!;
        var result = _context.ExprEval.Evaluate(expression);

        result.Should().BeTrue();
    }

    [Fact]
    public void TestFunctionEquals_returnsFalse()
    {
        var booleanExpressionString = @"{""function"":""equals"",""args"":[""a"", ""b""]}";
        var expression = JsonSerializer.Deserialize<BooleanLayoutDynamicsExprWrapper>(booleanExpressionString)!;
        var result = _context.ExprEval.Evaluate(expression);

        result.Should().BeFalse();
    }

    [Fact]
    public void TestFunctionEqualsRecurs_returnsTrue()
    {
        var booleanExpressionString = @"{""function"":""equals"",""args"":[{""function"":""equals"",""args"":[""a"", ""a""]},{""function"":""equals"",""args"":[""a"", ""a""]}]}";
        var expression = JsonSerializer.Deserialize<BooleanLayoutDynamicsExprWrapper>(booleanExpressionString)!;
        var result = _context.ExprEval.Evaluate(expression);

        result.Should().BeTrue();
    }

    [Fact]
    public void TestFunctionEqualsRecurs_returnsFalse()
    {
        var booleanExpressionString = @"{""function"":""equals"",""args"":[{""function"":""equals"",""args"":[""a"", ""a""]}, true]}";
        var expression = JsonSerializer.Deserialize<BooleanLayoutDynamicsExprWrapper>(booleanExpressionString)!;
        var result = _context.ExprEval.Evaluate(expression);

        result.Should().BeTrue();
    }
}