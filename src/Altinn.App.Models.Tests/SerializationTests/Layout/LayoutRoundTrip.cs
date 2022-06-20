using Altinn.App.Models;

namespace Altinn.App.Models.Tests.SerializationTests;

public class LayoutRoundTrip
{
    [Theory]
    [InlineData("HeaderComponentEqual.json")]
    public async Task RoundTripEqualDefaultSerializerOptionsTest(string filename)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var input = await File.ReadAllTextAsync(Path.Join("SerializationTests", "Layout", "RoundTripTestLayouts", filename));
        var obj = JsonSerializer.Deserialize<Layout>(input)!;
        var inputConverted = JsonSerializer.Serialize(obj, options).ReplaceLineEndings("\n");
        inputConverted.Should().Be(input);
    }

    [Theory]
    [InlineData("HeaderComponentEqual.json")]
    public async Task RoundTripEqualWrongSerializerOptionsTest(string filename)
    {
        var options = new JsonSerializerOptions
        {
            AllowTrailingCommas = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.Never,
            // DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // Don't escape html characters inside strings
            IgnoreReadOnlyFields = false,
            IgnoreReadOnlyProperties = false,
            IncludeFields = true,
            MaxDepth = 64,
            NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.AllowNamedFloatingPointLiterals,
            PropertyNameCaseInsensitive = false,
            // PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            ReadCommentHandling = JsonCommentHandling.Skip,
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement,
            WriteIndented = true,
        };
        var input = await File.ReadAllTextAsync(Path.Join("SerializationTests", "Layout", "RoundTripTestLayouts", filename));
        var obj = JsonSerializer.Deserialize<Layout>(input)!;
        var inputConverted = JsonSerializer.Serialize(obj, options).ReplaceLineEndings("\n");
        inputConverted.Should().Be(input);
    }

    [Theory]
    [InlineData("HeaderComponentInput.json", "HeaderComponentExpected.json")]
    public async Task RoundTripDifferentTest(string filenameInput, string filenameExpected)
    {
        var input = await File.ReadAllTextAsync(Path.Join("SerializationTests", "Layout", "RoundTripTestLayouts", filenameInput));
        var expected = await File.ReadAllTextAsync(Path.Join("SerializationTests", "Layout", "RoundTripTestLayouts", filenameExpected));
        var obj = JsonSerializer.Deserialize<Layout>(input)!;
        var inputConverted = JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true }).ReplaceLineEndings("\n");
        inputConverted.Should().Be(expected);
    }
}