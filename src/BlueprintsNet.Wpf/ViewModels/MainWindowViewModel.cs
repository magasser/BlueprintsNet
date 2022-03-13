using BlueprintsNet.Wpf.Options;
using ControlzEx.Theming;
using Microsoft.Extensions.Options;
using System.Windows;

namespace BlueprintsNet.Wpf.ViewModels;

public class MainWindowViewModel : BindableBase
{
    private readonly ThemeOptions _themeOptions;

    public MainWindowViewModel(IOptions<ThemeOptions> options)
    {
        _themeOptions = options.MustNotBeNull()
                            .Value
                            .MustNotBeNull();

        LoadedCommand = new DelegateCommand(OnLoaded);
    }

    public ICommand LoadedCommand { get; }

    private void OnLoaded() { }
}