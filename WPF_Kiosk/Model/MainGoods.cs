using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WPF_Kiosk.Model
{
    public class MainGoods : INotifyPropertyChanged
    {
        public MainGoods()
        {

        }

        public MainGoods(MainGoods other)
        {
            StrMainGoodsName = other.StrMainGoodsName;
            InMainGoodsDiscount = other.InMainGoodsDiscount;
            InMainGoodsPrice = other.InMainGoodsPrice;
            BlMainGoodsVis = other.BlMainGoodsVis;
            InMainGoodsMainCategoryNum = other.InMainGoodsMainCategoryNum;

            ObcDetailCategoryList = new ObservableCollection<DetailCategory>(
        other.ObcDetailCategoryList.Select(item => new DetailCategory(item)));
        }

        private string _strMainGoodsName;
        public string StrMainGoodsName
        {
            get { return _strMainGoodsName; }
            set
            {
                if (_strMainGoodsName != value)
                {
                    _strMainGoodsName = value;
                    Notify("StrMainGoodsName");
                }
            }
        }
        private int _inMainGoodsDiscount;
        public int InMainGoodsDiscount
        {
            get { return _inMainGoodsDiscount; }
            set
            {
                if (_inMainGoodsDiscount != value)
                {
                    _inMainGoodsDiscount = value;
                    Notify("InMainGoodsDiscount");
                }
            }
        }

        private int _inMainGoodsPrice;
        public int InMainGoodsPrice
        {
            get { return _inMainGoodsPrice; }
            set
            {
                if (_inMainGoodsPrice != value)
                {
                    _inMainGoodsPrice = value;
                    Notify("InMainGoodsPrice");
                }
            }
        }

        private bool _blMainGoodsVis = false;
        public bool BlMainGoodsVis
        {
            get { return _blMainGoodsVis; }
            set
            {
                if (_blMainGoodsVis != value)
                {
                    _blMainGoodsVis = value;
                    Notify("BlMainGoodsVis");
                }
            }
        }

        private int _inMainGoodsMainCategoryNum;
        public int InMainGoodsMainCategoryNum
        {
            get { return _inMainGoodsMainCategoryNum; }
            set
            {
                if (_inMainGoodsMainCategoryNum != value)
                {
                    _inMainGoodsMainCategoryNum = value;
                    Notify("InMainGoodsMainCategoryNum");
                }
            }
        }

        private ObservableCollection<DetailCategory> _obcDetailCategoryList = new ObservableCollection<DetailCategory>();
        public ObservableCollection<DetailCategory> ObcDetailCategoryList
        {
            get { return _obcDetailCategoryList; }
            set
            {
                if (_obcDetailCategoryList != value)
                {
                    _obcDetailCategoryList = value;
                    Notify("ObcDetailCategoryList");
                }
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void Notify([CallerMemberName] string? propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
