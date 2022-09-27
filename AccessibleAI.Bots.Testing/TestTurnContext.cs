using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace AccessibleAI.Bots.Testing;

public class TestTurnContext : ITurnContext
{
    public IEnumerable<string> Messages => Activities.Select(a => a.Text).Where(m => m != null);
    public List<Activity> Activities { get; } = new List<Activity>();

    public BotAdapter Adapter => throw new NotImplementedException();

    public TurnContextStateCollection TurnState => throw new NotImplementedException();

    public Activity Activity => throw new NotImplementedException();

    public bool Responded => throw new NotImplementedException();

    public Task DeleteActivityAsync(string activityId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteActivityAsync(ConversationReference conversationReference, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ITurnContext OnDeleteActivity(DeleteActivityHandler handler)
    {
        throw new NotImplementedException();
    }

    public ITurnContext OnSendActivities(SendActivitiesHandler handler)
    {
        throw new NotImplementedException();
    }

    public ITurnContext OnUpdateActivity(UpdateActivityHandler handler)
    {
        throw new NotImplementedException();
    }

    public Task<ResourceResponse[]> SendActivitiesAsync(IActivity[] activities, CancellationToken cancellationToken = default)
    {
        IEnumerable<Activity> concreteActivities = activities.Cast<Activity>();
        Activities.AddRange(concreteActivities);

        return Task.FromResult(Array.Empty<ResourceResponse>());
    }

    public Task<ResourceResponse> SendActivityAsync(string textReplyToSend, string speak = null, string inputHint = "acceptingInput", CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ResourceResponse> SendActivityAsync(IActivity activity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ResourceResponse> UpdateActivityAsync(IActivity activity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}