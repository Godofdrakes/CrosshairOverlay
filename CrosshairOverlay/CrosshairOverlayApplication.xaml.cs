using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;
using Settings = CrosshairOverlay.Properties.Crosshair;
using NotifyIcon = System.Windows.Forms.NotifyIcon;

namespace CrosshairOverlay
{
	/// <summary>
	///     Interaction logic for App.xaml
	/// </summary>
	public partial class CrosshairOverlayApplication : Application
	{
		public new static CrosshairOverlayApplication Current => Application.Current as CrosshairOverlayApplication ?? throw new InvalidOperationException();

		private CrosshairWindow? _crosshairWindow;
		private NotifyIcon? _notifyIcon;

		public static string DefaultCrosshairDir => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Crosshairs");
		public static string DefaultCrosshair => Path.Combine(DefaultCrosshairDir, "Basic 1.png");

		private void App_OnStartup(object sender, StartupEventArgs e)
		{
			if (string.IsNullOrEmpty(Settings.Default.FilePath))
			{
				Settings.Default.FilePath = DefaultCrosshair;
			}

			_notifyIcon = new NotifyIcon()
			{
				Icon = Icon.ExtractAssociatedIcon(ResourceAssembly.ManifestModule.Name),
				Visible = true
			};

			_notifyIcon.DoubleClick += (o, args) => SettingsWindow.OpenWindow();
			
			_notifyIcon.ContextMenu = new ContextMenu();
			_notifyIcon.ContextMenu.MenuItems.Add("Settings", (o, args) => SettingsWindow.OpenWindow());
			_notifyIcon.ContextMenu.MenuItems.Add("Exit", (o, args) =>
			{
				_notifyIcon.Visible = false;
				Current.Shutdown();
			});
			
			if (!File.Exists(Settings.Default.FilePath))
			{
				var title = "Failed to Load Crosshair";
				var text = $"The previously selected image could not be found. Verify the file exists or select a different one.";
				_notifyIcon.ShowBalloonTip(3000, title, text, ToolTipIcon.Error);
			}
			
			MainWindow = CrosshairWindow.OpenWindow();
		}
		
		private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			var message = $"{e.Exception.Message}\n\nThe application will now close.";
			MessageBox.Show(message, e.Exception.GetType().Name, MessageBoxButton.OK, MessageBoxImage.Error);
			e.Handled = false;
		}
	}
}