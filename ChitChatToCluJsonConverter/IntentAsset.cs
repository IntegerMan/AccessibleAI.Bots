using Newtonsoft.Json;

namespace ChitChatToCluJsonConverter;

public class IntentAsset
{
    public IntentAsset(string category = "")
    {
        Category = category;
    }

    [JsonProperty("category")]
    public string Category { get; set; }
}