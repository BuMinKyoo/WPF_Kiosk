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
        private int _detailCategoryNum;
        public int DetailCategoryNum
        {
            get { return _detailCategoryNum; }
            set
            {
                if (_detailCategoryNum != value)
                {
                    _detailCategoryNum = value;
                    Notify("DetailCategoryNum");
                }
            }
        }

        private string _detailCategoryName;
        public string DetailCategoryName
        {
            get { return _detailCategoryName; }
            set
            {
                if (_detailCategoryName != value)
                {
                    _detailCategoryName = value;
                    Notify("DetailCategoryName");
                }
            }
        }

        private bool _detailCategoryDisplay = false;
        public bool DetailCategoryDisplay
        {
            get { return _detailCategoryDisplay; }
            set
            {
                if (_detailCategoryDisplay != value)
                {
                    _detailCategoryDisplay = value;
                    Notify("DetailCategoryDisplay");
                }
            }
        }

        private int _goodsDetailItemCurrentIndex = 0;
        public int GoodsDetailItemCurrentIndex
        {
            get { return _goodsDetailItemCurrentIndex; }
            set
            {
                _goodsDetailItemCurrentIndex = value;
                Notify("GoodsDetailItemCurrentIndex");
            }
        }

        private ObservableCollection<GoodsDetail> _goodsDetails = new ObservableCollection<GoodsDetail>();
        public ObservableCollection<GoodsDetail> GoodsDetails
        {
            get { return _goodsDetails; }
            set
            {
                if (_goodsDetails != value)
                {
                    _goodsDetails = value;
                    Notify("GoodsDetails");
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
