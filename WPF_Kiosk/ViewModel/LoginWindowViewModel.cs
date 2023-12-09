using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WPF_Kiosk.View;

namespace WPF_Kiosk.ViewModel
{
    public class LoginWindowViewModel : INotifyPropertyChanged
    {
        public LoginWindowViewModel()
        {
            DblLoginPageWinW = SystemParameters.PrimaryScreenWidth * 0.7;
            DblLoginPageWinH = SystemParameters.PrimaryScreenHeight * 0.3;
        }

        private double _dblLoginPageWinW;
        public double DblLoginPageWinW
        {
            get { return _dblLoginPageWinW; }
            set
            {
                _dblLoginPageWinW = value;
                Notify();
            }
        }

        private double _dblLoginPageWinH;
        public double DblLoginPageWinH
        {
            get { return _dblLoginPageWinH; }
            set
            {
                _dblLoginPageWinH = value;
                Notify();
            }
        }

        private Command _icmdLoginPageGoLock;
        public ICommand IcmdLoginPageGoLock
        {
            get { return _icmdLoginPageGoLock = new Command(OnIcmdLoginPageGoLock); }
        }

        private async void OnIcmdLoginPageGoLock(object obj)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }

        private bool _blLoginPageVis = true;
        public bool BlLoginPageVis
        {
            get { return _blLoginPageVis; }
            set
            {
                _blLoginPageVis = value;
                Notify();
            }
        }

        // 펼칠 필요 X
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
