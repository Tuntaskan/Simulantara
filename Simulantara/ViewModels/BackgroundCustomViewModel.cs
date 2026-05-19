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

    public ObservableCollection<Background> Backgrounds { get; set; }
    = new();

    [ObservableProperty]
    private User? user;

    [ObservableProperty]
    private Background? selectedBackground;

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
            await _npcService.GetAllBackgroundsAsync();

        Backgrounds.Clear();

        foreach (var background in backgrounds)
            Backgrounds.Add(background);

        SelectedBackground = backgrounds
            .FirstOrDefault(x => x.Id == User.CurrentBackgroundId);
    }

    [RelayCommand]
    public async Task SelectBackground(
    Background background)
    {
        if (User == null)
            return;

        // background belum unlock
        if (User.Level < background.UnlockLevel)
            return;

        User.CurrentBackgroundId =
            background.Id;

        SelectedBackground = background;

        await _userService.SaveUserAsync(User);
    }
}