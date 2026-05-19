namespace Simulantara.Services;

public class NotificationService
{
    private readonly List<string> _messages =
        new()
        {
            "Cheer up! You did great today!",
            "Don't give up now!",
            "A little progress is still progress!",
            "Let's keep up your streak!",
            "Consistency is more important than perfection!"
        };

    public string GetRandomMessage()
    {
        Random random = new();

        int index = random.Next(_messages.Count);

        return _messages[index];
    }
}