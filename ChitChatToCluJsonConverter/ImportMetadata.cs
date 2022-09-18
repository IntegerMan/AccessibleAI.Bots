namespace ChitChatToCluJsonConverter;

public class ImportMetadata
{
    public string ProjectKind => "Conversation";
    public string ProjectName => "chit-chat-clu-intents";
    public ImportSettings Settings { get; set; } = new();
    public string Language => "en-us";
    public string Description => "";
    public bool Multilingual => false;
}