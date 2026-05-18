using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Simulantara.Models;
using Simulantara.Services;
using Simulantara.Views;
using Microsoft.Maui.Storage;

namespace Simulantara.ViewModels;

public partial class InputProfileViewModel : BaseViewModel
{
    private readonly UserService _userService;

    [ObservableProperty]
    private string username = "";

    [ObservableProperty]
    private Gender selectedGender;

    [ObservableProperty]
    private string? profileImage;

    public List<Gender> Genders =>
        Enum.GetValues(typeof(Gender))
            .Cast<Gender>()
            .ToList();

    public InputProfileViewModel(UserService userService)
    {
        _userService = userService;
    }

    [RelayCommand]
    public async Task SaveProfile()
    {
        if (string.IsNullOrWhiteSpace(Username))
            return;

        var user = new User
        {
            Username = Username,
            Gender = SelectedGender,
            ProfileImage = ProfileImage,
            Level = 1,
            Exp = 0,
            CurrentNpcId = 1,
            CurrentBackgroundId = 1
        };

        await _userService.SaveUserAsync(user);

        Application.Current!.MainPage = new AppShell();
    }

    [RelayCommand]
    public async Task PickPhoto()
    {
        try
        {
            var result = await MediaPicker.PickPhotoAsync();

            if (result == null)
                return;

            // nama file unik
            string fileName =
                $"{Guid.NewGuid()}{Path.GetExtension(result.FileName)}";

            // lokasi local storage
            string localPath = Path.Combine(
                FileSystem.AppDataDirectory,
                fileName);

            // copy file
            using Stream sourceStream =
                await result.OpenReadAsync();

            using FileStream localFileStream =
                File.OpenWrite(localPath);

            await sourceStream.CopyToAsync(localFileStream);

            // simpan path
            ProfileImage = localPath;
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