using BlueprintsNet.Core.Services;

namespace BlueprintsNet.Wpf.ViewModels;

public class MainWindowViewModel : BindableBase
{
    public MainWindowViewModel(IProjectService service)
    {
        LoadedCommand = new DelegateCommand(OnLoaded);
    }

    public ICommand LoadedCommand { get; }

    private void OnLoaded() { }
}