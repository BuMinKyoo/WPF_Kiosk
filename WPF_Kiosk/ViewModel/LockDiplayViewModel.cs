using CommunityToolkit.Mvvm.Messaging;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WPF_Kiosk.ViewModel
{
    public class LockDiplayViewModel : INotifyPropertyChanged
    {
        public LockDiplayViewModel()
        {
            WeakReferenceMessenger.Default.Register<CustomMessage>(this, ReceiveMessage);
        }

        private void ReceiveMessage(object recipient, CustomMessage message)
        {
            if (message.EventName == "LockDiplayViewModel-BlLockVis")
            {
                BlLockVis = (bool)message.Message;
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
            WeakReferenceMessenger.Default.Send(new CustomMessage("MainDisplayViewModel-BlMainDisplayVis", true));
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
            WeakReferenceMessenger.Default.Send(new CustomMessage("MainDisplayViewModel-BlMainDisplayVis", true));
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
