using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WPF_Kiosk.Model;

namespace WPF_Kiosk.ViewModel
{
    public class DetailCategoryAndGoodsDisplayViewModel : INotifyPropertyChanged
    {
        public DetailCategoryAndGoodsDisplayViewModel()
        {
            WeakReferenceMessenger.Default.Register<CustomMessage>(this, ReceiveMessage);
        }

        private void ReceiveMessage(object recipient, CustomMessage message)
        {
            if (message.EventName == "DetailCategoryAndGoodsDisplayViewModel-BlDetailGoodsGridVis")
            {
                BlDetailGoodsGridVis = (bool)message.Message;
                SetDetailGoodsQuickBtns();
            }
            else if (message.EventName == "DetailCategoryAndGoodsDisplayViewModel-ClsMainGoodsSelected")
            {
                ClsMainGoodsSelected = new MainGoods((MainGoods)message.Message);
            }
        }

        private bool _blDetailGoodsGridVis = false;
        public bool BlDetailGoodsGridVis
        {
            get { return _blDetailGoodsGridVis; }
            set
            {
                _blDetailGoodsGridVis = value;
                Notify();
            }
        }

        private MainGoods? _clsMainGoodsSelected = new MainGoods();
        public MainGoods? ClsMainGoodsSelected
        {
            get { return _clsMainGoodsSelected; }
            set
            {
                _clsMainGoodsSelected = value;
                Notify();
            }
        }

        private int _inDetailCategoryCurrentIndex = StaticValue.Stc_InDetailCategoryHCnt;
        public int InDetailCategoryCurrentIndex
        {
            get { return _inDetailCategoryCurrentIndex; }
            set
            {
                _inDetailCategoryCurrentIndex = value;
                Notify();
            }
        }

        private Command _icmdDetailGoodsPageClkL;
        public ICommand IcmdDetailGoodsPageClkL
        {
            get { return _icmdDetailGoodsPageClkL = new Command(OnIcmdDetailGoodsPageClkL); }
        }

        private void OnIcmdDetailGoodsPageClkL(object InMainCategoryNum)
        {
            if (ClsMainGoodsSelected.ObcDetailCategoryList[(int)InMainCategoryNum].InDetailGoodsCurrentIndex <= StaticValue.Stc_InDetailGoodsWCnt)
            {
                return;
            }

            int CurrentIndex = ClsMainGoodsSelected.ObcDetailCategoryList[(int)InMainCategoryNum].InDetailGoodsCurrentIndex;
            ClsMainGoodsSelected.ObcDetailCategoryList[(int)InMainCategoryNum].ObcDetailGoodsList[CurrentIndex - 1].BlDetailGoodsVis = false;
            ClsMainGoodsSelected.ObcDetailCategoryList[(int)InMainCategoryNum].ObcDetailGoodsList[CurrentIndex - (StaticValue.Stc_InDetailGoodsWCnt + 1)].BlDetailGoodsVis = true;

            ClsMainGoodsSelected.ObcDetailCategoryList[(int)InMainCategoryNum].InDetailGoodsCurrentIndex--;
        }

        private Command _icmdDetailGoodsPageClkR;
        public ICommand IcmdDetailGoodsPageClkR
        {
            get { return _icmdDetailGoodsPageClkR = new Command(OnIcmdDetailGoodsPageClkR); }
        }

        private void OnIcmdDetailGoodsPageClkR(object InMainCategoryNum)
        {
            if (ClsMainGoodsSelected.ObcDetailCategoryList[(int)InMainCategoryNum].InDetailGoodsCurrentIndex == ClsMainGoodsSelected.ObcDetailCategoryList[(int)InMainCategoryNum].ObcDetailGoodsList.Count)
            {
                return;
            }

            int CurrentIndex = ClsMainGoodsSelected.ObcDetailCategoryList[(int)InMainCategoryNum].InDetailGoodsCurrentIndex;
            ClsMainGoodsSelected.ObcDetailCategoryList[(int)InMainCategoryNum].ObcDetailGoodsList[CurrentIndex].BlDetailGoodsVis = true;
            ClsMainGoodsSelected.ObcDetailCategoryList[(int)InMainCategoryNum].ObcDetailGoodsList[CurrentIndex - StaticValue.Stc_InDetailGoodsWCnt].BlDetailGoodsVis = false;

            ClsMainGoodsSelected.ObcDetailCategoryList[(int)InMainCategoryNum].InDetailGoodsCurrentIndex++;
        }

        #region DetailGoodsQuickBtn

