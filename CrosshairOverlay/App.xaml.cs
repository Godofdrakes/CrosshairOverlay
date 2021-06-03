using System;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using Settings = CrosshairOverlay.Properties.Crosshair;

namespace CrosshairOverlay
{
	/// <summary>
	///     Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private CrosshairWindow _crosshairWindow;
		private SettingsWindow _settingsWindow;

		public static string DefaultCrosshairDir => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Crosshairs");
		public static Uri DefaultCrosshairUri => new(Path.Combine(DefaultCrosshairDir, "Basic 1.png"));

		private void App_OnStartup(object sender, StartupEventArgs e)
		{
			if (Settings.Default.ImageUri == null)
			{
				Settings.Default.ImageUri = DefaultCrosshairUri;
			}

			_settingsWindow = new SettingsWindow();
			_crosshairWindow = new CrosshairWindow();

			MainWindow = _settingsWindow; // #TODO: Better handling of application shutdown

			_settingsWindow.Show();
			_crosshairWindow.Show();
		}

		private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			var message = $"{e.Exception.Message}\n\nIt would be great if you could report this to me so I can fix it. The application will now close.";
			MessageBox.Show(message, e.Exception.GetType().Name, MessageBoxButton.OK, MessageBoxImage.Error);
			e.Handled = false;
		}
	}
}