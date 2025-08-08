using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using System.Globalization;

namespace ADVTheme.Converters
{
	/// <summary>
	/// Takes a bool and will return a specific value depending on if the value is true or false.
	/// </summary>
	public class BoolValueConverter : IValueConverter
	{
		public enum ValueTypes
		{
			Double,
			Integer,
			Float
		}

		public ValueTypes ValueType { get; set; } = ValueTypes.Double;

		public object? TrueValue { get; set; }

		public object? FalseValue { get; set; }

		public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			bool v = (bool)value;
			if (v)
			{
				switch (ValueType)
				{
					case ValueTypes.Double:
					default:
						return (double)TrueValue;
					case ValueTypes.Integer:
						return (int)TrueValue;
					case ValueTypes.Float:
						return (float)TrueValue;
				}
			}
			else
			{
				switch (ValueType)
				{
					case ValueTypes.Double:
					default:
						return (double)FalseValue;
					case ValueTypes.Integer:
						return (int)FalseValue;
					case ValueTypes.Float:
						return (float)FalseValue;
				}
			}
		}

		public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
