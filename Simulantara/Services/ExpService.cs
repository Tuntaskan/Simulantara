using Simulantara.Models;

namespace Simulantara.Services;

public class ExpService
{
    private readonly UserService _userService;

    public ExpService(UserService userService)
    {
        _userService = userService;
    }

    public async Task AddExpAsync(int expAmount)
    {
        var user = await _userService.GetUserAsync();

        if (user == null)
            return;

        user.Exp += expAmount;

        while (user.Exp >= 100)
        {
            user.Exp -= 100;
            user.Level++;
        }

        await _userService.SaveUserAsync(user);
    }
}