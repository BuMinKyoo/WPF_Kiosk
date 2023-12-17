using System;
using System.Globalization;
using System.Windows.Data;
using WPF_Kiosk.ViewModel;


namespace WPF_Kiosk.Converter.GirdSizeConverter
{
    public class MainGoodsHDivideConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double doubleValue)
            {
                return doubleValue / StaticValue.Stc_InMainGoodsHCnt;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
