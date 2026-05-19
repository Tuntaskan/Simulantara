using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Simulantara.Models;
using Simulantara.Services;
using System.Collections.ObjectModel;

namespace Simulantara.ViewModels;

public partial class HabitManageViewModel : BaseViewModel
{
    private readonly HabitService _habitService;
    private readonly UserService _userService;

    public ObservableCollection<Habit> Habits { get; set; }
        = new();

    public HabitManageViewModel(HabitService habitService, UserService userService)
    {
        _habitService = habitService;
        _userService = userService;
    }

    [ObservableProperty]
    private Background? currentBackground;

    [ObservableProperty]
    private bool hasNoHabits = true;

    [RelayCommand]
    public async Task LoadHabits()
    {
        var user = await _userService.GetUserAsync();

        if (user != null)
        {
            CurrentBackground =
                await _userService.GetCurrentBackgroundAsync(
                    user.CurrentBackgroundId);
        }

        var habits = await _habitService.GetHabitsAsync();

        Habits.Clear();

        foreach (var habit in habits)
            Habits.Add(habit);

        HasNoHabits = Habits.Count == 0;
    }

    [RelayCommand]
    public async Task AddHabit()
    {
        await Shell.Current.GoToAsync(nameof(Views.AddHabitPage));
    }

    [RelayCommand]
    public async Task DeleteHabit(Habit habit)
    {
        await _habitService.DeleteHabitAsync(habit);

        Habits.Remove(habit);

        HasNoHabits = Habits.Count == 0;
    }

    [RelayCommand]
    public async Task OpenDashboard()
    {
        await Shell.Current.GoToAsync("///DashboardPage");
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