namespace Altinn.App.LayoutExpressionEvaluator;

public interface IInstanceContextAccessor
{
    object? GetInstanceContextProperty(string path);
}