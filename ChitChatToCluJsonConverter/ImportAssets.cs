using Newtonsoft.Json;

namespace ChitChatToCluJsonConverter;

public class ImportAssets
{
    [JsonProperty("projectKind")]
    public string ProjectKind => "Conversation";
    
    [JsonProperty("intents")]
    public List<IntentAsset> Intents { get; set; } = new() { new IntentAsset("None") };

    [JsonProperty("entities")]
    public List<EntityAsset> Entities { get; set; } = new();

    [JsonProperty("utterances")]
    public List<UtteranceAsset> Utterances { get; set; } = new();
}