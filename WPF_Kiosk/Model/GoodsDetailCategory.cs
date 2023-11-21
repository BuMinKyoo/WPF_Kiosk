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
    public class GoodsDetailCategory : INotifyPropertyChanged
    {
        private int _goodsDetailCategoryNum;
        public int GoodsDetailCategoryNum
        {
            get { return _goodsDetailCategoryNum; }
            set
            {
                if (_goodsDetailCategoryNum != value)
                {
                    _goodsDetailCategoryNum = value;
                    Notify("GoodsDetailCategoryNum");
                }
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
