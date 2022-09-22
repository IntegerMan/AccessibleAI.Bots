using System;
using System.Text.Json;
using AccessibleAI.Bots.Core.Language;
using AccessibleAI.Bots.LanguageUnderstanding.Helpers;
using Azure;
using Azure.AI.Language.Conversations;
using Azure.Core;

namespace AccessibleAI.Bots.LanguageUnderstanding.Conversational;

public class CluIntentResolver : IIntentResolver
{
    private readonly Uri _endpoint;
    private readonly string _apiKey;
    private readonly string _project;
    private readonly string _deployment;

    public CluIntentResolver(string endpoint, string apiKey, string project, string deployment)
    {
        _endpoint = new Uri(endpoint);
        _apiKey = apiKey;
        _project = project;
        _deployment = deployment;
    }

    public IntentResolutionResult FindIntent(string utterance)
    {
        Response response = MakeCluRequest(utterance);

        /* Sample JSON Result:

        {
          "kind": "ConversationResult",
          "result": {
            "query": "What is the Matrix?",
            "prediction": {
              "topIntent": "WhatIs",
              "projectKind": "Conversation",
              "intents": [
                {
                  "category": "WhatIs",
                  "confidenceScore": 1
                },
                {
                  "category": "None",
                  "confidenceScore": 0.35893255
                }
              ],
              "entities": [
                {
                  "category": "Topic",
                  "text": "the Matrix",
                  "offset": 8,
                  "length": 10,
                  "confidenceScore": 1
                }
              ]
            }
          }
        }

        */

        using JsonDocument result = JsonDocument.Parse(response.ContentStream!);
        JsonElement conversationalTaskResult = result.RootElement;
        JsonElement conversationPrediction = conversationalTaskResult.GetProperty("result").GetProperty("prediction");

        IntentResolutionResult intent = GetIntentResultFromCluResponse(conversationPrediction);

        return intent;
    }

    private static IntentResolutionResult GetIntentResultFromCluResponse(JsonElement conversationPrediction)
    {
        IntentResolutionResult intent = new()
        {
            IntentName = conversationPrediction.GetProperty("topIntent").GetString()!
        };

        IntentLoadHelpers.ExtractIntents(intent, conversationPrediction.GetProperty("intents"));
        IntentLoadHelpers.ExtractEntities(intent, conversationPrediction.GetProperty("entities"));

        return intent;
    }

    private Response MakeCluRequest(string utterance)
    {
        AzureKeyCredential credential = new(_apiKey);
        ConversationAnalysisClient client = new(_endpoint, credential);

        RequestContent requestData = RequestHelpers.BuildLanguageRequest(utterance, _project, _deployment);

        return client.AnalyzeConversation(requestData);
    }
}