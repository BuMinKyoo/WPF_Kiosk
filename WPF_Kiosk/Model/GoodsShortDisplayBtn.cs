using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_Kiosk.Model
{
    public class GoodsShortDisplayBtn : INotifyPropertyChanged
    {
        private int _btnNum;
        public int BtnNum
        {
            get { return _btnNum; }
            set
            {
                if (_btnNum != value)
                {
                    _btnNum = value;
                    Notify("BtnNum");
                }
            }
        }

        private bool _btnChecked;
        public bool BtnChecked
        {
            get { return _btnChecked; }
            set
            {
                if (_btnChecked != value)
                {
                    _btnChecked = value;
                    Notify("BtnChecked");
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
