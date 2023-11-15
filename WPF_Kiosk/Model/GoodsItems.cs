using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_Kiosk.Model
{
    public class GoodsItems : INotifyPropertyChanged
    {
        private string _goodsName;
        public string GoodsName
        {
            get { return _goodsName; }
            set
            {
                if (_goodsName != value)
                {
                    _goodsName = value;
                    Notify("GoodsName");
                }
            }
        }
        private string _discount;
        public string Discount
        {
            get { return _discount; }
            set
            {
                if (_discount != value)
                {
                    _discount = value;
                    Notify("Discount");
                }
            }
        }

        private int _goodsPrice;
        public int GoodsPrice
        {
            get { return _goodsPrice; }
            set
            {
                if (_goodsPrice != value)
                {
                    _goodsPrice = value;
                    Notify("GoodsPrice");
                }
            }
        }

        private bool _goodsDisplay = false;
        public bool GoodsDisplay
        {
            get { return _goodsDisplay; }
            set
            {
                if (_goodsDisplay != value)
                {
                    _goodsDisplay = value;
                    Notify("GoodsDisplay");
                }
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void Notify([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
