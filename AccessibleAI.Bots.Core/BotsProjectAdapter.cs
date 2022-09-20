// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio CoreBot v4.16.0

using System;
using AccessibleAI.Bots.Core.Intents;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Builder.TraceExtensions;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;

namespace AccessibleAI.Bots.Core;

public class BotsProjectAdapter : CloudAdapter
{
    public BotsProjectAdapter(BotFrameworkAuthentication auth, 
        ITranscriptStore transcriptLogger, 
        ILogger<IBotFrameworkHttpAdapter> logger, 
        ConversationState? conversationState = default)
        : base(auth, logger)
    {
        Use(new TranscriptLoggerMiddleware(transcriptLogger));

        OnTurnError = async (turnContext, exception) =>
        {
            // Log any leaked exception from the application.
            logger.LogError(exception, $"[OnTurnError] unhandled error : {exception.Message}");

            // Send a message to the user
            string errorMessageText = "The bot encountered an error or bug";

            // Add extra error text for the emulator
            if (turnContext.IsEmulator())
            {
                errorMessageText += $": {exception.Message}{Environment.NewLine}{exception.StackTrace}";
            }

            Activity errorMessage = MessageFactory.Text(errorMessageText, errorMessageText, InputHints.ExpectingInput);
            await turnContext.SendActivityAsync(errorMessage);

            errorMessageText = "To continue to run this bot, please fix the bot source code.";
            errorMessage = MessageFactory.Text(errorMessageText, errorMessageText, InputHints.ExpectingInput);
            await turnContext.SendActivityAsync(errorMessage);

            if (conversationState != null)
            {
                try
                {
                    // Delete the conversationState for the current conversation to prevent the
                    // bot from getting stuck in a error-loop caused by being in a bad state.
                    // ConversationState should be thought of as similar to "cookie-state" in a Web pages.
                    await conversationState.DeleteAsync(turnContext);
                }
                catch (Exception e)
                {
                    logger.LogError(e, $"Exception caught on attempting to Delete ConversationState : {e.Message}");
                }
            }

            // Send a trace activity, which will be displayed in the Bot Framework Emulator
            await turnContext.TraceActivityAsync("OnTurnError Trace", exception.Message, "https://www.botframework.com/schemas/error", "TurnError");
        };
    }
}