using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WPF_Kiosk.Model;

namespace WPF_Kiosk.ViewModel
{
    public class GoodsConfirmDisplayViewModel : INotifyPropertyChanged
    {
        public GoodsConfirmDisplayViewModel()
        {
            WeakReferenceMessenger.Default.Register<CustomMessage>(this, ReceiveMessage);
        }

        private void ReceiveMessage(object recipient, CustomMessage message)
        {
            if (message.EventName == "GoodsConfirmDisplayViewModel-BlGoodsConfirmVis")
            {
                BlGoodsConfirmVis = (bool)message.Message;
            }
            else if (message.EventName == "GoodsConfirmDisplayViewModel-ObcMainGoodsCartList")
            {
                ObcMainGoodsCartList = (ObservableCollection<MainGoods>)message.Message;

                SetGoodsConfirmQuickBtns(); // // GoodsConfirmQuickBtn 담기

                // GoodsConfirmList의 Visible을 StaticValue.Stc_InGoodsConfirmHCnt개 단위로 true로 변경
                SetGoodsConfirmListVis(); 
            }
        }

        private bool _blGoodsConfirmVis = false;
        public bool BlGoodsConfirmVis
        {
            get { return _blGoodsConfirmVis; }
            set
            {
                _blGoodsConfirmVis = value;
                Notify();
            }
        }

        private ObservableCollection<MainGoods> _obcMainGoodsCartList = new ObservableCollection<MainGoods>();
        public ObservableCollection<MainGoods> ObcMainGoodsCartList
        {
            get { return _obcMainGoodsCartList; }
            set
            {
                _obcMainGoodsCartList = value;
                Notify();
            }
        }

        private ObservableCollection<GoodsConfirmQuickBtn> _obcGoodsConfirmQuickBtnList = new ObservableCollection<GoodsConfirmQuickBtn>();
        public ObservableCollection<GoodsConfirmQuickBtn> ObcGoodsConfirmQuickBtnList
        {
            get { return _obcGoodsConfirmQuickBtnList; }
            set
            {
                _obcGoodsConfirmQuickBtnList = value;
                Notify();
            }
        }

        // GoodsConfirm화면 오픈시, Quick상품 버튼도 다시 생성
        private void SetGoodsConfirmQuickBtns()
        {
            ObcGoodsConfirmQuickBtnList.Clear();
            int quotient = ObcMainGoodsCartList.Count / StaticValue.Stc_InGoodsConfirmHCnt;  // 몫
            int remainder = ObcMainGoodsCartList.Count % StaticValue.Stc_InGoodsConfirmHCnt; // 나머지

            // Quick버튼 수 구하기
            int GoodsConfirmQuickBtnsCnt = 0;
            if (remainder > 0)
            {
                GoodsConfirmQuickBtnsCnt = quotient + 1; // 나머지가 있다면 Quick버튼 한개를 더 만들어야됨
            }
            else
            {
                GoodsConfirmQuickBtnsCnt = quotient; // 나머지가 없다면 Quick버튼은 정확히 페이지 수많큼 있으면 됨
            }

            for (int i = 0; i < GoodsConfirmQuickBtnsCnt; i++)
            {
                if (i == 0) // 첫번째 Quick버튼은 체크
                {
                    ObcGoodsConfirmQuickBtnList.Add(new GoodsConfirmQuickBtn() { InGoodsConfirmQuickBtnNum = i, BlGoodsConfirmQuickBtnChecked = true });
                }
                else
                {
                    ObcGoodsConfirmQuickBtnList.Add(new GoodsConfirmQuickBtn() { InGoodsConfirmQuickBtnNum = i, BlGoodsConfirmQuickBtnChecked = false });
                }
            }
        }

        private int _inGoodsConfirmCurrentIndex = 0;
        public int InGoodsConfirmCurrentIndex
        {
            get { return _inGoodsConfirmCurrentIndex; }
            set
            {
                _inGoodsConfirmCurrentIndex = value;
                Notify();
            }
        }

        private Command _icmdGoodsConfirmPageClkL;
        public ICommand IcmdGoodsConfirmPageClkL
        {
            get { return _icmdGoodsConfirmPageClkL = new Command(OnIcmdGoodsConfirmPageClkL); }
        }

        private void OnIcmdGoodsConfirmPageClkL(object obj)
        {
            // 첫 페이지가 아닐 경우
            if (InGoodsConfirmCurrentIndex > StaticValue.Stc_InGoodsConfirmHCnt)
            {
                // 전체 MainGoodsCartList의 Visible을 false로 변경
                foreach (var item in ObcMainGoodsCartList)
                {
                    item.BlMainGoodsVis = false;
                }

                InGoodsConfirmCurrentIndex -= StaticValue.Stc_InGoodsConfirmHCnt;

                // MainGoodsCartList의 Visible을 StaticValue.Stc_InGoodsConfirmHCnt개 단위로 true로 변경
                for (int i = InGoodsConfirmCurrentIndex - 1; i > InGoodsConfirmCurrentIndex - StaticValue.Stc_InGoodsConfirmHCnt - 1; i--)
                {
                    ObcMainGoodsCartList[i].BlMainGoodsVis = true;
                }

                // 상품 넘기는 버튼 클릭후에는, Quick버튼도 같이 변경
                // Quick버튼의 체크를 하나 왼쪽으로 옮김
                int index = 0;
                for (int i = 0; i < ObcGoodsConfirmQuickBtnList.Count; i++)
                {
                    if (ObcGoodsConfirmQuickBtnList[i].BlGoodsConfirmQuickBtnChecked == true)
                    {
                        index = i;
                        break;
                    }
                }
                ObcGoodsConfirmQuickBtnList[index].BlGoodsConfirmQuickBtnChecked = false;
                ObcGoodsConfirmQuickBtnList[index - 1].BlGoodsConfirmQuickBtnChecked = true;
            }
        }

