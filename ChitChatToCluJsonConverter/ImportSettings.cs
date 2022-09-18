using Newtonsoft.Json;

namespace ChitChatToCluJsonConverter;

public class ImportSettings
{
    [JsonProperty("confidenceThreshold")]
    public int ConfidenceThreshold { get; set; } = 0;
}