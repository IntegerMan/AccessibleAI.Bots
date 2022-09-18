namespace ChitChatToCluJsonConverter;

public class IntentImport
{
    public string ProjectFileVersion => "2022-05-01";
    public string StringIndexType => "Utf16CodeUnit";
    public ImportMetadata Metadata { get; set; } = new();
    public ImportAssets Assets { get; set; } = new();
}