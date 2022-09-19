using Newtonsoft.Json;

namespace ChitChatToCluJsonConverter;

public class UtteranceAsset
{
    public UtteranceAsset()
    {

    }

    public UtteranceAsset(string text, string intent)
    {
        Text = text;
        Intent = intent;
    }

    [JsonProperty("text")]
    public string Text { get; set; } = null!;

    [JsonProperty("language")]
    public string Language { get; set; } = "en-us";

    [JsonProperty("intent")]
    public string Intent { get; set; } = "None";

    [JsonProperty("entities")]
    public List<EntityAsset> Entities { get; set; } = new();

    [JsonProperty("dataset")]
    public string Dataset { get; set; } = "Train";
}