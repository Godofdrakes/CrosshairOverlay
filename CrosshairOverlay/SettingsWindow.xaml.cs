using System;
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
			Settings.Default.ImageUri = App.DefaultCrosshairUri;
		}

		private void CloseSettings(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void BrowseForImage(object sender, RoutedEventArgs e)
		{
			var dialog = new OpenFileDialog
			{
				Multiselect = false,
				Filter = "Portable Network Graphics (*.png)|*.png",
				InitialDirectory = Path.GetDirectoryName(Settings.Default.ImageUri.LocalPath),
			};
			
			dialog.CustomPlaces.Add(new FileDialogCustomPlace(App.DefaultCrosshairDir));

			if (dialog.ShowDialog() == true)
			{
				Properties.Crosshair.Default.ImageUri = new Uri(dialog.FileName);
			}
		}
	}
}
