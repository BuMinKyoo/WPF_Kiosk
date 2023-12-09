using System;
using System.Globalization;
using System.Windows.Data;
using WPF_Kiosk.ViewModel;


namespace WPF_Kiosk.Converter.GirdSizeConverter
{
    public class DetailGoodsWDivideConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double doubleValue)
            {
                return doubleValue / MainWindowViewModel.Stc_InDetailGoodsWCnt;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
