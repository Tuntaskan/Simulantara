using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Simulantara.Models;
using Simulantara.Services;
using System.Collections.ObjectModel;

namespace Simulantara.ViewModels;

public partial class HabitDetailViewModel : BaseViewModel
{
    private readonly ProgressService _progressService;
    private readonly DatabaseService _database;
    private readonly UserService _userService;

    [ObservableProperty]
    private Habit? selectedHabit;

    [ObservableProperty]
    private Background? currentBackground;

    public ObservableCollection<HabitProgress> Progresses { get; set; }
    = new();

    public bool HasNoProgress =>
        Progresses.Count == 0;

    public HabitDetailViewModel(
    ProgressService progressService,
    DatabaseService database,
    UserService userService)
    {
        _progressService = progressService;
        _database = database;
        _userService = userService;

        Progresses.CollectionChanged += (s, e) =>
        {
            OnPropertyChanged(nameof(HasNoProgress));
        };
    }

    public async Task SetHabit(Habit habit)
    {
        SelectedHabit = habit;

        await LoadBackgroundAsync();

        await LoadProgresses();
    }

    [RelayCommand]
    public async Task LoadProgresses()
    {
        if (SelectedHabit == null)
            return;

        var progresses =
            await _database.GetProgressByHabitAsync(
                SelectedHabit.Id);

        Progresses.Clear();

        foreach (var progress in progresses)
            Progresses.Add(progress);
    }

    [RelayCommand]
    public async Task AddProgress()
    {
        if (SelectedHabit == null)
            return;

        await _progressService
            .AddProgressAsync(SelectedHabit);

        await LoadProgresses();
    }

    [RelayCommand]
    public async Task OpenBackgroundCustom()
    {
        await Shell.Current.GoToAsync(nameof(Views.BackgroundCustomPage));
    }

    public async Task LoadBackgroundAsync()
    {
        var user = await _userService.GetUserAsync();

        if (user == null)
            return;

        CurrentBackground =
            await _userService
            .GetCurrentBackgroundAsync(
                user.CurrentBackgroundId);
    }
}