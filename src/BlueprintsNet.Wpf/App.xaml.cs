using BlueprintsNet.Wpf.Views;
using ControlzEx.Theming;
using Microsoft.Extensions.Configuration;
using Prism.Ioc;
using Prism.Regions;
using System.IO;
using System.Windows;

namespace BlueprintsNet.Wpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    protected override Window CreateShell()
    {
        return Container.Resolve<MainWindow>();
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        var regionManager = Container.Resolve<IRegionManager>();

        regionManager.RegisterViewWithRegion<ToolBarView>(PrismRegions.ToolBarRegion);
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        ThemeManager.Current
            .ChangeTheme(this, Themes.Dark);
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterInstance<IConfiguration>(
            new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build());
    }
}
