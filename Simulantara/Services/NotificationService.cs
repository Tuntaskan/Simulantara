namespace Simulantara.Services;

public class NotificationService
{
    private readonly List<string> _messages =
        new()
        {
            "Semangat! Kamu hebat hari ini!",
            "Jangan menyerah sekarang!",
            "Sedikit progress tetap progress!",
            "Ayo lanjut streak kamu!",
            "Konsisten lebih penting daripada sempurna!"
        };

    public string GetRandomMessage()
    {
        Random random = new();

        int index = random.Next(_messages.Count);

        return _messages[index];
    }
}