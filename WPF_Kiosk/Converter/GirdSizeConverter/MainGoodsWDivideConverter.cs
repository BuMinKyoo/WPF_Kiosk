using System;
using System.Globalization;
using System.Windows.Data;

namespace WPF_Kiosk.Converter.GirdSizeConverter
{
    public class MainGoodsWDivideConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double doubleValue)
            {
                return doubleValue / MainWindowViewModel.Stc_InMainGoodsWCnt;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
