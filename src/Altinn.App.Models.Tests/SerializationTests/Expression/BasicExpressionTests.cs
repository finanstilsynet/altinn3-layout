using Altinn.App.Models;

namespace Altinn.App.Models.Tests.SerializationTests.Expression;

public class BasicExpressionTests
{
    [Fact]
    public void Expression_TrueAsExpression_ReturnsBooleanExpressionOfValue()
    {
        var input = "true";
        var output = JsonSerializer.Deserialize<BooleanLayoutDynamicsExprWrapper>(input)!;
        output.Value.Should().BeTrue();
        output.Root.Should().BeNull();

        var serialized = JsonSerializer.Serialize(output);
        serialized.Should().Be(input);
    }

    [Fact]
    public void Expression_FalseAsExpression_ReturnsBooleanExpressionOfValue()
    {
        var input = "false";
        var output = JsonSerializer.Deserialize<BooleanLayoutDynamicsExprWrapper>(input)!;
        output.Value.Should().BeFalse();
        output.Root.Should().BeNull();

        var serialized = JsonSerializer.Serialize(output);
        serialized.Should().Be(input);
    }

    [Fact]
    public void Expression_NullAsExpression_ReturnsBooleanExpressionOfValue()
    {
        var input = "null";
        var output = JsonSerializer.Deserialize<BooleanLayoutDynamicsExprWrapper>(input)!;
        output.Should().BeNull();

        var serialized = JsonSerializer.Serialize(output);
        serialized.Should().Be(input);
    }
    [Fact]
    public void Expression_Function_ThrowsJsonException()
    {
        var input = "{}";

        Action act = () => JsonSerializer.Deserialize<BooleanLayoutDynamicsExprWrapper>(input);
        act.Should().Throw<JsonException>();
    }

    [Fact]
    public void Expression_Function_ReturnsValidFunction()
    {
        var input = @"{""function"":""equals"",""args"":[]}";
        var output = JsonSerializer.Deserialize<BooleanLayoutDynamicsExprWrapper>(input)!;
        output.Should().NotBeNull();
        output.Value.Should().BeNull();
        output.Root.Should().NotBeNull();
        output.Root.Should().BeOfType<FunctionExpression>();
        var functionExpression = (FunctionExpression)output.Root!;
        functionExpression.Function.Should().Be("equals");
        functionExpression.Args.Should().BeEmpty();

        var serialized = JsonSerializer.Serialize(output);
        serialized.Should().Be(input);
    }

    [Fact]
    public void Expression_Function_ReturnsValidFunctionWithArguments()
    {
        var input = @"{""function"":""equals"",""args"":[{""dataModel"":""test.path""}]}";
        var output = JsonSerializer.Deserialize<BooleanLayoutDynamicsExprWrapper>(input)!;
        output.Should().NotBeNull();
        output.Value.Should().BeNull();
        output.Root.Should().NotBeNull();
        output.Root.Should().BeOfType<FunctionExpression>();
        var functionExpression = (FunctionExpression)output.Root!;
        functionExpression.Function.Should().Be("equals");
        functionExpression.Args.Should().HaveCount(1);
        var firstArg = functionExpression.Args.Single();
        firstArg.Should().BeOfType<DataModelExpression>();
        ((DataModelExpression)firstArg).DataModel.Should().Be("test.path");

        var serialized = JsonSerializer.Serialize(output);
        serialized.Should().Be(input);
    }
}