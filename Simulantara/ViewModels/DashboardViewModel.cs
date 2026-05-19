using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Simulantara.Models;
using Simulantara.Services;
using System.Collections.ObjectModel;

namespace Simulantara.ViewModels;

public partial class DashboardViewModel : BaseViewModel
{
    private readonly UserService _userService;
    private readonly HabitService _habitService;
    private readonly NotificationService _notificationService;

    [ObservableProperty]
    private User? user;

    [ObservableProperty]
    private string npcMessage = "";

    [ObservableProperty]
    private NPC? currentNpc;

    [ObservableProperty]
    private Background? currentBackground;

    public ObservableCollection<Habit> Habits { get; set; }
        = new();

    public DashboardViewModel(
        UserService userService,
        HabitService habitService,
        NotificationService notificationService)
    {
        _userService = userService;
        _habitService = habitService;
        _notificationService = notificationService;
    }

    [RelayCommand]
    public async Task LoadData()
    {
        User = await _userService.GetUserAsync();

        if (User != null)
        {
            CurrentNpc =
                await _userService.GetCurrentNpcAsync(User.CurrentNpcId);

            CurrentBackground =
                await _userService.GetCurrentBackgroundAsync(
                    User.CurrentBackgroundId);
        }

        var habits =
            await _habitService.GetHabitsAsync();

        Habits.Clear();

        foreach (var habit in habits)
            Habits.Add(habit);

        NpcMessage =
            _notificationService.GetRandomMessage();
    }

    [RelayCommand]
    public async Task OpenHabitManage()
    {
        await Shell.Current.GoToAsync(nameof(Views.HabitManagePage));
    }

    [RelayCommand]
    public async Task OpenProfile()
    {
        await Shell.Current.GoToAsync(nameof(Views.ProfilePage));
    }

    [RelayCommand]
    public async Task OpenHabitDetail(Habit habit)
    {
        if (habit == null)
            return;

        var page =
            App.Current.Handler.MauiContext.Services
            .GetService<Views.HabitDetailPage>();

        var vm =
            page.BindingContext as HabitDetailViewModel;

        if (vm != null)
        {
            await vm.SetHabit(habit);
        }

        await Shell.Current.Navigation.PushAsync(page);
    }

    [RelayCommand]
    public async Task OpenNpcCustom()
    {
        await Shell.Current.GoToAsync(nameof(Views.NpcCustomPage));
    }

    [RelayCommand]
    public async Task OpenBackgroundCustom()
    {
        await Shell.Current.GoToAsync(nameof(Views.BackgroundCustomPage));
    }
}