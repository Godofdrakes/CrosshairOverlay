using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using Settings = CrosshairOverlay.Properties.Crosshair;

namespace CrosshairOverlay
{
	/// <summary>
	///     Interaction logic for SettingsWindow.xaml
	/// </summary>
	public partial class SettingsWindow
	{
		public static void OpenWindow()
		{
			if (_settingsWindow != null)
			{
				_settingsWindow.Activate();
			}
			else
			{
				_settingsWindow = new SettingsWindow();
				_settingsWindow.Closing += (sender, args) => _settingsWindow = null;
				_settingsWindow.Show();
			}
		}

		private static SettingsWindow? _settingsWindow;
		
		public SettingsWindow()
		{
			InitializeComponent();
		}

		private void SaveSettings( object sender, RoutedEventArgs e )
		{
			Settings.Default.Save();
		}

		private void ResetSettings( object sender, RoutedEventArgs e )
		{
			Settings.Default.Reset();
			Settings.Default.FilePath = CrosshairOverlayApplication.DefaultCrosshair;
		}

		private void CloseSettings(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void BrowseForImage(object sender, RoutedEventArgs e)
		{
			var dialog = new OpenFileDialog
			{
				Multiselect = false,
				Filter = "Portable Network Graphics (*.png)|*.png",
				InitialDirectory = Path.GetDirectoryName(Settings.Default.FilePath),
			};
			
			dialog.CustomPlaces.Add(new FileDialogCustomPlace(CrosshairOverlayApplication.DefaultCrosshairDir));

			if (dialog.ShowDialog() == true)
			{
				Properties.Crosshair.Default.FilePath = dialog.FileName;
			}
		}
	}
}
