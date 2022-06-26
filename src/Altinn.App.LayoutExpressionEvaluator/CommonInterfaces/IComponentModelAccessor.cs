namespace Altinn.App.LayoutExpressionEvaluator;

public interface IComponentModelAccessor
{
    object GetModelProperty(string instanceId);
}