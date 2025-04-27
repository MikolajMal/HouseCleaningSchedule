using System;
using System.Globalization;
using System.Windows.Data;

namespace HouseCleaningSchedule.Converters
{
	public class StringToIntConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is int intValue) return intValue.ToString();
			return string.Empty;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string? strValue = value as string;
			if(string.IsNullOrEmpty(strValue)) return 0;
			if(int.TryParse(strValue, out int intValue)) return intValue;
			return 0;
		}
	}
}
