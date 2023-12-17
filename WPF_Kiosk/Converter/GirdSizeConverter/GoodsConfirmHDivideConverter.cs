using System;
using System.Globalization;
using System.Windows.Data;
using WPF_Kiosk.ViewModel;


namespace WPF_Kiosk.Converter.GirdSizeConverter
{
    public class GoodsConfirmHDivideConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double doubleValue)
            {
                return doubleValue / StaticValue.Stc_InGoodsConfirmHCnt;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
