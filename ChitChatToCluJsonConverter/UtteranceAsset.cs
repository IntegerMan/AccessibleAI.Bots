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

    public string Text { get; set; }
    public string Language { get; set; } = "en-us";
    public string Intent { get; set; } = "None";
    public List<EntityAsset> Entities { get; set; } = new();
    public string Dataset { get; set; } = "Train";
}