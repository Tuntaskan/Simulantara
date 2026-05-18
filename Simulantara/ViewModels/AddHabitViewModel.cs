using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Simulantara.Models;
using Simulantara.Services;
using System.Collections.ObjectModel;

namespace Simulantara.ViewModels;

public partial class AddHabitViewModel : BaseViewModel
{
    private readonly HabitService _habitService;
    private readonly DatabaseService _database;

    [ObservableProperty]
    private string habitName = "";

    [ObservableProperty]
    private string description = "";

    [ObservableProperty]
    private Category? selectedCategory;

    public ObservableCollection<Category> Categories { get; set; }
    = new();

    public AddHabitViewModel(
        HabitService habitService,
        DatabaseService database)
    {
        _habitService = habitService;
        _database = database;
    }

    public async Task InitializeAsync()
    {
        await _database.InitAsync();
        await LoadCategories();
    }

    [RelayCommand]
    public async Task LoadCategories()
    {
        var categories =
            await _database.GetCategoriesAsync();

        Categories.Clear();

        foreach (var category in categories)
            Categories.Add(category);
    }

    [RelayCommand]
    public async Task SaveHabit()
    {
        if (string.IsNullOrWhiteSpace(HabitName))
        {
            await Shell.Current.DisplayAlert(
                "Error",
                "Habit name wajib diisi",
                "OK");

            return;
        }

        if (SelectedCategory == null)
        {
            await Shell.Current.DisplayAlert(
                "Error",
                "Pilih category terlebih dahulu",
                "OK");

            return;
        }

        Habit habit = new()
        {
            Name = HabitName,
            Description = Description,
            CategoryId = SelectedCategory.Id
        };
            
        await _habitService.AddHabitAsync(habit);

        await Shell.Current.GoToAsync(nameof(Views.HabitManagePage));
    }

    [RelayCommand]
    public async Task GoToManageCategory()
    {
        await Shell.Current.GoToAsync(nameof(Views.ManageCategoryPage));
    }

    [RelayCommand]
    public async Task Back()
    {
        await Shell.Current.GoToAsync(nameof(Views.HabitManagePage));
    }
}