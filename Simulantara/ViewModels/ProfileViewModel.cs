using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Simulantara.Models;
using Simulantara.Services;
using Microsoft.Maui.Storage;

namespace Simulantara.ViewModels;

public partial class ProfileViewModel : BaseViewModel
{
    private readonly UserService _userService;

    [ObservableProperty]
    private User? user;

    public ProfileViewModel(UserService userService)
    {
        _userService = userService;
    }

    [RelayCommand]
    public async Task LoadProfile()
    {
        User = await _userService.GetUserAsync();
    }

    [RelayCommand]
    public async Task SaveProfile()
    {
        if (User == null)
            return;

        await _userService.SaveUserAsync(User);

        await Shell.Current.GoToAsync("//DashboardPage");
    }

    [RelayCommand]
    public async Task Back()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    public async Task PickPhoto()
    {
        if (User == null)
            return;

        try
        {
            var result = await MediaPicker.PickPhotoAsync();

            if (result == null)
                return;

            // nama file unik
            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(result.FileName)}";

            // lokasi simpan local app
            string localPath = Path.Combine(FileSystem.AppDataDirectory, fileName);

            // copy file ke local app storage
            using Stream sourceStream = await result.OpenReadAsync();
            using FileStream localFileStream = File.OpenWrite(localPath);

            await sourceStream.CopyToAsync(localFileStream);

            // simpan path
            User.ProfileImage = localPath;

            OnPropertyChanged(nameof(User));
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert(
                "Error",
                ex.Message,
                "OK");
        }
    }
}