        private Command _icmdGoodsConfirmPageClkR;
        public ICommand IcmdGoodsConfirmPageClkR
        {
            get { return _icmdGoodsConfirmPageClkR = new Command(OnIcmdGoodsConfirmPageClkR); }
        }

        private void OnIcmdGoodsConfirmPageClkR(object obj)
        {
            // 마지막 페이지가 아닐 경우
            if (InGoodsConfirmCurrentIndex < ObcMainGoodsCartList.Count)
            {
                // 전체 MainGoodsCartList의 Visible을 false로 변경
                foreach (var item in ObcMainGoodsCartList)
                {
                    item.BlMainGoodsVis = false;
                }

                // MainGoodsCartList의 Visible을 StaticValue.Stc_InGoodsConfirmHCnt개 단위로 true로 변경
                for (int i = InGoodsConfirmCurrentIndex; i < Math.Min(InGoodsConfirmCurrentIndex + StaticValue.Stc_InGoodsConfirmHCnt, ObcMainGoodsCartList.Count); i++)
                {
                    ObcMainGoodsCartList[i].BlMainGoodsVis = true;
                }

                InGoodsConfirmCurrentIndex += StaticValue.Stc_InGoodsConfirmHCnt;

                // 상품 넘기는 버튼 클릭후에는, Quick버튼도 같이 변경
                // Quick버튼의 체크를 하나 오른쪽으로 옮김
                int index = 0;
                for (int i = 0; i < ObcGoodsConfirmQuickBtnList.Count; i++)
                {
                    if (ObcGoodsConfirmQuickBtnList[i].BlGoodsConfirmQuickBtnChecked == true)
                    {
                        index = i;
                        break;
                    }
                }
                ObcGoodsConfirmQuickBtnList[index].BlGoodsConfirmQuickBtnChecked = false;
                ObcGoodsConfirmQuickBtnList[index + 1].BlGoodsConfirmQuickBtnChecked = true;
            }
        }

        private void SetGoodsConfirmListVis()
        {
            // ObcMainGoodsCartList전체를 안보이게 초기화
            foreach (var item in ObcMainGoodsCartList)
            {
                item.BlMainGoodsVis = false;
            }

            // ObcMainGoodsCartList의 Visible을 StaticValue.Stc_InGoodsConfirmHCnt개 단위로 true로 변경
            for (int i = 0; i < Math.Min(StaticValue.Stc_InGoodsConfirmHCnt, ObcMainGoodsCartList.Count); i++)
            {
                ObcMainGoodsCartList[i].BlMainGoodsVis = true;
            }
            InGoodsConfirmCurrentIndex = StaticValue.Stc_InGoodsConfirmHCnt;
        }

        private Command _icmdGoodsConfirmQuickBtnClk;
        public ICommand IcmdGoodsConfirmQuickBtnClk
        {
            get { return _icmdGoodsConfirmQuickBtnClk = new Command(OnIcmdGoodsConfirmQuickBtnClk); }
        }

        private void OnIcmdGoodsConfirmQuickBtnClk(object obj)
        {
            // InGoodsConfirmCurrentIndex 인덱스는 StaticValue.Stc_InGoodsConfirmHCnt * 페이지로 구한다
            InGoodsConfirmCurrentIndex = StaticValue.Stc_InGoodsConfirmHCnt * (int)obj;

            // GoodsConfirmList의 전체 Visible을 false로 변경
            foreach (var item in ObcMainGoodsCartList)
            {
                item.BlMainGoodsVis = false;
            }

            // GoodsConfirmList의 Visible을 StaticValue.Stc_InGoodsConfirmHCnt개 단위로 true로 변경
            for (int i = InGoodsConfirmCurrentIndex; i < Math.Min(InGoodsConfirmCurrentIndex + StaticValue.Stc_InGoodsConfirmHCnt, ObcMainGoodsCartList.Count); i++)
            {
                ObcMainGoodsCartList[i].BlMainGoodsVis = true;
            }

            InGoodsConfirmCurrentIndex += StaticValue.Stc_InGoodsConfirmHCnt;
        }

        private Command _icmdGoodsConfirmToMainDisplay;
        public ICommand IcmdGoodsConfirmToMainDisplay
        {
            get { return _icmdGoodsConfirmToMainDisplay = new Command(OnIcmdGoodsConfirmToMainDisplay); }
        }

        private void OnIcmdGoodsConfirmToMainDisplay(object obj)
        {
            // GoodsConfirm화면 안보이게 하기
            BlGoodsConfirmVis = false;

            // Main화면 보이게 하기
            WeakReferenceMessenger.Default.Send(new CustomMessage("MainDisplayViewModel-BlMainDisplayVis", true));

            // MainGoodsCart의 Visible을 StaticValue.Stc_InGoodsCartWCnt개 단위로 true로 변경
            // 첫번째 담긴 상품이 보이도록함
            WeakReferenceMessenger.Default.Send(new CustomEvent("MainDisplayViewModel-SetCartGoodsFirstVis"));
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
