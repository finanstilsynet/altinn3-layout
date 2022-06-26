namespace Altinn.App.LayoutExpressionEvaluator;

public interface IDataModelAccessor
{
    object? GetModelProperty(string path);
}