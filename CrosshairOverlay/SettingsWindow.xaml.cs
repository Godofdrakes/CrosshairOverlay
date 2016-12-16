using System;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace CrosshairOverlay
{
    /// <summary>
    ///     Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow
    {
        public SettingsWindow() { InitializeComponent(); }

        private void SaveSettings( object sender, RoutedEventArgs e )
        {
            Properties.Crosshair.Default.Save();
        }

        private void ResetSettings( object sender, RoutedEventArgs e )
        {
            Properties.Crosshair.Default.Reset();
        }
    }
}
