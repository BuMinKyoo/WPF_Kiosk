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
        public DetailCategory()
        {

        }

        public DetailCategory(DetailCategory other)
        {
            InDetailCategoryNum = other.InDetailCategoryNum;
            StrDetailCategoryName = other.StrDetailCategoryName;
            BlDetailCategoryVis = other.BlDetailCategoryVis;
            InDetailGoodsCurrentIndex = other.InDetailGoodsCurrentIndex;
            ObcDetailGoodsList = new ObservableCollection<DetailGoods>(other.ObcDetailGoodsList.Select(item => new DetailGoods(item)));
        }

        private int _inDetailCategoryNum;
        public int InDetailCategoryNum
        {
            get { return _inDetailCategoryNum; }
            set
            {
                if (_inDetailCategoryNum != value)
                {
                    _inDetailCategoryNum = value;
                    Notify();
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
                    Notify();
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
                    Notify();
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
                Notify();
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
                    Notify();
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
