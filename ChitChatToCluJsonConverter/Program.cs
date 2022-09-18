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

        while (!parser.EndOfData)
        {
            string[] row = parser.ReadFields()!;

            string utterance = row[0];
            string intent = row[1];

            Console.WriteLine($"{intent}: {utterance}");
        }

        // TODO: Write the JSON file
    }
}