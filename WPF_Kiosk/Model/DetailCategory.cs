using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Kiosk.Model
{
    public class DetailCategory : INotifyPropertyChanged
    {
        private int _inDetailCategoryNum;
        public int InDetailCategoryNum
        {
            get { return _inDetailCategoryNum; }
            set
            {
                if (_inDetailCategoryNum != value)
                {
                    _inDetailCategoryNum = value;
                    Notify("InDetailCategoryNum");
                }
            }
        }

        private string _strDetailCategoryName;
        public string StrDetailCategoryName
        {
            get { return _strDetailCategoryName; }
            set
            {
                if (_strDetailCategoryName != value)
                {
                    _strDetailCategoryName = value;
                    Notify("StrDetailCategoryName");
                }
            }
        }

        private bool _blDetailCategoryVis = false;
        public bool BlDetailCategoryVis
        {
            get { return _blDetailCategoryVis; }
            set
            {
                if (_blDetailCategoryVis != value)
                {
                    _blDetailCategoryVis = value;
                    Notify("BlDetailCategoryVis");
                }
            }
        }

        private int _inDetailGoodsCurrentIndex = 0;
        public int InDetailGoodsCurrentIndex
        {
            get { return _inDetailGoodsCurrentIndex; }
            set
            {
                _inDetailGoodsCurrentIndex = value;
                Notify("InDetailGoodsCurrentIndex");
            }
        }

        private ObservableCollection<DetailGoods> _obcDetailGoodsList = new ObservableCollection<DetailGoods>();
        public ObservableCollection<DetailGoods> ObcDetailGoodsList
        {
            get { return _obcDetailGoodsList; }
            set
            {
                if (_obcDetailGoodsList != value)
                {
                    _obcDetailGoodsList = value;
                    Notify("ObcDetailGoodsList");
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
