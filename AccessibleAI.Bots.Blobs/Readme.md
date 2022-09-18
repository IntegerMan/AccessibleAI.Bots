# AccessibleAI.Bots.Blobs

This package contains utility classes related to bot management using Azure Storage Blobs.

## Conversation Logging

This project comes with a `ConversationBlobStorage` class that can be used to log all conversations to Azure Blob Storage in a human-readable format like the following:

```
singularity-sally 
Hi, I'm Singularity Sally and I'm here to help you learn data science!

singularity-sally 
Please tell me what you'd like to learn about today.

You @ 9/17/2022 11:38:09 PM 
I want to learn about AI!

singularity-sally 

Artificial Intelligence, or AI, refers to the capability for computers to emulate the decision-making processes of creatures (including humans). AI includes everything in machine learning and deep learning along with conversational AI, game AI, decision trees, and other forms of AI.
```

### Usage
In your `Startup.cs` file add a using statement to get access to the `AccessibleAI.Bots.Blobs` namespace:

```cs
using AccessibleAI.Bots.Blobs;
```

Next we'll need to add or expand the existing constructor as follows to create a `ConversationBlobStorage` class:

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

Once you deploy your app, new conversation logs will appear in your Azure Storage container.

Note that you may want to delete old months and years and only store the most recent conversations. Right now there is no provided mechanism in this library for doing that.