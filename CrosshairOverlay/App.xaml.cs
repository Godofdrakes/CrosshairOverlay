using System.Windows;
using System.Windows.Threading;

namespace CrosshairOverlay
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private CrosshairWindow _crosshairWindow;
        private SettingsWindow _settingsWindow;

        private void App_OnStartup( object sender, StartupEventArgs e )
        {
            _settingsWindow = new SettingsWindow();
            _crosshairWindow = new CrosshairWindow();

            MainWindow = _settingsWindow; // #TODO: Better handling of application shutdown

            _settingsWindow.Show();
            _crosshairWindow.Show();
        }

        private void App_OnDispatcherUnhandledException( object sender, DispatcherUnhandledExceptionEventArgs e )
        {
            MessageBox.Show( e.Exception.Message, e.Exception.GetType().Name, MessageBoxButton.OK, MessageBoxImage.Error );
            e.Handled = false;
        }
    }
}
