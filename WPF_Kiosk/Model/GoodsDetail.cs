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
