using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WPF_Kiosk.Converter
{
    public class StarGridLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string starValue)
            {
                if (starValue.EndsWith("*"))
                {
                    if (double.TryParse(starValue.TrimEnd('*'), out double starWeight))
                    {
                        return new GridLength(starWeight, GridUnitType.Star);
                    }
                }
            }

            // 기본값으로 1* 반환
            return new GridLength(1, GridUnitType.Star);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
