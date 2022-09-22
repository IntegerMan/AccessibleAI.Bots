using Azure.Core;

namespace AccessibleAI.Bots.LanguageUnderstanding.Helpers;

internal static class RequestHelpers
{
    internal static RequestContent BuildLanguageRequest(string utterance, string project, string deployment) 
        => RequestContent.Create(new
        {
            analysisInput = new
            {
                conversationItem = new
                {
                    text = utterance,
                    id = "1",
                    participantId = "1",
                }
            },
            parameters = new
            {
                projectName = project,
                deploymentName = deployment,

                // Use Utf16CodeUnit for strings in .NET.
                stringIndexType = "Utf16CodeUnit",
            },
            kind = "Conversation",
        });
}