using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Simulantara.Services;

namespace Simulantara.ViewsModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly GameService _gameService;

    public MainViewModel(GameService gameService)
    {
        _gameService = gameService;
    }

    public int Level => _gameService.CurrentUser.Level;
    public int Exp => _gameService.CurrentUser.Exp;
    public int MaxExp => _gameService.CurrentUser.MaxExp;

    public event PropertyChangedEventHandler? PropertyChanged;
        
    void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}