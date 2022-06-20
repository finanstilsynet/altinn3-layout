using Altinn.App.Models;

namespace Altinn.App.Models.Tests.SerializationTests.ExpressionTests;

public class ExpressionRoundTrip
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
}