using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Simulantara.Models;
using Simulantara.Services;
using System.Collections.ObjectModel;

namespace Simulantara.ViewModels;

public partial class BackgroundCustomViewModel
    : BaseViewModel
{
    private readonly NPCService _npcService;
    private readonly UserService _userService;

    public ObservableCollection<Background> Backgrounds
        = new();

    [ObservableProperty]
    private User? user;

    public BackgroundCustomViewModel(
        NPCService npcService,
        UserService userService)
    {
        _npcService = npcService;
        _userService = userService;
    }

    [RelayCommand]
    public async Task LoadBackgrounds()
    {
        User = await _userService.GetUserAsync();

        var backgrounds =
            await _npcService.GetUnlockedBackgroundsAsync();

        Backgrounds.Clear();

        foreach (var background in backgrounds)
            Backgrounds.Add(background);
    }

    [RelayCommand]
    public async Task SelectBackground(
        Background background)
    {
        if (User == null)
            return;

        User.CurrentBackgroundId =
            background.Id;

        await _userService.SaveUserAsync(User);
    }
}