# AccessibleAI.Bots.Blobs

Details coming soon...

## Conversation Logging

In your `Startup.cs` file we'll need to add or expand the existing constructor as follows to create a `ConversationBlobStorage` class:

```cs
private readonly ITranscriptStore _conversationStorage;

public Startup(IConfiguration config)
{
    _conversationStorage = new ConversationBlobStorage(config.GetValue<string>("StorageConnStr"), config.GetValue<string>("ConversationContainerName"));
}
```

Note that `StorageConnStr` and `ConversationContainerName` refer to settings in your appsettings.json file. Customize these values with whatever settings you're using.

Also note that the storage container must already exist. You can create it using [Azure Storage Explorer](https://azure.microsoft.com/en-us/products/storage/storage-explorer/) or the Azure Portal.

Next we'll need to add the following to the `ConfigureServices` method:

```cs
services.AddSingleton(_conversationStorage);
services.AddSingleton<IMiddleware, TranscriptLoggerMiddleware>(_ => new TranscriptLoggerMiddleware(_conversationStorage));
```

Next, in your bot's `AdapterWithErrorHandler` or similar `CloudAdapter` constructor, you'll need to add an `ITranscriptStore transcriptLogger` parameter to the parameter list.

After that, you should add the following line:

```cs
Use(new TranscriptLoggerMiddleware(transcriptLogger));
```

