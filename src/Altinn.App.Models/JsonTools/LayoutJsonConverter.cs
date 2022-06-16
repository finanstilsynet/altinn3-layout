namespace Altinn.App.Models.JsonTools;

public static class LayoutJsonSerializer
{
    public static JsonSerializerOptions _serializerOptions = new()
    {
        AllowTrailingCommas = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // Don't escape html characters inside strings
        IgnoreReadOnlyFields = true,
        IgnoreReadOnlyProperties = true,
        IncludeFields = false,
        MaxDepth = 64,
        NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.AllowNamedFloatingPointLiterals,
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        ReadCommentHandling = JsonCommentHandling.Skip,
        ReferenceHandler = ReferenceHandler.IgnoreCycles,
        UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement,
        WriteIndented = true,
    };

    public static LayoutModels.Layout? Deserialize(string json)
    {
        return JsonSerializer.Deserialize<LayoutModels.Layout>(json, _serializerOptions);
    }
    public static string Serialize(LayoutModels.Layout layout)
    {
        return JsonSerializer.Serialize(layout, _serializerOptions);
    }
}