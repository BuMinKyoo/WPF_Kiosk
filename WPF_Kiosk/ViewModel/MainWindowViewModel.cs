using CommunityToolkit.Mvvm.Messaging;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using WPF_Kiosk.View;

namespace WPF_Kiosk.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private DispatcherTimer DpctAdminManager = new DispatcherTimer();

        public MainWindowViewModel()
        {
            // 윈도우 화면을 가져와서 비율에 따라 크기를 조절
            DblMainWinW = SystemParameters.PrimaryScreenWidth;
            DblMainWinH = SystemParameters.PrimaryScreenHeight;

            // ViewModel담기
            ObjMainDisplayViewModel = App.Current.Services.GetService(typeof(MainDisplayViewModel))!;
            ObjLockDiplayViewModel = App.Current.Services.GetService(typeof(LockDiplayViewModel))!;
            ObjGoodsConfirmDisplayViewModel = App.Current.Services.GetService(typeof(GoodsConfirmDisplayViewModel))!;
            ObjDetailCategoryAndGoodsDisplayViewModel = App.Current.Services.GetService(typeof(DetailCategoryAndGoodsDisplayViewModel))!;
            ObjAdminManagerDisplayViewModel = App.Current.Services.GetService(typeof(AdminManagerDisplayViewModel))!;

            // 관리자 화면으로 이동하기 위한 타이머
            DpctAdminManager.Interval = TimeSpan.FromSeconds(5);
            DpctAdminManager.Tick += DpctAdminManager_Tick;
        }

        // 컴포넌트 들의 모든 사이즈 조절
        #region OnIcmdWindowSizeEvent
        private Command _icmdWindowSizeEvent;
        public ICommand IcmdWindowSizeEvent
        {
            get { return _icmdWindowSizeEvent = new Command(OnIcmdWindowSizeEvent); }
        }

        private void OnIcmdWindowSizeEvent(object obj)
        {
            var arg = obj as SizeChangedEventArgs;
            if (arg == null)
            {
                return;
            }

            // 윈도우 화면을 가져와서 비율에 따라 크기를 조절
            DblMainWinW = arg.NewSize.Width;
            DblMainWinH = arg.NewSize.Height;
        }
        #endregion

        // ViewModel정의
        #region DisplayViewModels
        private object _objMainDisplayViewModel;
        public object ObjMainDisplayViewModel
        {
            get { return _objMainDisplayViewModel; }
            set
            {
                _objMainDisplayViewModel = value;
                Notify();
            }
        }

        private object _objLockDiplayViewModel;
        public object ObjLockDiplayViewModel
        {
            get { return _objLockDiplayViewModel; }
            set
            {
                _objLockDiplayViewModel = value;
                Notify();
            }
        }

        private object _objGoodsConfirmDisplayViewModel;
        public object ObjGoodsConfirmDisplayViewModel
        {
            get { return _objGoodsConfirmDisplayViewModel; }
            set
            {
                _objGoodsConfirmDisplayViewModel = value;
                Notify();
            }
        }

        private object _objDetailCategoryAndGoodsDisplayViewModel;
        public object ObjDetailCategoryAndGoodsDisplayViewModel
        {
            get { return _objDetailCategoryAndGoodsDisplayViewModel; }
            set
            {
                _objDetailCategoryAndGoodsDisplayViewModel = value;
                Notify();
            }
        }

        private object _objAdminManagerDisplayViewModel;
        public object ObjAdminManagerDisplayViewModel
        {
            get { return _objAdminManagerDisplayViewModel; }
            set
            {
                _objAdminManagerDisplayViewModel = value;
                Notify();
            }
        }

        #endregion

        private double _dblMainWinW;
        public double DblMainWinW
        {
            get { return _dblMainWinW; }
            set
            {
                _dblMainWinW = value;
                Notify();
            }
        }

        private double _dblMainWinH;
        public double DblMainWinH
        {
            get { return _dblMainWinH; }
            set
            {
                _dblMainWinH = value;
                Notify();
            }
        }

        #region MainTitle
        private Command _icmdMainTitleHomeBtnClk;
        public ICommand IcmdMainTitleHomeBtnClk
        {
            get { return _icmdMainTitleHomeBtnClk = new Command(OnIcmdMainTitleHomeBtnClk); }
        }

        private void OnIcmdMainTitleHomeBtnClk(object obj)
        {
            WeakReferenceMessenger.Default.Send(new CustomEvent("MainDisplayViewModel-ObcMainGoodsCartList-Clear"));

            WeakReferenceMessenger.Default.Send(new CustomMessage("LockDiplayViewModel-BlLockVis", true));
            WeakReferenceMessenger.Default.Send(new CustomMessage("MainDisplayViewModel-BlMainDisplayVis", false));

            WeakReferenceMessenger.Default.Send(new CustomMessage("DetailCategoryAndGoodsDisplayViewModel-BlDetailGoodsGridVis", false));
            WeakReferenceMessenger.Default.Send(new CustomMessage("GoodsConfirmDisplayViewModel-BlGoodsConfirmVis", false));
        }

        private Command _icmdWindowGoAdminManager;
        public ICommand IcmdWindowGoAdminManager
        {
            get { return _icmdWindowGoAdminManager = new Command(OnIcmdWindowGoAdminManager); }
        }

        private void OnIcmdWindowGoAdminManager(object obj)
        {
            // 한번이라도 클릭했다면, 타이머를 바로 다시 발동시키지 않기 위함
            if (InClickCount == 0)
            {
                DpctAdminManager.Start();
            }

            InClickCount++;

            // 지정된 횟수가 초과 했다면 관리자 화면으로 이동
            if (InClickCount >= 3)
            {
                DpctAdminManager.Stop();
                WeakReferenceMessenger.Default.Send(new CustomMessage("AdminManagerDisplayViewModel-BlAdminManagerVis", true));
                InClickCount = 0;

                // 통신하여 아이디 비밀번호 가져오기
                WeakReferenceMessenger.Default.Send(new CustomEvent("AdminManagerDisplayViewModel-GetPwId"));
            }
        }

        private int _inClickCount = 0;
        public int InClickCount
        {
            get { return _inClickCount; }
            set
            {
                _inClickCount = value;
                Notify();
            }
        }
        private void DpctAdminManager_Tick(object? sender, EventArgs e)
        {
            InClickCount = 0;
            DpctAdminManager.Stop();
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
