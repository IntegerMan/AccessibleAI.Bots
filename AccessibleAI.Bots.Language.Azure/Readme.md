# AccessibleAI.Bots.LanguageUnderstanding

The CLU Helpers project is designed to make interacting with Conversational Language Understanding (CLU) and Orchestration easier while the new version of the .NET SDK is still in development.

This package also includes logic for working with CLU-based chit-chat libraries in an object-oriented manner.

## Intent Resolvers

`IIntentResolver`s map an utterance string to a `LanguageResult` for that utterance.

### CluIntentResolver

The `CluIntentResolver` class allows you to match an intent with its entities from an utterance using Conversational Language Understanding (CLU).

Its usage is as follows:

```cs
CluIntentResolver clu = new CluIntentResolver(_config["CluEndpoint"], _config["CluToken"], _config["CluProject"], _config["CluDeployment"]);

string utterance = context.Activity.Text;

CluResult cluResult = clu.FindIntent(utterance);

switch (cluResult.TopIntent) 
{
	case "Hello":
		await turnContext.SendActivityAsync(MessageFactory.Text("Hi there!"), cancellationToken);
		break;

	case "WantToBuy":
		EntityMatch? entity = intent.GetEntity("ItemToPurchase");
		if (entity != null)
		{
			await turnContext.SendActivityAsync(MessageFactory.Text($"You want to buy {entity.ListKey}"), cancellationToken);
		} else {
			await turnContext.SendActivityAsync(MessageFactory.Text("What exactly do you want to buy?"), cancellationToken);
		}
		break;

	default:
		await turnContext.SendActivityAsync(MessageFactory.Text("I don't know how to reply to " + cluResult.TopIntent), cancellationToken);
		break;
}
```

### OrchestrationIntentResolver

TODO: This class is currently undocumented, but behaves similarly to CluIntentResolver.

### LayeredOrchestrationIntentResolver

This class is an `IIntentResolver` that allows you to use multiple `IIntentResolver`s to resolve intents in a prioritized order. 
This can help with class imbalances between CLU projects or can help prioritize one layer over another.

### PooledOrchestrationIntentResolver

This is a multiple `IIntentResolver` that pools the results of multiple `IIntentResolver`s and returns the most common intent, with 
optional weighting by layer priority. Under this model all layers will be asked for their opinion and the highest confidence wins.

## Conversation

### ChitChatHandlerBase

TODO: This class is currently early in development and is undocumented as a result