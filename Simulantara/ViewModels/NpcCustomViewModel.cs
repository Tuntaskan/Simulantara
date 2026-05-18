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

    public ObservableCollection<NPC> NPCs
        = new();

    [ObservableProperty]
    private User? user;

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
            await _npcService.GetUnlockedNPCsAsync();

        NPCs.Clear();

        foreach (var npc in npcs)
            NPCs.Add(npc);
    }

    [RelayCommand]
    public async Task SelectNPC(NPC npc)
    {
        if (User == null)
            return;

        User.CurrentNpcId = npc.Id;

        await _userService.SaveUserAsync(User);
    }
}