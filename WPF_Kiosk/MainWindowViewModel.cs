using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using System.Windows.Threading;
using WPF_Kiosk.Model;

namespace WPF_Kiosk
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region 전역변수
        public static int Stc_InMainCategoryWCnt = 6;

        public static int Stc_InMainGoodsWCnt = 4;

        public static int Stc_InMainGoodsHCnt = 4;

        public static int Stc_InGoodsCartWCnt = 4;

        public static int Stc_InDetailCategoryHCnt = 4;

        public static int Stc_InDetailGoodsWCnt = 5;

        public static int Stc_InGoodsConfirmHCnt = 5;

        #endregion

        public MainWindowViewModel()
        {
            // 펼칠 필요 X
            #region Size
            // 윈도우 화면을 가져와서 비율에 따라 크기를 조절
            DblLockWinW = SystemParameters.PrimaryScreenWidth;
            DblLockWinH = SystemParameters.PrimaryScreenHeight;

            #endregion

            #region 테스트 담기
            
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
                            ObcAllMainGoodsList[i].ObcDetailCategoryList[j].ObcDetailGoodsList.Add(new DetailGoods() { StrDetailGoodsName = ObcAllMainGoodsList[i].ObcDetailCategoryList[j].StrDetailCategoryName + "상품" + k.ToString(), InDetailGoodsDiscount = 0, InDetailGoodsPrice = 100 + 100 * k, InDetailGoodsDetailCategoryNum = j , InDetailGoodsNum = k});
                        }
                    }
                    else if (j == 1)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            ObcAllMainGoodsList[i].ObcDetailCategoryList[j].ObcDetailGoodsList.Add(new DetailGoods() { StrDetailGoodsName = ObcAllMainGoodsList[i].ObcDetailCategoryList[j].StrDetailCategoryName + "상품" + k.ToString(), InDetailGoodsDiscount = 0, InDetailGoodsPrice = 100 + 100 * k, InDetailGoodsDetailCategoryNum = j, InDetailGoodsNum = k});
                        }
                    }
                    else if (j == 2)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            ObcAllMainGoodsList[i].ObcDetailCategoryList[j].ObcDetailGoodsList.Add(new DetailGoods() { StrDetailGoodsName = ObcAllMainGoodsList[i].ObcDetailCategoryList[j].StrDetailCategoryName + "상품" + k.ToString(), InDetailGoodsDiscount = 0, InDetailGoodsPrice = 100 + 100 * k, InDetailGoodsDetailCategoryNum = j, InDetailGoodsNum = k});
                        }
                    }
                    else if (j == 3)
                    {
                        for (int k = 0; k < 6; k++)
                        {
                            ObcAllMainGoodsList[i].ObcDetailCategoryList[j].ObcDetailGoodsList.Add(new DetailGoods() { StrDetailGoodsName = ObcAllMainGoodsList[i].ObcDetailCategoryList[j].StrDetailCategoryName + "상품" + k.ToString(), InDetailGoodsDiscount = 0, InDetailGoodsPrice = 100 + 100 * k, InDetailGoodsDetailCategoryNum = j, InDetailGoodsNum = k});
                        }
                    }
                    else if (j == 4)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            ObcAllMainGoodsList[i].ObcDetailCategoryList[j].ObcDetailGoodsList.Add(new DetailGoods() { StrDetailGoodsName = ObcAllMainGoodsList[i].ObcDetailCategoryList[j].StrDetailCategoryName + "상품" + k.ToString(), InDetailGoodsDiscount = 0, InDetailGoodsPrice = 100 + 100 * k, InDetailGoodsDetailCategoryNum = j, InDetailGoodsNum = k});
                        }
                    }
                    else if (j == 5)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            ObcAllMainGoodsList[i].ObcDetailCategoryList[j].ObcDetailGoodsList.Add(new DetailGoods() { StrDetailGoodsName = ObcAllMainGoodsList[i].ObcDetailCategoryList[j].StrDetailCategoryName + "상품" + k.ToString(), InDetailGoodsDiscount = 0, InDetailGoodsPrice = 100 + 100 * k, InDetailGoodsDetailCategoryNum = j, InDetailGoodsNum = k});
                        }
                    }

                    // 디테일 카테고리안에 디테일이 표시되는 인덱스
                    int index = Math.Min(Stc_InDetailGoodsWCnt, ObcAllMainGoodsList[i].ObcDetailCategoryList[j].InDetailGoodsCurrentIndex = ObcAllMainGoodsList[i].ObcDetailCategoryList[j].ObcDetailGoodsList.Count);
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

            // 초기에 보여지는 DetailShort버튼 생성
            SetDetailGoodsQuickBtns();

            #endregion



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
            DblLockWinW = arg.NewSize.Width;
            DblLockWinH = arg.NewSize.Height;
        }

        #endregion

        #region Lock
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
            BlMainDisplayVis = true;

            // 초기에 보여지는 데이터들
            SetMainGoodsMainCategory();
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
            BlMainDisplayVis = true;

            // 초기에 보여지는 데이터들
            SetMainGoodsMainCategory();
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

        #endregion

        #region MainTitle
        private Command _icmdMainTitleHomeBtnClk;
        public ICommand IcmdMainTitleHomeBtnClk
        {
            get { return _icmdMainTitleHomeBtnClk = new Command(OnIcmdMainTitleHomeBtnClk); }
        }

        private void OnIcmdMainTitleHomeBtnClk(object obj)
        {
            ObcMainGoodsCartList.Clear();

            BlLockVis = true;
            BlMainDisplayVis = false;
            BlDetailGoodsGridVis = false;
            BlGoodsConfirmVis = false;
        }

        #endregion

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
            if (InMainCatecoryCurrentIndex <= Stc_InMainCategoryWCnt)
            {
                return;
            }

            ObcMainCategoryList[InMainCatecoryCurrentIndex - 1].BlMainCategoryVis = false;
            ObcMainCategoryList[InMainCatecoryCurrentIndex - (Stc_InMainCategoryWCnt + 1)].BlMainCategoryVis = true;
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
            ObcMainCategoryList[InMainCatecoryCurrentIndex - Stc_InMainCategoryWCnt].BlMainCategoryVis = false;
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
            for (int i = 0; i < Math.Min(Stc_InMainGoodsWCnt* Stc_InMainGoodsHCnt, ObcMainGoodsList.Count); i++)
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
            int quotient = ObcMainGoodsList.Count / (Stc_InMainGoodsWCnt * Stc_InMainGoodsHCnt);  // 몫
            int remainder = ObcMainGoodsList.Count % (Stc_InMainGoodsWCnt * Stc_InMainGoodsHCnt); // 나머지

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
            // 초기에 보여지는 카테고리 Stc_InMainCategoryWCnt개
            for (int i = 0; i < Math.Min(Stc_InMainCategoryWCnt, ObcMainCategoryList.Count); i++)
            {
                ObcMainCategoryList[i].BlMainCategoryVis = true;
            }
            InMainCatecoryCurrentIndex = Stc_InMainCategoryWCnt;

            // 초기에 보여지는 상품 Stc_InMainGoodsWCnt* Stc_InMainGoodsHCnt개(카테고리 0번)
            ObcMainGoodsList.Clear();
            foreach (var allGoodsItem in ObcAllMainGoodsList)
            {
                if (allGoodsItem.InMainGoodsMainCategoryNum == 0)
                {
                    ObcMainGoodsList.Add(allGoodsItem);
                }
            }

            for (int i = 0; i < Math.Min(Stc_InMainGoodsWCnt * Stc_InMainGoodsHCnt, ObcMainGoodsList.Count); i++)
            {
                ObcMainGoodsList[i].BlMainGoodsVis = true;

                for (int j = 0; j < ObcMainGoodsList[i].ObcDetailCategoryList.Count; j++)
                {
                    // 디테일 카테고리는 전부 돌리면서, 담아야지, 디테일 상품의 display를 전체적으로 돌릴 수 있음
                    if (j < Stc_InDetailCategoryHCnt)
                    {
                        ObcMainGoodsList[i].ObcDetailCategoryList[j].BlDetailCategoryVis = true;
                    }
                    else
                    {
                        ObcMainGoodsList[i].ObcDetailCategoryList[j].BlDetailCategoryVis = false;
                    }

                    // 카데고리 디테일 n번의 디테일 개수
                    for (int k = 0; k < Math.Min(Stc_InDetailGoodsWCnt, ObcAllMainGoodsList[i].ObcDetailCategoryList[j].ObcDetailGoodsList.Count); k++)
                    {
                        if (j == 4)
                        {

                        }
                        ObcAllMainGoodsList[i].ObcDetailCategoryList[j].ObcDetailGoodsList[k].BlDetailGoodsVis = true;
                    }
                }
            }
            InMainGoodsCurrentIndex = Stc_InMainGoodsHCnt * Stc_InMainGoodsWCnt;
            InDetailCategoryCurrentIndex = Stc_InDetailCategoryHCnt;
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


            // 클릭한 상품이 디테일 상품을 가지고 있는 경우
            if (ClsMainGoodsSelected.ObcDetailCategoryList.Count > 0)
            {
                BlDetailGoodsGridVis = true;

                // 클릭항 상품에 해당하는 GoodsQuickBtn 담기
                SetDetailGoodsQuickBtns();
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
            if (ObcMainGoodsCartList.Count > Stc_InGoodsCartWCnt)
            {
                // 전체 CartGoods의 Visible을 false로 변경
                foreach (var item in ObcMainGoodsCartList)
                {
                    item.BlMainGoodsVis = false;
                }

                // CartGoods의 Visible을 Stc_InGoodsCartWCnt개 단위로 true로 변경
                for (int i = 0; i < Stc_InGoodsCartWCnt; i++)
                {
                    ObcMainGoodsCartList[ObcMainGoodsCartList.Count - 1 - i].BlMainGoodsVis = true;
                }
            }

            // 상품을 선택하면 항상 마지막 index를 가리키도록 함
            InMainGoodsCartCurrentIndex = ObcMainGoodsCartList.Count;
        }

        private void SetCartGoodsFirstVis()
        {
            // 전체 CartGoods의 Visible을 false로 변경
            foreach (var item in ObcMainGoodsCartList)
            {
                item.BlMainGoodsVis = false;
            }

            // MainGoodsCart의 Visible을 Stc_InGoodsCartWCnt개 단위로 true로 변경
            for (int i = 0; i < Math.Min(Stc_InGoodsCartWCnt, ObcMainGoodsCartList.Count); i++)
            {
                ObcMainGoodsCartList[i].BlMainGoodsVis = true;
            }

            // 상품을 선택하면 항상 처음(보이는것) index를 가리키도록 함
            InMainGoodsCartCurrentIndex = Math.Min(Stc_InGoodsCartWCnt, ObcMainGoodsCartList.Count);
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
            // 상품의 인덱스는 Stc_InMainGoodsWCnt* Stc_InMainGoodsHCnt * 페이지로 구한후 Stc_InMainGoodsWCnt* Stc_InMainGoodsHCnt개를 보여준다
            InMainGoodsCurrentIndex = Stc_InMainGoodsWCnt * Stc_InMainGoodsHCnt * (int)BtnNum;

            // 전체 MainGoods의 Visible을 false로 변경
            foreach (var item in ObcMainGoodsList)
            {
                item.BlMainGoodsVis = false;
            }

            // MainGoods의 Visible을 Stc_InMainGoodsWCnt* Stc_InMainGoodsHCnt개 단위로 true로 변경
            for (int i = InMainGoodsCurrentIndex; i < Math.Min(InMainGoodsCurrentIndex + Stc_InMainGoodsWCnt * Stc_InMainGoodsHCnt, ObcMainGoodsList.Count); i++)
            {
                ObcMainGoodsList[i].BlMainGoodsVis = true;
            }

            InMainGoodsCurrentIndex += Stc_InMainGoodsWCnt * Stc_InMainGoodsHCnt;
        }

        private Command _icmdMainGoodsPageClkL;
        public ICommand IcmdMainGoodsPageClkL
        {
            get { return _icmdMainGoodsPageClkL = new Command(OnIcmdMainGoodsPageClkL); }
        }

        private void OnIcmdMainGoodsPageClkL(object obj)
        {
            // 첫 페이지가 아닐 경우
            if (InMainGoodsCurrentIndex > Stc_InMainGoodsWCnt * Stc_InMainGoodsHCnt)
            {
                // 전체 MainGoods의 Visible을 false로 변경
                foreach (var item in ObcMainGoodsList)
                {
                    item.BlMainGoodsVis = false;
                }

                InMainGoodsCurrentIndex -= Stc_InMainGoodsWCnt * Stc_InMainGoodsHCnt;

                // MainGoods의 Visible을 Stc_InMainGoodsWCnt* Stc_InMainGoodsHCnt개 단위로 true로 변경
                for (int i = InMainGoodsCurrentIndex - 1; i > InMainGoodsCurrentIndex - Stc_InMainGoodsWCnt * Stc_InMainGoodsHCnt - 1; i--)
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

                // MainGoods의 Visible을 Stc_InMainGoodsWCnt* Stc_InMainGoodsHCnt개 단위로 true로 변경
                for (int i = InMainGoodsCurrentIndex; i < Math.Min(InMainGoodsCurrentIndex + Stc_InMainGoodsWCnt * Stc_InMainGoodsHCnt, ObcMainGoodsList.Count); i++)
                {
                    ObcMainGoodsList[i].BlMainGoodsVis = true;
                }

                InMainGoodsCurrentIndex += Stc_InMainGoodsWCnt * Stc_InMainGoodsHCnt;

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
            if (InMainGoodsCartCurrentIndex > Stc_InGoodsCartWCnt)
            {
                ObcMainGoodsCartList[InMainGoodsCartCurrentIndex - Stc_InGoodsCartWCnt - 1].BlMainGoodsVis = true;
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
                ObcMainGoodsCartList[InMainGoodsCartCurrentIndex - Stc_InGoodsCartWCnt].BlMainGoodsVis = false;

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
            BlGoodsConfirmVis = true;

            // GoodsConfirmQuickBtn 담기
            SetGoodsConfirmQuickBtns();

            // MainGoodsCart에 있는 Visible을 GoodsConfirmList 표현수만큼 다시 설정하기
            SetGoodsConfirmListVis();
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

        #region DetailGoods
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

        private int _inDetailCategoryCurrentIndex = 0;
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
            if (ClsMainGoodsSelected.ObcDetailCategoryList[(int)InMainCategoryNum].InDetailGoodsCurrentIndex <= Stc_InDetailGoodsWCnt)
            {
                return;
            }

            int CurrentIndex = ClsMainGoodsSelected.ObcDetailCategoryList[(int)InMainCategoryNum].InDetailGoodsCurrentIndex;
            ClsMainGoodsSelected.ObcDetailCategoryList[(int)InMainCategoryNum].ObcDetailGoodsList[CurrentIndex - 1].BlDetailGoodsVis = false;
            ClsMainGoodsSelected.ObcDetailCategoryList[(int)InMainCategoryNum].ObcDetailGoodsList[CurrentIndex - (Stc_InDetailGoodsWCnt + 1)].BlDetailGoodsVis = true;

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
            ClsMainGoodsSelected.ObcDetailCategoryList[(int)InMainCategoryNum].ObcDetailGoodsList[CurrentIndex - Stc_InDetailGoodsWCnt].BlDetailGoodsVis = false;

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
            if (InDetailCategoryCurrentIndex > Stc_InDetailCategoryHCnt)
            {
                // 전체 GoodsDetailCategory의 Visible을 false로 변경
                foreach (var item in ClsMainGoodsSelected.ObcDetailCategoryList)
                {
                    item.BlDetailCategoryVis = false;
                }

                InDetailCategoryCurrentIndex -= Stc_InDetailCategoryHCnt;

                // GoodsDetailCategory의 Visible을 InDetailCategoryCurrentIndex개 단위로 true로 변경
                for (int i = InDetailCategoryCurrentIndex - 1; i > InDetailCategoryCurrentIndex - Stc_InDetailCategoryHCnt - 1; i--)
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
                for (int i = InDetailCategoryCurrentIndex; i < Math.Min(InDetailCategoryCurrentIndex + Stc_InDetailCategoryHCnt, ClsMainGoodsSelected.ObcDetailCategoryList.Count); i++)
                {
                    ClsMainGoodsSelected.ObcDetailCategoryList[i].BlDetailCategoryVis = true;
                }

                InDetailCategoryCurrentIndex += Stc_InDetailCategoryHCnt;

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
            int quotient = ClsMainGoodsSelected.ObcDetailCategoryList.Count / Stc_InDetailCategoryHCnt;  // 몫
            int remainder = ClsMainGoodsSelected.ObcDetailCategoryList.Count % Stc_InDetailCategoryHCnt; // 나머지

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
            // 상품디테일 카테고리 인덱스는 Stc_InDetailCategoryHCnt * 페이지로 구한다
            InDetailCategoryCurrentIndex = Stc_InDetailCategoryHCnt * (int)obj;

            // 클릭한 상품의 카테고리의 Visible을 false로 변경
            foreach (var item in ClsMainGoodsSelected.ObcDetailCategoryList)
            {
                item.BlDetailCategoryVis = false;
            }

            // ClsMainGoodsSelected.ObcDetailCategoryList의 Visible을 InDetailCategoryCurrentIndex개 단위로 true로 변경
            for (int i = InDetailCategoryCurrentIndex; i < Math.Min(InDetailCategoryCurrentIndex + Stc_InDetailCategoryHCnt, ClsMainGoodsSelected.ObcDetailCategoryList.Count); i++)
            {
                ClsMainGoodsSelected.ObcDetailCategoryList[i].BlDetailCategoryVis = true;
            }

            InDetailCategoryCurrentIndex += Stc_InDetailCategoryHCnt;
        }

        #endregion

        private Command _icmdDetailGoodsGridClose;
        public ICommand IcmdDetailGoodsGridClose
        {
            get { return _icmdMainGoodsClk = new Command(OnIcmdDetailGoodsGridClose); }
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
            ObcMainGoodsCartList.Add(ClsMainGoodsSelected);

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

        #endregion

        #region MainGoodsConfirm
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
            int quotient = ObcMainGoodsCartList.Count / Stc_InGoodsConfirmHCnt;  // 몫
            int remainder = ObcMainGoodsCartList.Count % Stc_InGoodsConfirmHCnt; // 나머지

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
            if (InGoodsConfirmCurrentIndex > Stc_InGoodsConfirmHCnt)
            {
                // 전체 MainGoodsCartList의 Visible을 false로 변경
                foreach (var item in ObcMainGoodsCartList)
                {
                    item.BlMainGoodsVis = false;
                }

                InGoodsConfirmCurrentIndex -= Stc_InGoodsConfirmHCnt;

                // MainGoodsCartList의 Visible을 Stc_InGoodsConfirmHCnt개 단위로 true로 변경
                for (int i = InGoodsConfirmCurrentIndex - 1; i > InGoodsConfirmCurrentIndex - Stc_InGoodsConfirmHCnt - 1; i--)
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

                // MainGoodsCartList의 Visible을 Stc_InGoodsConfirmHCnt개 단위로 true로 변경
                for (int i = InGoodsConfirmCurrentIndex; i < Math.Min(InGoodsConfirmCurrentIndex + Stc_InGoodsConfirmHCnt, ObcMainGoodsCartList.Count); i++)
                {
                    ObcMainGoodsCartList[i].BlMainGoodsVis = true;
                }

                InGoodsConfirmCurrentIndex += Stc_InGoodsConfirmHCnt;

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

            // ObcMainGoodsCartList의 Visible을 Stc_InGoodsConfirmHCnt개 단위로 true로 변경
            for (int i = 0; i < Math.Min(Stc_InGoodsConfirmHCnt, ObcMainGoodsCartList.Count); i++)
            {
                ObcMainGoodsCartList[i].BlMainGoodsVis = true;
            }
            InGoodsConfirmCurrentIndex = Stc_InGoodsConfirmHCnt;
        }

        private Command _icmdGoodsConfirmQuickBtnClk;
        public ICommand IcmdGoodsConfirmQuickBtnClk
        {
            get { return _icmdGoodsConfirmQuickBtnClk = new Command(OnIcmdGoodsConfirmQuickBtnClk); }
        }

        private void OnIcmdGoodsConfirmQuickBtnClk(object obj)
        {
            // InGoodsConfirmCurrentIndex 인덱스는 Stc_InGoodsConfirmHCnt * 페이지로 구한다
            InGoodsConfirmCurrentIndex = Stc_InGoodsConfirmHCnt * (int)obj;

            // GoodsConfirmList의 전체 Visible을 false로 변경
            foreach (var item in ObcMainGoodsCartList)
            {
                item.BlMainGoodsVis = false;
            }

            // GoodsConfirmList의 Visible을 Stc_InGoodsConfirmHCnt개 단위로 true로 변경
            for (int i = InGoodsConfirmCurrentIndex; i < Math.Min(InGoodsConfirmCurrentIndex + Stc_InGoodsConfirmHCnt, ObcMainGoodsCartList.Count); i++)
            {
                ObcMainGoodsCartList[i].BlMainGoodsVis = true;
            }

            InGoodsConfirmCurrentIndex += Stc_InGoodsConfirmHCnt;
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
            BlMainDisplayVis = true;

            // MainGoodsCart의 Visible을 Stc_InGoodsCartWCnt개 단위로 true로 변경
            // 첫번째 담긴 상품이 보이도록함
            SetCartGoodsFirstVis();
        }
        #endregion

        #region AdminManager
        private DispatcherTimer DpctAdminManager = new DispatcherTimer();
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

        private Command _icmdWindowGoAdminManager;
        public ICommand IcmdWindowGoAdminManager
        {
            get { return _icmdWindowGoAdminManager = new Command(OnIcmdWindowGoAdminManager); }
        }

        private async void OnIcmdWindowGoAdminManager(object obj)
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
                BlAdminManagerVis = true;
                InClickCount = 0;

                // 통신하여 아이디 비밀번호 가져오기
                // Get방식
                try
                {
                    // HttpClient 인스턴스 생성
                    using (HttpClient client = new HttpClient())
                    {
                        // GET 요청 보내기
                        HttpResponseMessage response = await client.GetAsync("http://220.118.53.92:5001/IDPW");

                        // 응답 확인
                        if (response.IsSuccessStatusCode)
                        {
                            string content = await response.Content.ReadAsStringAsync();
                        }
                        else
                        {
                            MessageBox.Show($"HTTP 오류 코드: {response.StatusCode}", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"오류 발생: {ex.Message}", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void DpctAdminManager_Tick(object? sender, EventArgs e)
        {
            InClickCount = 0;
            DpctAdminManager.Stop();
        }


        private bool _blAdminManagerVis = false;
        public bool BlAdminManagerVis
        {
            get { return _blAdminManagerVis; }
            set
            {
                _blAdminManagerVis = value;
                Notify();
            }
        }

        #endregion

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
