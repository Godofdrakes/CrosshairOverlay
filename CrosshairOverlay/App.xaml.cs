using System.Windows;
using System.Windows.Threading;

namespace CrosshairOverlay
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private CrosshairWindow crosshairWindow;
        private SettingsWindow settingsWindow;

        private void App_OnStartup( object sender, StartupEventArgs e )
        {
            settingsWindow = new SettingsWindow();
            crosshairWindow = new CrosshairWindow();

            MainWindow = settingsWindow; // #TODO: Better handling of application shutdown

            settingsWindow.Show();
            crosshairWindow.Show();
        }

        private void App_OnDispatcherUnhandledException( object sender, DispatcherUnhandledExceptionEventArgs e )
        {
            MessageBox.Show( e.Exception.Message, e.Exception.GetType().Name, MessageBoxButton.OK, MessageBoxImage.Error );
            e.Handled = false;
        }
    }
}
