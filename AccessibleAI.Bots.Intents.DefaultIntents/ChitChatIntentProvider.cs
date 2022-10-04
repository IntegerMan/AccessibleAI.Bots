using AccessibleAI.Bots.Core.Language;
using AccessibleAI.Bots.Language.Levenshtein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessibleAI.Bots.Intents.DefaultIntents;

public class ChitChatIntentResolver : LevenshteinTextFileEntityProvider
{
    public ChitChatIntentResolver(string filePath = "chitchat.tsv") : base(filePath)
    {
    }

}
