using System.Text;

namespace AccessibleAI.Bots.Blobs;

internal static class StringHelpers
{
    public static void AppendIfNotEmpty(this StringBuilder sb, string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return;

        sb.AppendLine(text);
    }

}