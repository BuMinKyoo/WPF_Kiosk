using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_Kiosk.Model
{
    public class GoodsConfirmQuickBtn : INotifyPropertyChanged
    {
        private int _inGoodsConfirmQuickBtnNum;
        public int InGoodsConfirmQuickBtnNum
        {
            get { return _inGoodsConfirmQuickBtnNum; }
            set
            {
                if (_inGoodsConfirmQuickBtnNum != value)
                {
                    _inGoodsConfirmQuickBtnNum = value;
                    Notify("InGoodsConfirmQuickBtnNum");
                }
            }
        }

        private bool _blGoodsConfirmQuickBtnChecked;
        public bool BlGoodsConfirmQuickBtnChecked
        {
            get { return _blGoodsConfirmQuickBtnChecked; }
            set
            {
                if (_blGoodsConfirmQuickBtnChecked != value)
                {
                    _blGoodsConfirmQuickBtnChecked = value;
                    Notify("BlGoodsConfirmQuickBtnChecked");
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
