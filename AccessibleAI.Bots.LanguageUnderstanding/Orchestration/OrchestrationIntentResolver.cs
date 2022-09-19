using System.Text.Json;
using AccessibleAI.Bots.LanguageUnderstanding.Helpers;
using AccessibleAI.Bots.LanguageUnderstanding.Models;
using Azure;
using Azure.AI.Language.Conversations;
using Azure.Core;

namespace AccessibleAI.Bots.LanguageUnderstanding.Orchestration
{
    public class OrchestrationIntentResolver : IIntentResolver
    {
        private readonly Uri _endpoint;
        private readonly string _apiKey;
        private readonly string _project;
        private readonly string _deployment;

        public OrchestrationIntentResolver(string endpoint, string apiKey, string project, string deployment)
        {
            _endpoint = new Uri(endpoint);
            _apiKey = apiKey;
            _project = project;
            _deployment = deployment;
        }
        private Response MakeRequest(string utterance)
        {
            AzureKeyCredential credential = new(_apiKey);
            ConversationAnalysisClient client = new(_endpoint, credential);

            RequestContent requestData = RequestHelpers.BuildLanguageRequest(utterance, _project, _deployment);
            
            Response response = client.AnalyzeConversation(requestData);
            return response;
        }

        private static LanguageResult GetIntentResultFromResponse(JsonElement conversationPrediction)
        {
            /* Sample JSON Result
            {
              "kind": "ConversationResult",
              "result": {
                "query": "Hello there",
                "prediction": {
                  "topIntent": "ChitChat",
                  "projectKind": "Orchestration",
                  "intents": {
                    "ChitChat": {
                      "confidenceScore": 1,
                      "targetProjectKind": "Conversation",
                      "result": {
                        "query": "Hello there",
                        "prediction": {
                          "topIntent": "ChitChat.Hello",
                          "projectKind": "Conversation",
                          "intents": [
                            {
                              "category": "ChitChat.Hello",
                              "confidenceScore": 0.9816466
                            },
                            {
                              "category": "ChitChat.CanYouChatWithMe",
                              "confidenceScore": 0.966536
                            },
                            {
                              "category": "ChitChat.HelloOtherBot",
                              "confidenceScore": 0.9552968
                            },
                            {
                              "category": "ChitChat.HowAreYou",
                              "confidenceScore": 0.94162464
                            },
                            {
                              "category": "ChitChat.IsThisWorking",
                              "confidenceScore": 0.9386898
                            },
                            {
                              "category": "ChitChat.CanYouClarifyThat",
                              "confidenceScore": 0.93746716
                            },
                            {
                              "category": "ChitChat.TellMeAboutMe",
                              "confidenceScore": 0.92941564
                            },
                            {
                              "category": "ChitChat.ThankYou",
                              "confidenceScore": 0.9284721
                            },
                          ],
                          "entities": []
                        }
                      }
                    },
                    "SingularityClu": {
                      "confidenceScore": 0.8278525,
                      "targetProjectKind": "Conversation"
                    },
                    "None": {
                      "confidenceScore": 0,
                      "targetProjectKind": "NonLinked"
                    }
                  }
                }
              }
            }
             */

            LanguageResult intent = new()
            {
                OrchestrationIntentName = conversationPrediction.GetProperty("topIntent").GetString()!
            };

            JsonElement subIntent = conversationPrediction.GetProperty("intents")
                                                          .GetProperty(intent.OrchestrationIntentName)
                                                          .GetProperty("result")
                                                          .GetProperty("prediction");

            intent.IntentName = subIntent.GetProperty("topIntent").GetString()!;

            IntentLoadHelpers.ExtractIntents(intent, subIntent.GetProperty("intents"));
            IntentLoadHelpers.ExtractEntities(intent, subIntent.GetProperty("entities"));

            return intent;
        }

        public LanguageResult FindIntent(string utterance)
        {
            Response response = MakeRequest(utterance);

            using JsonDocument result = JsonDocument.Parse(response.ContentStream!);
            JsonElement conversationalTaskResult = result.RootElement;
            JsonElement conversationPrediction = conversationalTaskResult.GetProperty("result")
                                                                         .GetProperty("prediction");


            LanguageResult intent = GetIntentResultFromResponse(conversationPrediction);

            return intent;
        }
    }
}