using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Simulantara.Models;
using Simulantara.Services;
using System.Collections.ObjectModel;

namespace Simulantara.ViewModels;

public partial class NpcCustomViewModel : BaseViewModel
{
    private readonly NPCService _npcService;
    private readonly UserService _userService;

    public ObservableCollection<NPC> NPCs { get; set; }
    = new();

    [ObservableProperty]
    private User? user;

    [ObservableProperty]
    private NPC? selectedNpc;

    [ObservableProperty]
    private Background? selectedBackground;

    public NpcCustomViewModel(
        NPCService npcService,
        UserService userService)
    {
        _npcService = npcService;
        _userService = userService;
    }

    [RelayCommand]
    public async Task LoadNPCs()
    {
        User = await _userService.GetUserAsync();

        var npcs =
            await _npcService.GetAllNPCsAsync();

        NPCs.Clear();

        foreach (var npc in npcs)
            NPCs.Add(npc);

        SelectedNpc = npcs
            .FirstOrDefault(x => x.Id == User.CurrentNpcId);

        SelectedBackground =
            await _userService.GetCurrentBackgroundAsync(User.CurrentBackgroundId);
    }

    [RelayCommand]
    public async Task SelectNPC(NPC npc)
    {
        if (User == null)
            return;

        if (User.Level < npc.UnlockLevel)
            return;

        User.CurrentNpcId = npc.Id;

        SelectedNpc = npc;

        await _userService.SaveUserAsync(User);
    }
}