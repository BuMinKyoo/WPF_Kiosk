using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WPF_Kiosk
{
    public class VisibleConverter : IValueConverter
    {
        // ViewModel -> View
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // 입력된 값이 bool 형태인지 확인하고, 그에 따라 Visibility 값을 반환합니다.
            if (value is bool boolValue)
            {
                return boolValue ?  Visibility.Visible : Visibility.Collapsed;
            }

            return 0;
        }

        // View -> ViewModel
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }
}
