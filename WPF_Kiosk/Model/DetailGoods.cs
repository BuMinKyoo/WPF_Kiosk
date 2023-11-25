using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_Kiosk.Model
{
    public class DetailGoods : INotifyPropertyChanged
    {
        private string _strDetailGoodsName;
        public string StrDetailGoodsName
        {
            get { return _strDetailGoodsName; }
            set
            {
                if (_strDetailGoodsName != value)
                {
                    _strDetailGoodsName = value;
                    Notify("StrDetailGoodsName");
                }
            }
        }
        private int _inDetailGoodsDiscount;
        public int InDetailGoodsDiscount
        {
            get { return _inDetailGoodsDiscount; }
            set
            {
                if (_inDetailGoodsDiscount != value)
                {
                    _inDetailGoodsDiscount = value;
                    Notify("InDetailGoodsDiscount");
                }
            }
        }

        private int _inDetailGoodsPrice;
        public int InDetailGoodsPrice
        {
            get { return _inDetailGoodsPrice; }
            set
            {
                if (_inDetailGoodsPrice != value)
                {
                    _inDetailGoodsPrice = value;
                    Notify("InDetailGoodsPrice");
                }
            }
        }

        private int _inDetailGoodsNum;
        public int InDetailGoodsNum
        {
            get { return _inDetailGoodsNum; }
            set
            {
                if (_inDetailGoodsNum != value)
                {
                    _inDetailGoodsNum = value;
                    Notify("InDetailGoodsNum");
                }
            }
        }


        private int _inDetailGoodsDetailCategoryNum;
        public int InDetailGoodsDetailCategoryNum
        {
            get { return _inDetailGoodsDetailCategoryNum; }
            set
            {
                if (_inDetailGoodsDetailCategoryNum != value)
                {
                    _inDetailGoodsDetailCategoryNum = value;
                    Notify("InDetailGoodsDetailCategoryNum");
                }
            }
        }

        private bool _blDetailGoodsVis = false;
        public bool BlDetailGoodsVis
        {
            get { return _blDetailGoodsVis; }
            set
            {
                if (_blDetailGoodsVis != value)
                {
                    _blDetailGoodsVis = value;
                    Notify("BlDetailGoodsVis");
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
