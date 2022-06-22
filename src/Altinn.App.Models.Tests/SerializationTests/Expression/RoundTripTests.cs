using Altinn.App.Models;

namespace Altinn.App.Models.Tests.SerializationTests.Expression;

public class RoundTripTests
{
    [Theory]
    [InlineData("FunctionExpressionInLayout.json")]
    public async Task TestRoundTripEqual(string filename)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var input = await File.ReadAllTextAsync(Path.Join("SerializationTests", "Expression", "RoundTripTestExpressions", filename));
        var obj = JsonSerializer.Deserialize<Layout>(input)!;
        var inputConverted = JsonSerializer.Serialize(obj, options).ReplaceLineEndings("\n");
        inputConverted.Should().Be(input);
    }
}