        private Command _icmdDetailCategoryPageClkL;
        public ICommand IcmdDetailCategoryPageClkL
        {
            get { return _icmdDetailCategoryPageClkL = new Command(OnIcmdDetailCategoryPageClkL); }
        }

        private void OnIcmdDetailCategoryPageClkL(object obj)
        {
            // 첫 페이지가 아닐 경우
            if (InDetailCategoryCurrentIndex > StaticValue.Stc_InDetailCategoryHCnt)
            {
                // 전체 GoodsDetailCategory의 Visible을 false로 변경
                foreach (var item in ClsMainGoodsSelected.ObcDetailCategoryList)
                {
                    item.BlDetailCategoryVis = false;
                }

                InDetailCategoryCurrentIndex -= StaticValue.Stc_InDetailCategoryHCnt;

                // GoodsDetailCategory의 Visible을 InDetailCategoryCurrentIndex개 단위로 true로 변경
                for (int i = InDetailCategoryCurrentIndex - 1; i > InDetailCategoryCurrentIndex - StaticValue.Stc_InDetailCategoryHCnt - 1; i--)
                {
                    ClsMainGoodsSelected.ObcDetailCategoryList[i].BlDetailCategoryVis = true;
                }

                // 상품디테일카테고리 넘기는 버튼 클릭후에는, short버튼도 같이 변경
                // Short버튼의 체크를 하나 왼쪽으로 옮김
                int index = 0;
                for (int i = 0; i < ObcDetailGoodsQuickBtnList.Count; i++)
                {
                    if (ObcDetailGoodsQuickBtnList[i].BlDetailGoodsQuickBtnChecked == true)
                    {
                        index = i;
                        break;
                    }
                }
                ObcDetailGoodsQuickBtnList[index].BlDetailGoodsQuickBtnChecked = false;
                ObcDetailGoodsQuickBtnList[index - 1].BlDetailGoodsQuickBtnChecked = true;
            }
        }

        private Command _icmdDetailCategoryPageClkR;
        public ICommand IcmdDetailCategoryPageClkR
        {
            get { return _icmdDetailCategoryPageClkR = new Command(OnIcmdDetailCategoryPageClkR); }
        }

        private void OnIcmdDetailCategoryPageClkR(object obj)
        {
            // 마지막 페이지가 아닐 경우
            if (InDetailCategoryCurrentIndex < ClsMainGoodsSelected.ObcDetailCategoryList.Count)
            {
                // 전체 ClsMainGoodsSelected.ObcDetailCategoryList의 Visible을 false로 변경
                foreach (var item in ClsMainGoodsSelected.ObcDetailCategoryList)
                {
                    item.BlDetailCategoryVis = false;
                }


                // GoodsDetailCategory의 Visible을 InDetailCategoryCurrentIndex개 단위로 true로 변경
                for (int i = InDetailCategoryCurrentIndex; i < Math.Min(InDetailCategoryCurrentIndex + StaticValue.Stc_InDetailCategoryHCnt, ClsMainGoodsSelected.ObcDetailCategoryList.Count); i++)
                {
                    ClsMainGoodsSelected.ObcDetailCategoryList[i].BlDetailCategoryVis = true;
                }

                InDetailCategoryCurrentIndex += StaticValue.Stc_InDetailCategoryHCnt;

                // 상품디테일카테고리 넘기는 버튼 클릭후에는, short버튼도 같이 변경
                // Short버튼의 체크를 하나 오른쪽으로 옮김
                int index = 0;
                for (int i = 0; i < ObcDetailGoodsQuickBtnList.Count; i++)
                {
                    if (ObcDetailGoodsQuickBtnList[i].BlDetailGoodsQuickBtnChecked == true)
                    {
                        index = i;
                        break;
                    }
                }
                ObcDetailGoodsQuickBtnList[index].BlDetailGoodsQuickBtnChecked = false;
                ObcDetailGoodsQuickBtnList[index + 1].BlDetailGoodsQuickBtnChecked = true;
            }
        }

