using Avalonia.Data.Converters;
using System.Globalization;

namespace ADVTheme.Converters
{
	/// <summary>
	/// Convert Opacity Value to Bool.
	/// 
	/// If Opacity <= 0, return false.
	/// If Opacity >= 1, return true.
	/// </summary>
	public class OpacityBoolConverter : IValueConverter
	{
		public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			return ((double?)value <= 0) ? false : true;
		}

		public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			return ((double?)value > 0.001) ? true : false;
		}
	}
}
