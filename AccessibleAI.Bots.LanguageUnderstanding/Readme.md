# AccessibleAI.Bots.CluHelpers

The CLU Helpers project is designed to make interacting with Conversational Language Understanding (CLU) easier while the new version of the .NET SDK is still in development.

## CluIntentResolver

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