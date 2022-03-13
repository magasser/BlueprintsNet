using BlueprintsNet.Wpf.Options;
using BlueprintsNet.Wpf.Views;
using ControlzEx.Theming;
using MahApps.Metro.Theming;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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
    private string? _themeValue;

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
            .AddLibraryTheme(
            new LibraryTheme(
                new Uri("pack://application:,,,/BlueprintsNet.Wpf;component/Styles/Themes/Dark.Default.xaml"),
                MahAppsLibraryThemeProvider.DefaultInstance));
        ThemeManager.Current
            .AddLibraryTheme(
            new LibraryTheme(
                new Uri("pack://application:,,,/BlueprintsNet.Wpf;component/Styles/Themes/Light.Default.xaml"),
                MahAppsLibraryThemeProvider.DefaultInstance));

        var themeOptions = Container.Resolve<IOptions<ThemeOptions>>()
                               .Value;

        ThemeManager.Current
            .ChangeTheme(this, themeOptions.Value);
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterInstance<IConfiguration>(
            new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build());

        containerRegistry.RegisterServices(
            services => services.Configure<ThemeOptions>(
                Container.Resolve<IConfiguration>()
                    .GetSection(ThemeOptions.Key)));
    }
}
