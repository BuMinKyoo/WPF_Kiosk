using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WPF_Kiosk.Model;

namespace WPF_Kiosk.ViewModel
{
    public class MainDisplayViewModel : INotifyPropertyChanged
    {
        public MainDisplayViewModel()
        {
            #region 데이터
            // 카테고리 담기
            for (int i = 0; i < 12; i++)
            {
                ObcMainCategoryList.Add(new MainCategory() { InMainCategoryNum = i, StrMainCategoryName = i.ToString() });
            }

            // 카테고리1상품
            for (int i = 0; i < 10; i++)
            {
                ObcAllMainGoodsList.Add(new MainGoods() { InMainGoodsMainCategoryNum = 0, StrMainGoodsName = "카테0상품" + i.ToString(), InMainGoodsDiscount = 0, InMainGoodsPrice = 1000 + 1000 * i, });

                // 카테고리1상품의 디테일 카테고리 개수
                for (int j = 0; j < 6; j++)
                {
                    ObcAllMainGoodsList[i].ObcDetailCategoryList.Add(new DetailCategory() { InDetailCategoryNum = j, StrDetailCategoryName = ObcAllMainGoodsList[i].StrMainGoodsName + "디테일" + j.ToString() });


                    // 카데고리 디테일 n번의 디테일 개수
                    if (j == 0)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            ObcAllMainGoodsList[i].ObcDetailCategoryList[j].ObcDetailGoodsList.Add(new DetailGoods() { StrDetailGoodsName = ObcAllMainGoodsList[i].ObcDetailCategoryList[j].StrDetailCategoryName + "상품" + k.ToString(), InDetailGoodsDiscount = 0, InDetailGoodsPrice = 100 + 100 * k, InDetailGoodsDetailCategoryNum = j, InDetailGoodsNum = k });
                        }
                    }
                    else if (j == 1)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            ObcAllMainGoodsList[i].ObcDetailCategoryList[j].ObcDetailGoodsList.Add(new DetailGoods() { StrDetailGoodsName = ObcAllMainGoodsList[i].ObcDetailCategoryList[j].StrDetailCategoryName + "상품" + k.ToString(), InDetailGoodsDiscount = 0, InDetailGoodsPrice = 100 + 100 * k, InDetailGoodsDetailCategoryNum = j, InDetailGoodsNum = k });
                        }
                    }
                    else if (j == 2)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            ObcAllMainGoodsList[i].ObcDetailCategoryList[j].ObcDetailGoodsList.Add(new DetailGoods() { StrDetailGoodsName = ObcAllMainGoodsList[i].ObcDetailCategoryList[j].StrDetailCategoryName + "상품" + k.ToString(), InDetailGoodsDiscount = 0, InDetailGoodsPrice = 100 + 100 * k, InDetailGoodsDetailCategoryNum = j, InDetailGoodsNum = k });
                        }
                    }
                    else if (j == 3)
                    {
                        for (int k = 0; k < 6; k++)
                        {
                            ObcAllMainGoodsList[i].ObcDetailCategoryList[j].ObcDetailGoodsList.Add(new DetailGoods() { StrDetailGoodsName = ObcAllMainGoodsList[i].ObcDetailCategoryList[j].StrDetailCategoryName + "상품" + k.ToString(), InDetailGoodsDiscount = 0, InDetailGoodsPrice = 100 + 100 * k, InDetailGoodsDetailCategoryNum = j, InDetailGoodsNum = k });
                        }
                    }
                    else if (j == 4)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            ObcAllMainGoodsList[i].ObcDetailCategoryList[j].ObcDetailGoodsList.Add(new DetailGoods() { StrDetailGoodsName = ObcAllMainGoodsList[i].ObcDetailCategoryList[j].StrDetailCategoryName + "상품" + k.ToString(), InDetailGoodsDiscount = 0, InDetailGoodsPrice = 100 + 100 * k, InDetailGoodsDetailCategoryNum = j, InDetailGoodsNum = k });
                        }
                    }
                    else if (j == 5)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            ObcAllMainGoodsList[i].ObcDetailCategoryList[j].ObcDetailGoodsList.Add(new DetailGoods() { StrDetailGoodsName = ObcAllMainGoodsList[i].ObcDetailCategoryList[j].StrDetailCategoryName + "상품" + k.ToString(), InDetailGoodsDiscount = 0, InDetailGoodsPrice = 100 + 100 * k, InDetailGoodsDetailCategoryNum = j, InDetailGoodsNum = k });
                        }
                    }

                    // 디테일 카테고리안에 디테일이 표시되는 인덱스
                    int index = Math.Min(StaticValue.Stc_InDetailGoodsWCnt, ObcAllMainGoodsList[i].ObcDetailCategoryList[j].InDetailGoodsCurrentIndex = ObcAllMainGoodsList[i].ObcDetailCategoryList[j].ObcDetailGoodsList.Count);
                    ObcAllMainGoodsList[i].ObcDetailCategoryList[j].InDetailGoodsCurrentIndex = index;
                }
            }

            // 카테고리2상품
            for (int i = 0; i < 20; i++)
            {
                ObcAllMainGoodsList.Add(new MainGoods() { InMainGoodsMainCategoryNum = 1, StrMainGoodsName = "카테1상품" + i.ToString(), InMainGoodsDiscount = 0, InMainGoodsPrice = 1000 + 1000 * i, });
            }

            // 카테고리3상품
            for (int i = 0; i < 40; i++)
            {
                ObcAllMainGoodsList.Add(new MainGoods() { InMainGoodsMainCategoryNum = 2, StrMainGoodsName = "카테2상품" + i.ToString(), InMainGoodsDiscount = 0, InMainGoodsPrice = 1000 + 1000 * i, });
            }
            #endregion

            #region 초기에 보여지는 데이터들
            SetMainGoodsMainCategory();

            // 초기에 보여지는 Short버튼 생성
            SetMainGoodsQuickBtns();
            #endregion

            WeakReferenceMessenger.Default.Register<CustomMessage>(this, ReceiveMessage);
            WeakReferenceMessenger.Default.Register<CustomEvent>(this, ReceiveEvent);
        }

        private void ReceiveEvent(object recipient, CustomEvent message)
        {
            if (message.EventName == "MainDisplayViewModel-ObcMainGoodsCartList-Clear")
            {
                ObcMainGoodsCartList.Clear();
            }
            else if (message.EventName == "MainDisplayViewModel-SetCartGoodsFirstVis")
            {
                // MainGoodsCart의 Visible을 StaticValue.Stc_InGoodsCartWCnt개 단위로 true로 변경
                // 첫번째 담긴 상품이 보이도록함
                SetCartGoodsFirstVis();
            }
        }

        private void ReceiveMessage(object recipient, CustomMessage message)
        {
            if (message.EventName == "MainDisplayViewModel-BlMainDisplayVis")
            {
                BlMainDisplayVis = (bool)message.Message;
            }
            else if (message.EventName == "MainDisplayViewModel-ClsMainGoodsSelected-Add")
            {
                ObcMainGoodsCartList.Add((MainGoods)message.Message);
            }
        }

        #region MainCategory
        private ObservableCollection<MainCategory> _obcMainCategoryList = new ObservableCollection<MainCategory>();
        public ObservableCollection<MainCategory> ObcMainCategoryList
        {
            get { return _obcMainCategoryList; }
            set
            {
                _obcMainCategoryList = value;
                Notify();
            }
        }


        private int _inMainCatecoryCurrentIndex = 0;
        public int InMainCatecoryCurrentIndex
        {
            get { return _inMainCatecoryCurrentIndex; }
            set
            {
                _inMainCatecoryCurrentIndex = value;
                Notify();
            }
        }

        private Command _icmdMainCategoryPageClkL;
        public ICommand IcmdMainCategoryPageClkL
        {
            get { return _icmdMainCategoryPageClkL = new Command(OnIcmdMainCategoryPageClkL); }
        }

        private void OnIcmdMainCategoryPageClkL(object obj)
        {
            if (InMainCatecoryCurrentIndex <= StaticValue.Stc_InMainCategoryWCnt)
            {
                return;
            }

            ObcMainCategoryList[InMainCatecoryCurrentIndex - 1].BlMainCategoryVis = false;
            ObcMainCategoryList[InMainCatecoryCurrentIndex - (StaticValue.Stc_InMainCategoryWCnt + 1)].BlMainCategoryVis = true;
            InMainCatecoryCurrentIndex--;
        }

        private Command _icmdMainCategoryPageClkR;
        public ICommand IcmdMainCategoryPageClkR
        {
            get { return _icmdMainCategoryPageClkR = new Command(OnIcmdMainCategoryPageClkR); }
        }

        private void OnIcmdMainCategoryPageClkR(object obj)
        {
            if (InMainCatecoryCurrentIndex == ObcMainCategoryList.Count)
            {
                return;
            }

            ObcMainCategoryList[InMainCatecoryCurrentIndex].BlMainCategoryVis = true;
            ObcMainCategoryList[InMainCatecoryCurrentIndex - StaticValue.Stc_InMainCategoryWCnt].BlMainCategoryVis = false;
            InMainCatecoryCurrentIndex++;
        }


        private Command _icmdMainCategoryClk;
        public ICommand IcmdMainCategoryClk
        {
            get { return _icmdMainCategoryClk = new Command(OnIcmdMainCategoryClk); }
        }

        private void OnIcmdMainCategoryClk(object obj)
        {
            //선택된 MainCategory에 해당되는 MainGoods담기
            ObcMainGoodsList.Clear();
            if (obj is string categoryStr) // obj가 string인 경우
            {
                foreach (var allGoodsItem in ObcAllMainGoodsList)
                {
                    if (int.TryParse(categoryStr, out int InMainCategoryNum))
                    {
                        if (allGoodsItem.InMainGoodsMainCategoryNum == InMainCategoryNum)
                        {
                            ObcMainGoodsList.Add(allGoodsItem);
                        }
                    }
                    // 변환 실패 시 처리할 로직 필요하면 추가
                }
            }
            else if (obj is int InMainCategoryNum) // obj가 이미 int인 경우
            {
                foreach (var allGoodsItem in ObcAllMainGoodsList)
                {
                    if (allGoodsItem.InMainGoodsMainCategoryNum == InMainCategoryNum)
                    {
                        ObcMainGoodsList.Add(allGoodsItem);
                    }
                }
            }

            // 인덱스 초기화 작업 및 상품 display
            InMainGoodsCurrentIndex = 0;
            for (int i = 0; i < Math.Min(StaticValue.Stc_InMainGoodsWCnt * StaticValue.Stc_InMainGoodsHCnt, ObcMainGoodsList.Count); i++)
            {
                ObcMainGoodsList[i].BlMainGoodsVis = true;
                InMainGoodsCurrentIndex++;
            }

            SetMainGoodsQuickBtns();
        }

        // MainCategory 클릭시, Quick상품 버튼도 다시 생성
        private void SetMainGoodsQuickBtns()
        {
            ObcMainGoodsQuickBtnList.Clear();
            int quotient = ObcMainGoodsList.Count / (StaticValue.Stc_InMainGoodsWCnt * StaticValue.Stc_InMainGoodsHCnt);  // 몫
            int remainder = ObcMainGoodsList.Count % (StaticValue.Stc_InMainGoodsWCnt * StaticValue.Stc_InMainGoodsHCnt); // 나머지

            // Quick버튼 수 구하기
            int GoodsShortDisplayBtnsCnt = 0;
            if (remainder > 0)
            {
                GoodsShortDisplayBtnsCnt = quotient + 1; // 나머지가 있다면 Quick버튼 한개를 더 만들어야됨
            }
            else
            {
                GoodsShortDisplayBtnsCnt = quotient; // 나머지가 없다면 Quick버튼은 정확히 페이지 수많큼 있으면 됨
            }

            for (int i = 0; i < GoodsShortDisplayBtnsCnt; i++)
            {
                if (i == 0) // 첫번째 Quick버튼은 체크
                {
                    ObcMainGoodsQuickBtnList.Add(new MainGoodsQuickBtn() { InMainGoodsQuickBtnNum = i, BlMainGoodsQuickBtnChecked = true });
                }
                else
                {
                    ObcMainGoodsQuickBtnList.Add(new MainGoodsQuickBtn() { InMainGoodsQuickBtnNum = i, BlMainGoodsQuickBtnChecked = false });
                }
            }
        }
        #endregion

        #region MainGoods
        private void SetMainGoodsMainCategory()
        {
            // 초기에 보여지는 카테고리 StaticValue.Stc_InMainCategoryWCnt개
            for (int i = 0; i < Math.Min(StaticValue.Stc_InMainCategoryWCnt, ObcMainCategoryList.Count); i++)
            {
                ObcMainCategoryList[i].BlMainCategoryVis = true;
            }
            InMainCatecoryCurrentIndex = StaticValue.Stc_InMainCategoryWCnt;

            // 초기에 보여지는 상품 StaticValue.Stc_InMainGoodsWCnt* StaticValue.Stc_InMainGoodsHCnt개(카테고리 0번)
            ObcMainGoodsList.Clear();
            foreach (var allGoodsItem in ObcAllMainGoodsList)
            {
                if (allGoodsItem.InMainGoodsMainCategoryNum == 0)
                {
                    ObcMainGoodsList.Add(allGoodsItem);
                }
            }

            for (int i = 0; i < Math.Min(StaticValue.Stc_InMainGoodsWCnt * StaticValue.Stc_InMainGoodsHCnt, ObcMainGoodsList.Count); i++)
            {
                ObcMainGoodsList[i].BlMainGoodsVis = true;

                for (int j = 0; j < ObcMainGoodsList[i].ObcDetailCategoryList.Count; j++)
                {
                    // 디테일 카테고리는 전부 돌리면서, 담아야지, 디테일 상품의 display를 전체적으로 돌릴 수 있음
                    if (j < StaticValue.Stc_InDetailCategoryHCnt)
                    {
                        ObcMainGoodsList[i].ObcDetailCategoryList[j].BlDetailCategoryVis = true;
                    }
                    else
                    {
                        ObcMainGoodsList[i].ObcDetailCategoryList[j].BlDetailCategoryVis = false;
                    }

                    // 카데고리 디테일 n번의 디테일 개수
                    for (int k = 0; k < Math.Min(StaticValue.Stc_InDetailGoodsWCnt, ObcAllMainGoodsList[i].ObcDetailCategoryList[j].ObcDetailGoodsList.Count); k++)
                    {
                        if (j == 4)
                        {

                        }
                        ObcAllMainGoodsList[i].ObcDetailCategoryList[j].ObcDetailGoodsList[k].BlDetailGoodsVis = true;
                    }
                }
            }
            InMainGoodsCurrentIndex = StaticValue.Stc_InMainGoodsHCnt * StaticValue.Stc_InMainGoodsWCnt;
        }

        private ObservableCollection<MainGoods> _obcAllMainGoodsList = new ObservableCollection<MainGoods>();
        public ObservableCollection<MainGoods> ObcAllMainGoodsList
        {
            get { return _obcAllMainGoodsList; }
            set
            {
                _obcAllMainGoodsList = value;
                Notify();
            }
        }

        private ObservableCollection<MainGoods> _obcMainGoodsList = new ObservableCollection<MainGoods>();
        public ObservableCollection<MainGoods> ObcMainGoodsList
        {
            get { return _obcMainGoodsList; }
            set
            {
                _obcMainGoodsList = value;
                Notify();
            }
        }

        private int _inMainGoodsCurrentIndex = 0;
        public int InMainGoodsCurrentIndex
        {
            get { return _inMainGoodsCurrentIndex; }
            set
            {
                _inMainGoodsCurrentIndex = value;
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

        private Command _icmdMainGoodsClk;
        public ICommand IcmdMainGoodsClk
        {
            get { return _icmdMainGoodsClk = new Command(OnIcmdMainGoodsClk); }
        }

        // 클릭한 상품의 데이터를 받아서 상품 담기
        private void OnIcmdMainGoodsClk(object obj)
        {
            // 클릭한 상품을 클릭한 상품으로 잡기
            ClsMainGoodsSelected = new MainGoods((MainGoods)obj);
            WeakReferenceMessenger.Default.Send(new CustomMessage("DetailCategoryAndGoodsDisplayViewModel-ClsMainGoodsSelected", ClsMainGoodsSelected));


            // 클릭한 상품이 디테일 상품을 가지고 있는 경우
            if (ClsMainGoodsSelected.ObcDetailCategoryList.Count > 0)
            {
                WeakReferenceMessenger.Default.Send(new CustomMessage("DetailCategoryAndGoodsDisplayViewModel-BlDetailGoodsGridVis", true));
            }
            else // 클릭한 상품이 디테일 상품을 가지고 있지 않는 경우
            {
                ObcMainGoodsCartList.Add(ClsMainGoodsSelected);
                ClsMainGoodsSelected = null;
                // 상품을 클릭한 후 담고난 뒤, 장바구니 상품들의 Visible의 true, false를 조절
                // 마지막에 담긴 상품이 보이도록함
                SetCartGoodsLastVis();
            }
        }

        private void SetCartGoodsLastVis()
        {
            if (ObcMainGoodsCartList.Count > StaticValue.Stc_InGoodsCartWCnt)
            {
                // 전체 CartGoods의 Visible을 false로 변경
                foreach (var item in ObcMainGoodsCartList)
                {
                    item.BlMainGoodsVis = false;
                }

                // CartGoods의 Visible을 StaticValue.Stc_InGoodsCartWCnt개 단위로 true로 변경
                for (int i = 0; i < StaticValue.Stc_InGoodsCartWCnt; i++)
                {
                    ObcMainGoodsCartList[ObcMainGoodsCartList.Count - 1 - i].BlMainGoodsVis = true;
                }
            }

            // 상품을 선택하면 항상 마지막 index를 가리키도록 함
            InMainGoodsCartCurrentIndex = ObcMainGoodsCartList.Count;
        }

        // GoodsConfirm화면에서 Main화면으로 돌아올시 상품의 Display를 처음으로 돌리기
        private void SetCartGoodsFirstVis()
        {
            // 전체 CartGoods의 Visible을 false로 변경
            foreach (var item in ObcMainGoodsCartList)
            {
                item.BlMainGoodsVis = false;
            }

            // MainGoodsCart의 Visible을 StaticValue.Stc_InGoodsCartWCnt개 단위로 true로 변경
            for (int i = 0; i < Math.Min(StaticValue.Stc_InGoodsCartWCnt, ObcMainGoodsCartList.Count); i++)
            {
                ObcMainGoodsCartList[i].BlMainGoodsVis = true;
            }

            // 상품을 선택하면 항상 처음(보이는것) index를 가리키도록 함
            InMainGoodsCartCurrentIndex = Math.Min(StaticValue.Stc_InGoodsCartWCnt, ObcMainGoodsCartList.Count);
        }

        #endregion

        #region MainGoodsQuickBtn

        private ObservableCollection<MainGoodsQuickBtn> _obcMainGoodsQuickBtnList = new ObservableCollection<MainGoodsQuickBtn>();
        public ObservableCollection<MainGoodsQuickBtn> ObcMainGoodsQuickBtnList
        {
            get { return _obcMainGoodsQuickBtnList; }
            set
            {
                _obcMainGoodsQuickBtnList = value;
                Notify();
            }
        }

        private Command _goodsShortDisplayBtnsClick;
        public ICommand IcmdMainGoodsQuickBtnClk
        {
            get { return _goodsShortDisplayBtnsClick = new Command(OnIcmdMainGoodsQuickBtnClk); }
        }

        private void OnIcmdMainGoodsQuickBtnClk(object BtnNum)
        {
            // 상품의 인덱스는 StaticValue.Stc_InMainGoodsWCnt* StaticValue.Stc_InMainGoodsHCnt * 페이지로 구한후 StaticValue.Stc_InMainGoodsWCnt* StaticValue.Stc_InMainGoodsHCnt개를 보여준다
            InMainGoodsCurrentIndex = StaticValue.Stc_InMainGoodsWCnt * StaticValue.Stc_InMainGoodsHCnt * (int)BtnNum;

            // 전체 MainGoods의 Visible을 false로 변경
            foreach (var item in ObcMainGoodsList)
            {
                item.BlMainGoodsVis = false;
            }

            // MainGoods의 Visible을 StaticValue.Stc_InMainGoodsWCnt* StaticValue.Stc_InMainGoodsHCnt개 단위로 true로 변경
            for (int i = InMainGoodsCurrentIndex; i < Math.Min(InMainGoodsCurrentIndex + StaticValue.Stc_InMainGoodsWCnt * StaticValue.Stc_InMainGoodsHCnt, ObcMainGoodsList.Count); i++)
            {
                ObcMainGoodsList[i].BlMainGoodsVis = true;
            }

            InMainGoodsCurrentIndex += StaticValue.Stc_InMainGoodsWCnt * StaticValue.Stc_InMainGoodsHCnt;
        }

        private Command _icmdMainGoodsPageClkL;
        public ICommand IcmdMainGoodsPageClkL
        {
            get { return _icmdMainGoodsPageClkL = new Command(OnIcmdMainGoodsPageClkL); }
        }

        private void OnIcmdMainGoodsPageClkL(object obj)
        {
            // 첫 페이지가 아닐 경우
            if (InMainGoodsCurrentIndex > StaticValue.Stc_InMainGoodsWCnt * StaticValue.Stc_InMainGoodsHCnt)
            {
                // 전체 MainGoods의 Visible을 false로 변경
                foreach (var item in ObcMainGoodsList)
                {
                    item.BlMainGoodsVis = false;
                }

                InMainGoodsCurrentIndex -= StaticValue.Stc_InMainGoodsWCnt * StaticValue.Stc_InMainGoodsHCnt;

                // MainGoods의 Visible을 StaticValue.Stc_InMainGoodsWCnt* StaticValue.Stc_InMainGoodsHCnt개 단위로 true로 변경
                for (int i = InMainGoodsCurrentIndex - 1; i > InMainGoodsCurrentIndex - StaticValue.Stc_InMainGoodsWCnt * StaticValue.Stc_InMainGoodsHCnt - 1; i--)
                {
                    ObcMainGoodsList[i].BlMainGoodsVis = true;
                }

                // 상품 넘기는 버튼 클릭후에는, Quick버튼도 같이 변경
                // Quick버튼의 체크를 하나 왼쪽으로 옮김
                int index = 0;
                for (int i = 0; i < ObcMainGoodsQuickBtnList.Count; i++)
                {
                    if (ObcMainGoodsQuickBtnList[i].BlMainGoodsQuickBtnChecked == true)
                    {
                        index = i;
                        break;
                    }
                }
                ObcMainGoodsQuickBtnList[index].BlMainGoodsQuickBtnChecked = false;
                ObcMainGoodsQuickBtnList[index - 1].BlMainGoodsQuickBtnChecked = true;
            }
        }

        private Command _icmdMainGoodsPageClkR;
        public ICommand IcmdMainGoodsPageClkR
        {
            get { return _icmdMainGoodsPageClkR = new Command(OnIcmdMainGoodsPageClkR); }
        }

        private void OnIcmdMainGoodsPageClkR(object obj)
        {
            // 마지막 페이지가 아닐 경우
            if (InMainGoodsCurrentIndex < ObcMainGoodsList.Count)
            {
                // 전체 MainGoods의 Visible을 false로 변경
                foreach (var item in ObcMainGoodsList)
                {
                    item.BlMainGoodsVis = false;
                }

                // MainGoods의 Visible을 StaticValue.Stc_InMainGoodsWCnt* StaticValue.Stc_InMainGoodsHCnt개 단위로 true로 변경
                for (int i = InMainGoodsCurrentIndex; i < Math.Min(InMainGoodsCurrentIndex + StaticValue.Stc_InMainGoodsWCnt * StaticValue.Stc_InMainGoodsHCnt, ObcMainGoodsList.Count); i++)
                {
                    ObcMainGoodsList[i].BlMainGoodsVis = true;
                }

                InMainGoodsCurrentIndex += StaticValue.Stc_InMainGoodsWCnt * StaticValue.Stc_InMainGoodsHCnt;

                // 상품 넘기는 버튼 클릭후에는, Quick버튼도 같이 변경
                // Quick버튼의 체크를 하나 오른쪽으로 옮김
                int index = 0;
                for (int i = 0; i < ObcMainGoodsQuickBtnList.Count; i++)
                {
                    if (ObcMainGoodsQuickBtnList[i].BlMainGoodsQuickBtnChecked == true)
                    {
                        index = i;
                        break;
                    }
                }
                ObcMainGoodsQuickBtnList[index].BlMainGoodsQuickBtnChecked = false;
                ObcMainGoodsQuickBtnList[index + 1].BlMainGoodsQuickBtnChecked = true;
            }
        }
        #endregion

        #region MainGoodsCart
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

        private int _inMainGoodsCartCurrentIndex = 0;
        public int InMainGoodsCartCurrentIndex
        {
            get { return _inMainGoodsCartCurrentIndex; }
            set
            {
                _inMainGoodsCartCurrentIndex = value;
                Notify();
            }
        }

        private Command _icmdMainGoodsCartAllDelete;
        public ICommand IcmdMainGoodsCartAllDelete
        {
            get { return _icmdMainGoodsCartAllDelete = new Command(OnIcmdMainGoodsCartAllDelete); }
        }

        // 장바구니 상품 지우기
        private void OnIcmdMainGoodsCartAllDelete(object obj)
        {
            ObcMainGoodsCartList.Clear();
            InMainGoodsCartCurrentIndex = 0;
        }

        private Command _icmdMainGoodsCartPageClkL;
        public ICommand IcmdMainGoodsCartPageClkL
        {
            get { return _icmdMainGoodsCartPageClkL = new Command(OnIcmdMainGoodsCartPageClkL); }
        }

        // 장바구니 상품 페이지 이동
        private void OnIcmdMainGoodsCartPageClkL(object obj)
        {
            // 현재 index가 전체 상품의 개수보다 더 큰값을 가리키고 있다면 왼쪽으로 페이지를 이동할것이 있다는것
            if (InMainGoodsCartCurrentIndex > StaticValue.Stc_InGoodsCartWCnt)
            {
                ObcMainGoodsCartList[InMainGoodsCartCurrentIndex - StaticValue.Stc_InGoodsCartWCnt - 1].BlMainGoodsVis = true;
                ObcMainGoodsCartList[InMainGoodsCartCurrentIndex - 1].BlMainGoodsVis = false;

                InMainGoodsCartCurrentIndex--;
            }
        }

        private Command _icmdMainGoodsCartPageClkR;
        public ICommand IcmdMainGoodsCartPageClkR
        {
            get { return _icmdMainGoodsCartPageClkR = new Command(OnIcmdMainGoodsCartPageClkR); }
        }

        // 장바구니 상품 페이지 이동
        private void OnIcmdMainGoodsCartPageClkR(object GoodsSelectItem)
        {
            if (InMainGoodsCartCurrentIndex < ObcMainGoodsCartList.Count)
            {
                ObcMainGoodsCartList[InMainGoodsCartCurrentIndex].BlMainGoodsVis = true;
                ObcMainGoodsCartList[InMainGoodsCartCurrentIndex - StaticValue.Stc_InGoodsCartWCnt].BlMainGoodsVis = false;

                InMainGoodsCartCurrentIndex++;
            }
        }

        private Command _icmdMainGoodsCartGoCartConfirm;
        public ICommand IcmdMainGoodsCartGoCartConfirm
        {
            get { return _icmdMainGoodsCartGoCartConfirm = new Command(OnIcmdMainGoodsCartGoCartConfirm); }
        }

        // 주문확인 페이지로 이동
        private void OnIcmdMainGoodsCartGoCartConfirm(object obj)
        {
            // Main페이지 안보이게 하기
            BlMainDisplayVis = false;

            // 주문확인 페이지 보이게 하기
            WeakReferenceMessenger.Default.Send(new CustomMessage("GoodsConfirmDisplayViewModel-BlGoodsConfirmVis", true));

            WeakReferenceMessenger.Default.Send(new CustomMessage("GoodsConfirmDisplayViewModel-ObcMainGoodsCartList", ObcMainGoodsCartList));
        }

        private bool _blMainDisplayVis = false;
        public bool BlMainDisplayVis
        {
            get { return _blMainDisplayVis; }
            set
            {
                _blMainDisplayVis = value;
                Notify();
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
