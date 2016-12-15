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
        private readonly WindowInteropHelper helper;

        public CrosshairWindow()
        {
            InitializeComponent();
            helper = new WindowInteropHelper( this );
        }

        /// <inheritdoc />
        protected override void OnSourceInitialized( EventArgs e )
        {
            base.OnSourceInitialized( e );

            // Register this window as 'transparent' (click through) with the Win32 api
            var extendedStyle = User32.GetWindowLong( helper.Handle, User32.GWL_EXSTYLE );
            User32.SetWindowLong( helper.Handle, User32.GWL_EXSTYLE, extendedStyle | User32.WS_EX_TRANSPARENT );
        }
    }
}
