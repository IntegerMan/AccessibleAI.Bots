namespace ChitChatToCluJsonConverter;

public class ImportAssets
{
    public string ProjectKind => "Conversation";
    public List<IntentAsset> Intents { get; set; } = new() { new IntentAsset("None") };
    public List<EntityAsset> Entities { get; set; } = new();
    public List<UtteranceAsset> Utterances { get; set; } = new();
}