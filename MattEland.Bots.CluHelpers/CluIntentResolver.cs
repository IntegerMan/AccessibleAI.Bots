using System;
using System.IO;
using System.Text;
using System.Text.Json;
using Azure;
using Azure.AI.Language.Conversations;
using Azure.Core;

namespace MattEland.Bots.CluHelpers
{

    public class CluIntentResolver
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

        public CluResult FindIntent(string utterance)
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

            using JsonDocument result = JsonDocument.Parse(response.ContentStream);
            string json = ToJsonString(result.RootElement);
            JsonElement conversationalTaskResult = result.RootElement;
            JsonElement conversationPrediction = conversationalTaskResult.GetProperty("result").GetProperty("prediction");

            CluResult intent = GetIntentResultFromCluResponse(conversationPrediction);

            

            return intent;
        }

        private static CluResult GetIntentResultFromCluResponse(JsonElement conversationPrediction)
        {
            CluResult intent = new()
            {
                TopIntent = conversationPrediction.GetProperty("topIntent").GetString()
            };

            foreach (JsonElement intentJson in conversationPrediction.GetProperty("intents").EnumerateArray())
            {
                IntentMatch intentMatch = new()
                {
                    Category = intentJson.GetProperty("category").ToString(),
                    ConfidenceScore = intentJson.GetProperty("confidenceScore").GetSingle()
                };

                intent.AddMatchingIntent(intentMatch);
            }

            foreach (JsonElement entityJson in conversationPrediction.GetProperty("entities").EnumerateArray())
            {
                EntityMatch entity = new()
                {
                    Category = entityJson.GetProperty("category").GetString(),
                    Text = entityJson.GetProperty("text").GetString(),
                    Offset = entityJson.GetProperty("offset").GetInt32(),
                    Length = entityJson.GetProperty("length").GetInt32(),
                    ConfidenceScore = entityJson.GetProperty("confidenceScore").GetSingle()
                };

                if (entityJson.TryGetProperty("extraInformation", out JsonElement extraInfo))
                {
                    foreach (JsonElement info in extraInfo.EnumerateArray())
                    {
                        string kind = info.GetProperty("extraInformationKind").GetString();
                        if (kind == "ListKey")
                        {
                            entity.ListKey = info.GetProperty("key").GetString();
                        }
                    }
                }

                intent.AddEntity(entity);
            }

            return intent;
        }

        private Response MakeCluRequest(string utterance)
        {
            AzureKeyCredential credential = new(_apiKey);
            ConversationAnalysisClient client = new(_endpoint, credential);

            var data = new
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
                    projectName = _project,
                    deploymentName = _deployment,

                    // Use Utf16CodeUnit for strings in .NET.
                    stringIndexType = "Utf16CodeUnit",
                },
                kind = "Conversation",
            };

            RequestContent requestData = RequestContent.Create(data);
            Response response = client.AnalyzeConversation(requestData);
            return response;
        }

        public static string ToJsonString(JsonElement jsonElement)
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
}
