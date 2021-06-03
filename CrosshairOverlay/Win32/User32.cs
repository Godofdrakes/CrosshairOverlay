using System;
using System.Runtime.InteropServices;

namespace CrosshairOverlay.Win32
{
    public static class User32
    {
	    public const int WS_EX_NOACTIVATE = 0x08000000;
        public const int WS_EX_TOOLWINDOW = 0x00000080;
        public const int WS_EX_TRANSPARENT = 0x00000020;
        public const int GWL_EXSTYLE = -20;

        [DllImport( "user32.dll" )]
        public static extern int GetWindowLong( IntPtr hwnd, int index );

        [DllImport( "user32.dll" )]
        public static extern int SetWindowLong( IntPtr hwnd, int index, int newStyle );
    }
}
