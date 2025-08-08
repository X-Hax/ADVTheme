using Avalonia.Data.Converters;
using System.Globalization;

namespace ADVTheme.Converters
{
	/// <summary>
	/// Compares the first two values in the list and returns false if they do not match.
	/// </summary>
	public class MultiDoubleComparer : IMultiValueConverter
	{
		public object? Convert(IList<object?> value, Type targetType, object? parameter, CultureInfo culture)
		{
			bool check = true;
			
			for (int i = 0; i < value.Count-1; i++)
			{
				if ((double)value[i+1] != (double)value[0])
				{
					check = false; break;
				}
			}

			return check;
		}
	}
}
