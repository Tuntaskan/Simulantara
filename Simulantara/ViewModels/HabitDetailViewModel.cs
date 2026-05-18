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

    [ObservableProperty]
    private Habit? selectedHabit;

    public ObservableCollection<HabitProgress> Progresses { get; set; }
    = new();

    public bool HasNoProgress =>
        Progresses.Count == 0;

    public HabitDetailViewModel(
        ProgressService progressService,
        DatabaseService database)
    {
        _progressService = progressService;
        _database = database;
    }

    public async Task SetHabit(Habit habit)
    {
        SelectedHabit = habit;

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
}