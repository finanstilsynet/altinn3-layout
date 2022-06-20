using Altinn.App.Models;

namespace Altinn.App.Models.Tests.ComponentTests;

public class HeaderTests
{
    [Theory]
    [InlineData("H2", Header.HeaderSizes.h2)]
    [InlineData("l", Header.HeaderSizes.h2)]
    [InlineData("invalid", Header.HeaderSizes.h2)]
    [InlineData("s", Header.HeaderSizes.h4)]
    [InlineData("h3", Header.HeaderSizes.h3)]
    public void Enum_SetString(string size, Header.HeaderSizes expected)
    {
        var header = new Header()
        {
            Size = size,
        };
        header.SizeEnum.Should().Be(expected);
    }

    [Theory]
    [InlineData(Header.HeaderSizes.h2, "h2")]
    [InlineData(Header.HeaderSizes.h3, "h3")]
    [InlineData(Header.HeaderSizes.h4, "h4")]
    public void Enum_SetEnum(Header.HeaderSizes headEnum, string expected)
    {
        var header = new Header()
        {
            SizeEnum = headEnum,
        };
        header.Size.Should().Be(expected);
    }

    [Fact]
    public void EnumSet_InvalidValue_throwsArugmentOutOfRangeExeption()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var header = new Header()
            {
                SizeEnum = (Header.HeaderSizes)1000,
            };
        });
    }

    [Fact]
    public void SizeSet_InvalidValue_ReturnsSameValue()
    {

    }
}