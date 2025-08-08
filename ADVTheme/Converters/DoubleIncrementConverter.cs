using Avalonia.Data.Converters;
using System.Globalization;

namespace ADVTheme.Converters
{
	/// <summary>
	/// Increments a supplied double using the <see cref="ModifierType"/> provided and a value to increment by.
	/// 
	/// Default modifier method is Addition.
	/// </summary>
	public class DoubleIncrementConverter : IValueConverter
	{
		public enum ModifierType
		{
			Add,
			Subtract,
			Multiply,
			Divide,
		}

		public double ModifierValue { get; set; } = 0;

		public ModifierType ModifierMethod { get; set; } = ModifierType.Add;

		public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			if (value is null)
				return ModifierValue;

			switch (ModifierMethod)
			{
				case ModifierType.Add:
				default:
					return ((double)value) + ModifierValue;
				case ModifierType.Subtract:
					return ((double)value) - ModifierValue;
				case ModifierType.Multiply:
					return ((double)value) * ModifierValue;
				case ModifierType.Divide:
					return ((double)value) / ModifierValue;
			}
		}

		public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
