using Newtonsoft.Json;

namespace ChitChatToCluJsonConverter;

public class ImportMetadata
{
    [JsonProperty("projectKind")]
    public string ProjectKind => "Conversation";
    
    [JsonProperty("projectName")]
    public string ProjectName => "chit-chat-clu-Intents";

    [JsonProperty("settings")]
    public ImportSettings Settings { get; set; } = new();

    [JsonProperty("language")]
    public string Language => "en-us";

    [JsonProperty("description")]
    public string Description => "";

    [JsonProperty("multilingual")]
    public bool Multilingual => false;
}