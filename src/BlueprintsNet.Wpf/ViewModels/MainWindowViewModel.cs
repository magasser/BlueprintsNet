using System.Windows;
using Microsoft.Extensions.Options;
using ControlzEx.Theming;
using BlueprintsNet.Wpf.Options;

namespace BlueprintsNet.Wpf.ViewModels;

public class MainWindowViewModel : BindableBase
{
    public MainWindowViewModel()
    {
        LoadedCommand = new DelegateCommand(OnLoaded);
    }

    public ICommand LoadedCommand { get; }

    private void OnLoaded() { }
}