using Newtonsoft.Json;

namespace ChitChatToCluJsonConverter;

public class IntentImport
{
    [JsonProperty("projectFileVersion")]
    public string ProjectFileVersion => "2022-05-01";
    
    [JsonProperty("stringIndexType")]
    public string StringIndexType => "Utf16CodeUnit";

    [JsonProperty("metadata")]
    public ImportMetadata Metadata { get; set; } = new();
    
    [JsonProperty("assets")]
    public ImportAssets Assets { get; set; } = new();
}