using Altinn.App.Models.JsonTools;

namespace Altinn.App.Models.Tests.SerializationTests.Layout;

public class LayoutRoundTrip
{
    [Theory]
    [InlineData("HeaderComponent.json")]
    public async Task RoundTripTest(string filename)
    {
        var input = await File.ReadAllTextAsync(Path.Join("SerializationTests","Layout","RoundTripTestLayouts", filename));
        var obj = LayoutJsonSerializer.Deserialize(input)!;
        var inputConverted = LayoutJsonSerializer.Serialize(obj).ReplaceLineEndings("\n");
        inputConverted.Should().Be(input);
    }
}