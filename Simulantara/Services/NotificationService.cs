namespace Simulantara.Services;

public class NotificationService
{
    public async Task ShowNPCPopup(string message)
    {
        await Application.Current.MainPage.DisplayAlert(
            "NPC Simulantara",
            message,
            "OK");
    }
}