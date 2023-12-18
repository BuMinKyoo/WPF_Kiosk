using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace WPF_Kiosk.ViewModel
{
    public class LoginWindowViewModel : INotifyPropertyChanged
    {
        private double _dblLoginWindowStartX;
        private double _dblLoginWindowStartY;
        private double _dblLoginPageWinW;
        private double _dblLoginPageWinH;
        private Command _icmdLoginPageGoLock;
        private bool _blLoginPageVis = true;

        public LoginWindowViewModel()
        {
            // LoginWindow를 비율에 따라 크기를 조절
            _dblLoginPageWinW = SystemParameters.PrimaryScreenWidth * StaticValue.Stc_DblLoginWindowRatioW;
            _dblLoginPageWinH = SystemParameters.PrimaryScreenHeight * StaticValue.Stc_DblLoginWindowRatioH;
        }

        #region properties
        public double DblLoginPageWinW
        {
            get { return _dblLoginPageWinW; }
            set
            {
                _dblLoginPageWinW = value;
                Notify();
            }
        }

        public double DblLoginPageWinH
        {
            get { return _dblLoginPageWinH; }
            set
            {
                _dblLoginPageWinH = value;
                Notify();
            }
        }

        public bool BlLoginPageVis
        {
            get { return _blLoginPageVis; }
            set
            {
                _blLoginPageVis = value;
                Notify();
            }
        }
        #endregion

        #region ICommand
        public ICommand IcmdLoginPageGoLock
        {
            get { return _icmdLoginPageGoLock = new Command(OnIcmdLoginPageGoLock); }
        }

        private void OnIcmdLoginPageGoLock(object obj)
        {
            if (obj is DependencyObject dependencyObject)
            {
                Window parentWindow = Window.GetWindow(dependencyObject);
                if (parentWindow != null)
                {
                    // parentWindow를 사용하여 윈도우 작업 수행
                    parentWindow.Close(); // 예: 윈도우 닫기
                }
            }
        }
        #endregion

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