        private void SetDetailGoodsQuickBtns()
        {
            ObcDetailGoodsQuickBtnList.Clear();
            int quotient = ClsMainGoodsSelected.ObcDetailCategoryList.Count / StaticValue.Stc_InDetailCategoryHCnt;  // 몫
            int remainder = ClsMainGoodsSelected.ObcDetailCategoryList.Count % StaticValue.Stc_InDetailCategoryHCnt; // 나머지

            // Quick버튼 수 구하기
            int GoodsDetailShortDisplayBtnsCnt = 0;
            if (remainder > 0)
            {
                GoodsDetailShortDisplayBtnsCnt = quotient + 1; // 나머지가 있다면 Quick버튼 한개를 더 만들어야됨
            }
            else
            {
                GoodsDetailShortDisplayBtnsCnt = quotient; // 나머지가 없다면 Quick버튼은 정확히 페이지 수많큼 있으면 됨
            }

            for (int i = 0; i < GoodsDetailShortDisplayBtnsCnt; i++)
            {
                if (i == 0) // 첫번째 버튼은 체크
                {
                    ObcDetailGoodsQuickBtnList.Add(new DetailGoodsQuickBtn() { InDetailGoodsQuickBtnNum = i, BlDetailGoodsQuickBtnChecked = true });
                }
                else
                {
                    ObcDetailGoodsQuickBtnList.Add(new DetailGoodsQuickBtn() { InDetailGoodsQuickBtnNum = i, BlDetailGoodsQuickBtnChecked = false });
                }
            }
        }

        private ObservableCollection<DetailGoodsQuickBtn> _obcDetailGoodsQuickBtnList = new ObservableCollection<DetailGoodsQuickBtn>();
        public ObservableCollection<DetailGoodsQuickBtn> ObcDetailGoodsQuickBtnList
        {
            get { return _obcDetailGoodsQuickBtnList; }
            set
            {
                _obcDetailGoodsQuickBtnList = value;
                Notify();
            }
        }

        private Command _icmdDetailGoodsQuickBtnClk;
        public ICommand IcmdDetailGoodsQuickBtnClk
        {
            get { return _icmdDetailGoodsQuickBtnClk = new Command(OnIcmdDetailGoodsQuickBtnClk); }
        }

        private void OnIcmdDetailGoodsQuickBtnClk(object obj)
        {
            // 상품디테일 카테고리 인덱스는 StaticValue.Stc_InDetailCategoryHCnt * 페이지로 구한다
            InDetailCategoryCurrentIndex = StaticValue.Stc_InDetailCategoryHCnt * (int)obj;

            // 클릭한 상품의 카테고리의 Visible을 false로 변경
            foreach (var item in ClsMainGoodsSelected.ObcDetailCategoryList)
            {
                item.BlDetailCategoryVis = false;
            }

            // ClsMainGoodsSelected.ObcDetailCategoryList의 Visible을 InDetailCategoryCurrentIndex개 단위로 true로 변경
            for (int i = InDetailCategoryCurrentIndex; i < Math.Min(InDetailCategoryCurrentIndex + StaticValue.Stc_InDetailCategoryHCnt, ClsMainGoodsSelected.ObcDetailCategoryList.Count); i++)
            {
                ClsMainGoodsSelected.ObcDetailCategoryList[i].BlDetailCategoryVis = true;
            }

            InDetailCategoryCurrentIndex += StaticValue.Stc_InDetailCategoryHCnt;
        }

        #endregion

        private Command _icmdDetailGoodsGridClose;
        public ICommand IcmdDetailGoodsGridClose
        {
            get { return _icmdDetailGoodsGridClose = new Command(OnIcmdDetailGoodsGridClose); }
        }

        // 상품디테일창 닫기
        private void OnIcmdDetailGoodsGridClose(object obj)
        {
            BlDetailGoodsGridVis = false;

            // 클릭했던 상품 초기화
            ClsMainGoodsSelected = null;
        }

        private Command _icmdDetailGoodsSelectGoCart;
        public ICommand IcmdDetailGoodsSelectGoCart
        {
            get { return _icmdDetailGoodsSelectGoCart = new Command(OnIcmdDetailGoodsSelectGoCart); }
        }

        // 선택한 상품 디테일창에서 장바구니로 이동
        private void OnIcmdDetailGoodsSelectGoCart(object obj)
        {
            BlDetailGoodsGridVis = false;

            // 클릭한 상품 장바구니로 이동
            WeakReferenceMessenger.Default.Send(new CustomMessage("MainDisplayViewModel-ClsMainGoodsSelected-Add", ClsMainGoodsSelected));

            // 클릭했던 상품 초기화
            ClsMainGoodsSelected = null;
        }

        // 디테일상품 클릭
        private Command _icmdDetailGoodsClk;
        public ICommand IcmdDetailGoodsClk
        {
            get { return _icmdDetailGoodsClk = new Command(OnIcmdDetailGoodsClk); }
        }

        private void OnIcmdDetailGoodsClk(object obj)
        {
            DetailGoods DetailGoodsSelected = (DetailGoods)obj;
            DetailGoodsSelected.BlDetailGoodsClicked = !DetailGoodsSelected.BlDetailGoodsClicked;

            // DetailGoods의 체크 제한수는 여기서 작성
            /////////
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
