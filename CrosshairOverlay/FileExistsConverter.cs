using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace CrosshairOverlay
{
	[ValueConversion(typeof(Uri), typeof(bool))]
	[ValueConversion(typeof(string), typeof(bool))]
	public class FileExistsConverter : IValueConverter
	{
		public static FileExistsConverter Instance { get; } = new();

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value switch
			{
				string path => File.Exists(path),
				Uri uri => File.Exists(uri.LocalPath),
				_ => false
			};
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}