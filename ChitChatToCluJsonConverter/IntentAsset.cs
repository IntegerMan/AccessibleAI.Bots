namespace ChitChatToCluJsonConverter;

public class IntentAsset
{
    public IntentAsset(string category = "")
    {
        Category = category;
    }

    public string Category { get; set; }
}