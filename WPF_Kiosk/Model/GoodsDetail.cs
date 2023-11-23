using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_Kiosk.Model
{
    public class GoodsDetail : INotifyPropertyChanged
    {
        private string _goodsDtailName;
        public string GoodsDtailName
        {
            get { return _goodsDtailName; }
            set
            {
                if (_goodsDtailName != value)
                {
                    _goodsDtailName = value;
                    Notify("GoodsDtailName");
                }
            }
        }
        private int _goodsDtailDiscount;
        public int GoodsDtailDiscount
        {
            get { return _goodsDtailDiscount; }
            set
            {
                if (_goodsDtailDiscount != value)
                {
                    _goodsDtailDiscount = value;
                    Notify("GoodsDtailDiscount");
                }
            }
        }

        private int _goodsDtailPrice;
        public int GoodsDtailPrice
        {
            get { return _goodsDtailPrice; }
            set
            {
                if (_goodsDtailPrice != value)
                {
                    _goodsDtailPrice = value;
                    Notify("GoodsDtailPrice");
                }
            }
        }

        private int _goodsDtailNum;
        public int GoodsDtailNum
        {
            get { return _goodsDtailNum; }
            set
            {
                if (_goodsDtailNum != value)
                {
                    _goodsDtailNum = value;
                    Notify("GoodsDtailNum");
                }
            }
        }


        private int _goodsDtailCategoryNum;
        public int GoodsDtailCategoryNum
        {
            get { return _goodsDtailCategoryNum; }
            set
            {
                if (_goodsDtailCategoryNum != value)
                {
                    _goodsDtailCategoryNum = value;
                    Notify("GoodsDtailCategoryNum");
                }
            }
        }

        private bool _goodsDetailDisplay = false;
        public bool GoodsDetailDisplay
        {
            get { return _goodsDetailDisplay; }
            set
            {
                if (_goodsDetailDisplay != value)
                {
                    _goodsDetailDisplay = value;
                    Notify("GoodsDetailDisplay");
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
