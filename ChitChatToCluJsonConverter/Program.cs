using System.Text.Json;
using Microsoft.VisualBasic.FileIO;

namespace ChitChatToCluJsonConverter;

public class Program
{
    public static void Main(string[] args)
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

        // TODO: Move the intents into the import object

        foreach (KeyValuePair<string, List<string>> intent in intents)
        {
            import.Assets.Intents.Add(new IntentAsset(intent.Key));

            foreach (string utterance in intent.Value)
            {
                import.Assets.Utterances.Add(new UtteranceAsset(utterance, intent.Key));
            }
        }

        Console.WriteLine("Writing Output");
        string json = JsonSerializer.Serialize(import, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("chitchat.json", json);

        Console.WriteLine("Export complete");
    }

    private static Dictionary<string, List<string>> BuildIntentLists(TextFieldParser parser)
    {
        Dictionary<string, List<string>> intents = new();

        while (!parser.EndOfData)
        {
            string[] row = parser.ReadFields()!;

            string utterance = row[0];
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