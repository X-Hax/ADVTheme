using Avalonia.Data.Converters;
using System.Globalization;

namespace ADVTheme.Converters
{
	/// <summary>
	/// Checks if the current platform matches the requested <see cref="OSPlatform"/>.
	/// </summary>
	public class PlatformBoolConverter : IValueConverter
	{
		public enum OSPlatform
		{
			Windows,
			Mac,
			Linux
		}

		public OSPlatform Platform { get; set; } = OSPlatform.Windows;

		public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			switch (Platform)
			{
				case OSPlatform.Windows:
				default:
					return OperatingSystem.IsWindows();
				case OSPlatform.Mac:
					return OperatingSystem.IsMacOS();
				case OSPlatform.Linux:
					return OperatingSystem.IsLinux();
			}
		}

		public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			// This should never be reached.
			throw new NotImplementedException();
		}
	}
}
