using System.IO;
using System.Text;
using System.Text.Json;

namespace AccessibleAI.Bots.Core.Helpers;

public static class JsonHelpers
{
    public static string ToJsonString(this JsonElement jsonElement)
    {
        using (MemoryStream stream = new())
        {
            Utf8JsonWriter writer = new(stream, new JsonWriterOptions { Indented = true });
            jsonElement.WriteTo(writer);
            writer.Flush();
            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }

}