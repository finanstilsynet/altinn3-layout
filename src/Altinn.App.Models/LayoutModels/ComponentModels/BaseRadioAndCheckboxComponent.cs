using System.ComponentModel.DataAnnotations;

namespace Altinn.App.Models;

public abstract record BaseRadioAndCheckboxComponent : BaseSelectionComponent
{
    [JsonPropertyName("layout")]
    [JsonPropertyOrder(100)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Layout { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public SelectionLayouts LayoutEnum
    {
        get 
        {
            return Layout switch
            {
                "column" => SelectionLayouts.column,
                "row" => SelectionLayouts.row,
                _ => SelectionLayouts.column,
            };
        }
        set
        {
            Layout = value switch
            {
                SelectionLayouts.row => "row",
                SelectionLayouts.column => "column",
                _ => throw new ArgumentOutOfRangeException(nameof(SelectionLayouts), value, ""),
            };
        }
    }

    public enum SelectionLayouts
    {
        column,
        row,
    }
}