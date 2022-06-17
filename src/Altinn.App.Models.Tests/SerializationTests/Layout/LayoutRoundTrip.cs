using Altinn.App.Models.JsonTools;

namespace Altinn.App.Models.Tests.SerializationTests.Layout;

public class LayoutRoundTrip
{
    [Theory]
    [InlineData("HeaderComponentEqual.json")]
    public async Task RoundTripEqualTest(string filename)
    {
        var input = await File.ReadAllTextAsync(Path.Join("SerializationTests","Layout","RoundTripTestLayouts", filename));
        var obj = LayoutJsonSerializer.Deserialize(input)!;
        var inputConverted = LayoutJsonSerializer.Serialize(obj).ReplaceLineEndings("\n");
        inputConverted.Should().Be(input);
    }

    [Theory]
    [InlineData("HeaderComponentInput.json", "HeaderComponentExpected.json")]
    public async Task RoundTripDifferentTest(string filenameInput, string filenameExpected)
    {
        var input = await File.ReadAllTextAsync(Path.Join("SerializationTests","Layout","RoundTripTestLayouts", filenameInput));
        var expected = await File.ReadAllTextAsync(Path.Join("SerializationTests","Layout","RoundTripTestLayouts", filenameExpected));
        var obj = LayoutJsonSerializer.Deserialize(input)!;
        var inputConverted = LayoutJsonSerializer.Serialize(obj).ReplaceLineEndings("\n");
        inputConverted.Should().Be(expected);
    }
}