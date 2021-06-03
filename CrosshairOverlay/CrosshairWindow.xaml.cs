using System;
using System.Windows;
using System.Windows.Interop;
using CrosshairOverlay.Win32;

namespace CrosshairOverlay
{
    /// <summary>
    ///     Interaction logic for CrosshairOverlay.xaml
    /// </summary>
    public partial class CrosshairWindow : Window
    {
        private readonly WindowInteropHelper _helper;

        public CrosshairWindow()
        {
            InitializeComponent();
            _helper = new WindowInteropHelper( this );
        }

        /// <inheritdoc />
        protected override void OnSourceInitialized( EventArgs e )
        {
            base.OnSourceInitialized( e );

            // Register this window as 'transparent' (click through) with the Win32 api
            var extendedStyle = User32.GetWindowLong( _helper.Handle, User32.GWL_EXSTYLE );

            extendedStyle |= User32.WS_EX_NOACTIVATE;
            extendedStyle |= User32.WS_EX_TOOLWINDOW;
            extendedStyle |= User32.WS_EX_TRANSPARENT;
            
            User32.SetWindowLong( _helper.Handle, User32.GWL_EXSTYLE, extendedStyle );
        }
    }
}
