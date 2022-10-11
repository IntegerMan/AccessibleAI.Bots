using System.Collections.Generic;
using Microsoft.Bot.Schema;

namespace AccessibleAI.Bots.Core.Intents;

public class CardInformation
{
    public CardInformation(string title, string text, string? imageUrl = null) : this(title, null, text, imageUrl, null)
    {
    }

    public CardInformation(string title, string? subtitle, string text, string? imageUrl = null, string? imageAltText = null,
        List<CardAction>? actions = null)
    {
        Title = title;
        Subtitle = subtitle;
        Text = text;
        ImageUrl = imageUrl;
        ImageAltText = imageAltText;
        Actions = actions;
    }

    public string Title { get; }
    public string? Subtitle { get; }
    public string Text { get; }
    public string? ImageUrl { get; }
    public string? ImageAltText { get; }
    public List<CardAction>? Actions { get; }
}