using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace WPF_Kiosk.ViewModel
{
    public class LockDiplayViewModel : INotifyPropertyChanged
    {
        public LockDiplayViewModel()
        {
            // 윈도우 화면을 가져와서 비율에 따라 크기를 조절
            DblLockWinW = SystemParameters.PrimaryScreenWidth;
            DblLockWinH = SystemParameters.PrimaryScreenHeight;
        }

        private double _dblLockWinW;
        public double DblLockWinW
        {
            get { return _dblLockWinW; }
            set
            {
                _dblLockWinW = value;
                Notify();
            }
        }

        private double _dblLockWinH;
        public double DblLockWinH
        {
            get { return _dblLockWinH; }
            set
            {
                _dblLockWinH = value;
                Notify();
            }
        }

        private Command _icmdLockMouseLeftUp;
        public ICommand IcmdLockMouseLeftUp
        {
            get { return _icmdLockMouseLeftUp = new Command(OnIcmdLockMouseLeftUp); }
        }

        // KioskLock화면에 마우스 업 클릭시 작동
        private void OnIcmdLockMouseLeftUp(object obj)
        {
            BlLockVis = false;
            //BlMainDisplayVis = true;

            // 초기에 보여지는 데이터들
            //SetMainGoodsMainCategory();
        }

        // OnIcmdKioskLockMouseLeftUp과 같은 기능이지만, 버튼으로 command연결
        private Command _icmdLockBtnClick;
        public ICommand IcmdLockBtnClick
        {
            get { return _icmdLockBtnClick = new Command(OnIcmdLockBtnClick); }
        }

        private void OnIcmdLockBtnClick(object obj)
        {
            BlLockVis = false;
            //BlMainDisplayVis = true;

            // 초기에 보여지는 데이터들
            //SetMainGoodsMainCategory();
        }

        private bool _blLockVis = true;
        public bool BlLockVis
        {
            get { return _blLockVis; }
            set
            {
                _blLockVis = value;
                Notify();
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
