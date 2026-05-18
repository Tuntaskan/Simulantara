using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Simulantara.Models;
using Simulantara.Services;
using System.Collections.ObjectModel;

namespace Simulantara.ViewModels;

public partial class ManageCategoryViewModel : BaseViewModel
{
    private readonly DatabaseService _database;

    [ObservableProperty]
    private string categoryName = "";

    public ObservableCollection<Category> Categories { get; set; }
    = new();

    public ManageCategoryViewModel(
        DatabaseService database)
    {
        _database = database;
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
}