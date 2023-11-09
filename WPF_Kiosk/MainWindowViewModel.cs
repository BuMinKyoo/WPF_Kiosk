using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace WPF_Kiosk
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            WindowWidth = SystemParameters.PrimaryScreenWidth;
            WindowHight = SystemParameters.PrimaryScreenHeight;
        }

        #region KioskLock
        private double _windowWidth;
        public double WindowWidth
        {
            get { return _windowWidth; }
            set
            {
                _windowWidth = value;
                Notify("WindowWidth");
            }
        }

        private double _windowHight;
        public double WindowHight
        {
            get { return _windowHight; }
            set
            {
                _windowHight = value;
                Notify("WindowHight");
            }
        }

        private Command _KioskLockMouseUp;
        public ICommand KioskLockMouseUp
        {
            get { return _KioskLockMouseUp = new Command(OnKioskLockMouseUp); }
        }

        private bool _kioskLockVisibility = true;
        public bool KioskLockVisibility
        {
            get { return _kioskLockVisibility; }
            set
            {
                _kioskLockVisibility = value;
                Notify("KioskLockVisibility");
            }
        }

        private void OnKioskLockMouseUp(object obj)
        {
            KioskLockVisibility = false;
        }

        private Command _kioskLockBtnClick;
        public ICommand KioskLockBtnClick
        {
            get { return _kioskLockBtnClick = new Command(OnKioskLockBtnClick); }
        }

        private void OnKioskLockBtnClick(object obj)
        {
            KioskLockVisibility = false;
        }

        #endregion

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
