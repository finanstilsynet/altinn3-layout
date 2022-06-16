using Altinn.App.Models.LayoutModels.ComponentModels;

namespace Altinn.App.Models.Tests.ComponentTests;

public class HeaderTests
{
    [Theory]
    [InlineData("invalid", Header.HeaderSizes.INVALID)]
    [InlineData("H2", Header.HeaderSizes.H2)]
    [InlineData("l", Header.HeaderSizes.H2)]
    public void Enum_SetEnum(string size, Header.HeaderSizes expected)
    {
        var header = new Header()
        {
            Size = size,
        };
        header.SizeEnum.Should().Be(expected);
    }
    
    [Fact]
    public void Enum_GetEnum()
    {
        var header = new Header()
        {
            SizeEnum = Header.HeaderSizes.INVALID,
        };
        header.Size.Should().BeNull();

        header = new Header()
        {
            SizeEnum = Header.HeaderSizes.H2,
        };
        header.Size.Should().Be("h2");

        header = new Header()
        {
            SizeEnum = Header.HeaderSizes.H3,
        };
        header.Size.Should().Be("h3");

        header = new Header()
        {
            SizeEnum = Header.HeaderSizes.H4,
        };
        header.Size.Should().Be("h4");
    }
}