﻿
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