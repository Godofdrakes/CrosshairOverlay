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

        private void Slider_MouseWheel( object sender, System.Windows.Input.MouseWheelEventArgs e )
        {
            Slider slider = sender as Slider;
            if( e.Delta > 0 )
            {
                slider.Value += slider.TickFrequency;
            }
            else
            {
                slider.Value -= slider.TickFrequency;
            }
            slider.Value = Math.Round( slider.Value, 1 );
        }

        private void SaveButton( object sender, RoutedEventArgs e )
        {

        }

        private void DefaultsButton( object sender, RoutedEventArgs e )
        {

        }
    }
}
