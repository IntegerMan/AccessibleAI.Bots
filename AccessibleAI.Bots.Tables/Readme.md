# AccessibleAI.Bots.Tables

Azure Table Storage helpers for Microsoft Bot Framework chatbot development.

The intent of these offerings is to provide a table storage means of accessing a variety of bot content so that bots do not need to be frequently redeployed as edits and expansions are made.

## TableEntityRepository

The `TableEntityRepository` class lets you pull `TableEntities` out of an Azure Table Storage by a partition key and row key.

This can be used to retrieve response data for a particular intent, possibly including additional information such as a card header, title, additional links, etc.

This class is still early on in its development and will make more sense once AccessibleAI.Bots.Core is available.

### Usage

```cs
TableEntityRepository definitions = new TableEntityRepository(config["StorageConnStr"], config["DefinitionTableName"], config["DefinitionPartitionKey"])

string rowKey = "YourIntentName";

Definition? definition = definitions.FindDefinition(rowKey);

if (definition == null)
{
	await turnContext.SendActivityAsync(MessageFactory.Text($"I'm sorry, I couldn't find info on {rowKey}"), cancellationToken);
}
else
{
	await turnContext.SendActivityAsync(MessageFactory.Text(definition.DefinitionText), cancellationToken);
}
```