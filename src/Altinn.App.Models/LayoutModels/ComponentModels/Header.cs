using System.ComponentModel.DataAnnotations;

namespace Altinn.App.Models;

public class Header : BaseTextComponent
{
    [JsonPropertyName("size")]
    [JsonPropertyOrder(100)]
    [EnumDataType(typeof(HeaderSizes))]
    public string Size { get; set; } = "h2";

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public HeaderSizes SizeEnum
    {
        get => Size switch
        {
            "h2" => HeaderSizes.h2,
            "H2" => HeaderSizes.h2,
            "L" => HeaderSizes.h2,
            "l" => HeaderSizes.h2,
            "h3" => HeaderSizes.h3,
            "H3" => HeaderSizes.h3,
            "M" => HeaderSizes.h3,
            "m" => HeaderSizes.h3,
            "h4" => HeaderSizes.h4,
            "H4" => HeaderSizes.h4,
            "S" => HeaderSizes.h4,
            "s" => HeaderSizes.h4,
            _ => HeaderSizes.h2
        };
        set
        {
            Size = value switch {
                HeaderSizes.h2 => "h2",
                HeaderSizes.h3 => "h3",
                HeaderSizes.h4 => "h4",
                _ => throw new ArgumentOutOfRangeException(nameof(SizeEnum), value, ""),
            };
        }
    }

    public enum HeaderSizes
    {
        h2,
        h3,
        h4,
    }
}