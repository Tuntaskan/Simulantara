using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Simulantara.Models;
using Simulantara.Services;
using System.Collections.ObjectModel;

namespace Simulantara.ViewModels;

public partial class ManageCategoryViewModel : BaseViewModel
{
    private readonly DatabaseService _database;
    private readonly UserService _userService;

    [ObservableProperty]
    private string categoryName = "";

    [ObservableProperty]
    private Background? currentBackground;

    public ObservableCollection<Category> Categories { get; set; }
    = new();

    public ManageCategoryViewModel(
    DatabaseService database,
    UserService userService)
    {
        _database = database;
        _userService = userService;
    }

    [RelayCommand]
    public async Task LoadCategories()
    {
        await LoadBackgroundAsync();

        var categories =
            await _database.GetCategoriesAsync();

        Categories.Clear();

        foreach (var category in categories)
            Categories.Add(category);
    }

    [RelayCommand]
    public async Task AddCategory()
    {
        if (string.IsNullOrWhiteSpace(CategoryName))
            return;

        Category category = new()
        {
            Name = CategoryName,
            IsDefault = false
        };

        await _database.SaveCategoryAsync(category);

        CategoryName = "";

        await LoadCategories();
    }

    [RelayCommand]
    public async Task Back()
    {
        await Shell.Current.GoToAsync(nameof(Views.AddHabitPage));
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