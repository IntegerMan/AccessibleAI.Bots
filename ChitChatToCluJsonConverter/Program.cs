using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;

namespace ChitChatToCluJsonConverter;

public class Program
{
    public static void Main()
    {
        string csvFile = @"chitchat.tsv";
        TextFieldParser parser = new(csvFile);
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters("\t");
        parser.ReadFields(); // Skip the header row

        Console.WriteLine("Reading Input");
        Dictionary<string, List<string>> intents = BuildIntentLists(parser);


        Console.WriteLine("Transforming Input");
        IntentImport import = new();

        // TODO: Move the Intents into the import object

        foreach (KeyValuePair<string, List<string>> intent in intents)
        {
            import.Assets.Intents.Add(new IntentAsset(intent.Key));

            foreach (string utterance in intent.Value)
            {
                import.Assets.Utterances.Add(new UtteranceAsset(utterance, intent.Key));
            }
        }

        Console.WriteLine("Writing Output");
        JsonSerializer serializer = new();

        using (StreamWriter sw = new("chitchat.json"))
        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            writer.Formatting = Formatting.Indented;

            serializer.Serialize(writer, import);
        }

        Console.WriteLine("Export complete");
    }

    private static Dictionary<string, List<string>> BuildIntentLists(TextFieldParser parser)
    {
        HashSet<string> utterances = new();
        Dictionary<string, List<string>> intents = new();

        while (!parser.EndOfData)
        {
            string[] row = parser.ReadFields()!;

            string utterance = row[0];

            // Some of the chit chat stuff actually has duplicates, which CLU import doesn't like, so enforce uniqueness
            if (utterances.Contains(utterance))
            {
                continue;
            }
            utterances.Add(utterance);

            string intent = row[1];

            if (!intents.ContainsKey(intent))
            {
                intents.Add(intent, new List<string>());
            }

            intents[intent].Add(utterance);
        }

        return intents;
    }
}