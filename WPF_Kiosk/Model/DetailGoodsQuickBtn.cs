using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_Kiosk.Model
{
    public class DetailGoodsQuickBtn : INotifyPropertyChanged
    {
        private int _inDetailGoodsQuickBtnNum;
        public int InDetailGoodsQuickBtnNum
        {
            get { return _inDetailGoodsQuickBtnNum; }
            set
            {
                if (_inDetailGoodsQuickBtnNum != value)
                {
                    _inDetailGoodsQuickBtnNum = value;
                    Notify();
                }
            }
        }

        private bool _blDetailGoodsQuickBtnChecked;
        public bool BlDetailGoodsQuickBtnChecked
        {
            get { return _blDetailGoodsQuickBtnChecked; }
            set
            {
                if (_blDetailGoodsQuickBtnChecked != value)
                {
                    _blDetailGoodsQuickBtnChecked = value;
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
