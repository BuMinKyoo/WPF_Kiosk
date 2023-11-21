using System.Collections.ObjectModel;
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
        private int _goodsDiscount;
        public int GoodsDiscount
        {
            get { return _goodsDiscount; }
            set
            {
                if (_goodsDiscount != value)
                {
                    _goodsDiscount = value;
                    Notify("GoodsDiscount");
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

        private int _goodsCategoryNum;
        public int GoodsCategoryNum
        {
            get { return _goodsCategoryNum; }
            set
            {
                if (_goodsCategoryNum != value)
                {
                    _goodsCategoryNum = value;
                    Notify("GoodsCategoryNum");
                }
            }
        }

        private ObservableCollection<GoodsDetailCategory> _goodsDetailCategorys = new ObservableCollection<GoodsDetailCategory>();
        public ObservableCollection<GoodsDetailCategory> GoodsDetailCategorys
        {
            get { return _goodsDetailCategorys; }
            set
            {
                if (_goodsDetailCategorys != value)
                {
                    _goodsDetailCategorys = value;
                    Notify("GoodsDetailCategorys");
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
