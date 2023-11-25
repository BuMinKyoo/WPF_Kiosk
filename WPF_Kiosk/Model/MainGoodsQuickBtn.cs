using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_Kiosk.Model
{
    public class MainGoodsQuickBtn : INotifyPropertyChanged
    {
        private int _inMainGoodsQuickBtnNum;
        public int InMainGoodsQuickBtnNum
        {
            get { return _inMainGoodsQuickBtnNum; }
            set
            {
                if (_inMainGoodsQuickBtnNum != value)
                {
                    _inMainGoodsQuickBtnNum = value;
                    Notify("InMainGoodsQuickBtnNum");
                }
            }
        }

        private bool _blMainGoodsQuickBtnChecked;
        public bool BlMainGoodsQuickBtnChecked
        {
            get { return _blMainGoodsQuickBtnChecked; }
            set
            {
                if (_blMainGoodsQuickBtnChecked != value)
                {
                    _blMainGoodsQuickBtnChecked = value;
                    Notify("BlMainGoodsQuickBtnChecked");
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
