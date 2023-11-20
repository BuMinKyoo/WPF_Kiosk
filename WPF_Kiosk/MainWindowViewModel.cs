using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using WPF_Kiosk.Model;

namespace WPF_Kiosk
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region 전역변수
        // 카테고리의 전체 개수
        public static int StaticCategoryItemCnt = 6;

        // 상품 가로 개수
        public static int StaticGoodsItemsWidthCnt = 4;

        // 상품 세로 개수
        public static int StaticGoodsItemsHightCnt = 4;

        // 장바구니 가로 개수
        public static int StaticGoodsSelectWidthCnt = 4;

        #endregion

        public MainWindowViewModel()
        {
            // 펼칠 필요 X
            #region Size
            // 윈도우 화면을 가져와서 비율에 따라 크기를 조절
            WindowWidth = SystemParameters.PrimaryScreenWidth;
            WindowHight = SystemParameters.PrimaryScreenHeight;

            ConponentSizeChange();

            #endregion

            #region AllGoodsItems, GoodsItems 테스트 담기
            for (int i = 0; i < 10; i++)
            {
                AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 1, GoodsName = "카테1상품" + i.ToString(), GoodsDiscount = 0, GoodsPrice = 1000 + 1000 * i, });
            }

            for (int i = 0; i < 20; i++)
            {
                AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 2, GoodsName = "카테2상품" + i.ToString(), GoodsDiscount = 0, GoodsPrice = 1000 + 1000 * i, });
            }

            for (int i = 0; i < 40; i++)
            {
                AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "카테3상품" + i.ToString(), GoodsDiscount = 0, GoodsPrice = 1000 + 1000 * i, });
            }

            // 초기에 보여지는 상품 StaticGoodsItemsWidthCnt* StaticGoodsItemsHightCnt개(카테고리 1번)
            foreach (var allGoodsItem in AllGoodsItems)
            {
                if (allGoodsItem.GoodsCategoryNum == 1)
                {
                    GoodsItems.Add(allGoodsItem);
                }
            }
           
            for (int i = 0; i < Math.Min(StaticGoodsItemsWidthCnt * StaticGoodsItemsHightCnt, GoodsItems.Count); i++)
            {
                GoodsItems[i].GoodsDisplay = true;
                GoodsItemCurrentIndex++;
            }
            #endregion

            #region Category테스트
            for (int i = 1; i < 12; i++)
            {
                Categorys.Add(new Category() { CategoryNum = i, CategoryName = i.ToString() });
            }

            // 초기에 보여지는 카테고리 StaticCategoryItemCnt개
            for (int i = 0; i < StaticCategoryItemCnt; i++)
            {
                Categorys[i].CategoryDisplay = true;
                CatecoryCurrentIndex++;
            }
            #endregion

            // 초기에 보여지는 Short버튼 생성
            GetGoodsShortDisplayBtns();

        }

        // 컴포넌트 들의 모든 사이즈 조절
        #region ConponentSizeChange
        private void ConponentSizeChange()
        {
            // 6으로 나누는 이유는, 전체 크기가
            //< Grid.RowDefinitions >
            //< RowDefinition Height = "0.5*" />
            //< RowDefinition Height = "0.3*" />
            //< RowDefinition Height = "4*" />
            //< RowDefinition Height = "0.3*" />
            //< RowDefinition Height = "0.9*" />
            //</ Grid.RowDefinitions >
            // 합해서 6이기 때문

            // 카테고리 크기를 화면 비율에 따라 조절
            CategoryWidth = (WindowWidth - 200) / StaticCategoryItemCnt; // 양 옆 < > 버튼을 제외한것
            CategoryHight = (WindowHight * 0.3 / 6); // Grid비율에 따라 변경 되는 값

            // 상품의 크기를 화면 비율에 따라 조절
            GoodsItemsWidth = WindowWidth / StaticGoodsItemsWidthCnt;
            GoodsItemsHight = (WindowHight * 4 / 6) / StaticGoodsItemsHightCnt; // Grid비율에 따라 변경 되는 값

            // KioskGoodsSelectDisplay의 크기를 화면 비율에 따라 조절
            GoodsShortDisplayHight = WindowHight * 0.3 / 6;

            // KioskGoodsSelects의 크기를 화면 비율에 따라 조절
            GoodsSelectsWidth = (WindowWidth - (30 * 2)) * 0.6 / StaticGoodsSelectWidthCnt; // 0.6 = 6/10
            GoodsSelectsHight = ((WindowHight * 0.9 / 6) - (30 * 2)) * 0.83 ;  // 0.83 = 5/6

            GoodsDetailGridWidth = WindowWidth * 0.8;
            GoodsDetailGridHight = WindowHight * 0.8;
        }

        private Command _windowSizeEvent;
        public ICommand WindowSizeEvent
        {
            get { return _windowSizeEvent = new Command(OnWindowSizeEvent); }
        }

        private void OnWindowSizeEvent(object obj)
        {
            var arg = obj as SizeChangedEventArgs;
            if (arg == null)
            {
                return;
            }

            #region Size
            // 윈도우 화면을 가져와서 비율에 따라 크기를 조절
            WindowWidth = arg.NewSize.Width;
            WindowHight = arg.NewSize.Height;

            ConponentSizeChange();

            #endregion
        }

        #endregion

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

        // KioskLock화면에 마우스 업 클릭시 작동
        private void OnKioskLockMouseUp(object obj)
        {
            KioskLockVisibility = false;
        }

        // OnKioskLockMouseUp과 같은 기능이지만, 버튼으로 command연결
        private Command _kioskLockBtnClick;
        public ICommand KioskLockBtnClick
        {
            get { return _kioskLockBtnClick = new Command(OnKioskLockBtnClick); }
        }

        private void OnKioskLockBtnClick(object obj)
        {
            KioskLockVisibility = false;
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

        #endregion

        #region KioskCategory
        private ObservableCollection<Category> _categorys = new ObservableCollection<Category>();
        public ObservableCollection<Category> Categorys
        {
            get { return _categorys; }
            set
            {
                _categorys = value;
                Notify("Categorys");
            }
        }

        private double _categoryWidth;
        public double CategoryWidth
        {
            get { return _categoryWidth; }
            set
            {
                _categoryWidth = value;
                Notify("CategoryWidth");
            }
        }

        private double _categoryHight;
        public double CategoryHight
        {
            get { return _categoryHight; }
            set
            {
                _categoryHight = value;
                Notify("CategoryHight");
            }
        }

        private int _catecoryCurrentIndex = 0;
        public int CatecoryCurrentIndex
        {
            get { return _catecoryCurrentIndex; }
            set
            {
                _catecoryCurrentIndex = value;
                Notify("CatecoryCurrentIndex");
            }
        }

        private Command _categoryClkLeft;
        public ICommand CategoryClkLeft
        {
            get { return _categoryClkLeft = new Command(OnCategoryClkLeft); }
        }

        private void OnCategoryClkLeft(object obj)
        {
            if (CatecoryCurrentIndex == StaticCategoryItemCnt)
            {
                return;
            }

            Categorys[CatecoryCurrentIndex - 1].CategoryDisplay = false;
            Categorys[CatecoryCurrentIndex - (StaticCategoryItemCnt + 1)].CategoryDisplay = true;
            CatecoryCurrentIndex--;
        }

        private Command _categoryClkRight;
        public ICommand CategoryClkRight
        {
            get { return _categoryClkRight = new Command(OnCategoryClkRight); }
        }

        private void OnCategoryClkRight(object obj)
        {
            if (CatecoryCurrentIndex == Categorys.Count)
            {
                return;
            }

            Categorys[CatecoryCurrentIndex].CategoryDisplay = true;
            Categorys[CatecoryCurrentIndex - StaticCategoryItemCnt].CategoryDisplay = false;
            CatecoryCurrentIndex++;
        }


        private Command _categoryClick;
        public ICommand CategoryClick
        {
            get { return _categoryClick = new Command(OnCategoryClick); }
        }

        private void OnCategoryClick(object obj)
        {
            //선택된 Category에 해당되는 GoodsItem담기
            GoodsItems.Clear();
            if (obj is string categoryStr) // obj가 string인 경우
            {
                foreach (var allGoodsItem in AllGoodsItems)
                {
                    if (int.TryParse(categoryStr, out int categoryNum))
                    {
                        if (allGoodsItem.GoodsCategoryNum == categoryNum)
                        {
                            GoodsItems.Add(allGoodsItem);
                        }
                    }
                    // 변환 실패 시 처리할 로직 필요하면 추가
                }
            }
            else if (obj is int categoryNum) // obj가 이미 int인 경우
            {
                foreach (var allGoodsItem in AllGoodsItems)
                {
                    if (allGoodsItem.GoodsCategoryNum == categoryNum)
                    {
                        GoodsItems.Add(allGoodsItem);
                    }
                }
            }

            // 인덱스 초기화 작업 및 상품 display
            GoodsItemCurrentIndex = 0;
            for (int i = 0; i < Math.Min(StaticGoodsItemsWidthCnt* StaticGoodsItemsHightCnt, GoodsItems.Count); i++)
            {
                GoodsItems[i].GoodsDisplay = true;
                GoodsItemCurrentIndex++;
            }

            GetGoodsShortDisplayBtns();
        }

        // 카테고리 클릭시, short 상품 버튼도 다시 생성
        private void GetGoodsShortDisplayBtns()
        {
            GoodsShortDisplayBtns.Clear();
            int quotient = GoodsItems.Count / (StaticGoodsItemsWidthCnt * StaticGoodsItemsHightCnt);  // 몫
            int remainder = GoodsItems.Count % (StaticGoodsItemsWidthCnt * StaticGoodsItemsHightCnt); // 나머지

            // Short버튼 수 구하기
            int GoodsShortDisplayBtnsCnt = 0;
            if (remainder > 0)
            {
                GoodsShortDisplayBtnsCnt = quotient + 1; // 나머지가 있다면 Short버튼 한개를 더 만들어야됨
            }
            else
            {
                GoodsShortDisplayBtnsCnt = quotient; // 나머지가 없다면 Short버튼은 정확히 페이지 수많큼 있으면 됨
            }

            for (int i = 0; i < GoodsShortDisplayBtnsCnt; i++)
            {
                if (i == 0) // 첫번째 버튼은 체크
                {
                    GoodsShortDisplayBtns.Add(new GoodsShortDisplayBtn() { BtnNum = i, BtnChecked = true });
                }
                else
                {
                    GoodsShortDisplayBtns.Add(new GoodsShortDisplayBtn() { BtnNum = i, BtnChecked = false });
                }
            }
        }
        #endregion

        #region KioskGoods
        private ObservableCollection<GoodsItems> _allGoodsItems = new ObservableCollection<GoodsItems>();
        public ObservableCollection<GoodsItems> AllGoodsItems
        {
            get { return _allGoodsItems; }
            set
            {
                _allGoodsItems = value;
                Notify("AllGoodsItems");
            }
        }

        private ObservableCollection<GoodsItems> _goodsItems = new ObservableCollection<GoodsItems>();
        public ObservableCollection<GoodsItems> GoodsItems
        {
            get { return _goodsItems; }
            set
            {
                _goodsItems = value;
                Notify("GoodsItems");
            }
        }

        private double _goodsItemsWidth;
        public double GoodsItemsWidth
        {
            get { return _goodsItemsWidth; }
            set
            {
                _goodsItemsWidth = value;
                Notify("GoodsItemsWidth");
            }
        }

        private double _goodsItemsHight;
        public double GoodsItemsHight
        {
            get { return _goodsItemsHight; }
            set
            {
                _goodsItemsHight = value;
                Notify("GoodsItemsHight");
            }
        }

        private int _goodsItemCurrentIndex = 0;
        public int GoodsItemCurrentIndex
        {
            get { return _goodsItemCurrentIndex; }
            set
            {
                _goodsItemCurrentIndex = value;
                Notify("GoodsItemCurrentIndex");
            }
        }

        private Command _goodsItemClick;
        public ICommand GoodsItemClick
        {
            get { return _goodsItemClick = new Command(OnGoodsItemClick); }
        }

        // 클릭한 상품의 데이터를 받아서 상품 담기
        private void OnGoodsItemClick(object GoodsSelectItem)
        {
            var GoodsArray = GoodsSelectItem as object[];
            GoodsSelects.Add(new GoodsItems() { GoodsName = (string)GoodsArray[0], GoodsPrice = (int)GoodsArray[1], GoodsCategoryNum = (int)GoodsArray[2], GoodsDisplay =  true});

            // 상품을 클릭한 후 담고난 뒤, 선택된 상품의 display의 true, false를 조절
            GoodsSelectDisplay();
        }

        private void GoodsSelectDisplay()
        {
            if (GoodsSelects.Count > StaticGoodsSelectWidthCnt)
            {
                // 전체 GoodsSelects의 Visible을 false로 변경
                foreach (var item in GoodsSelects)
                {
                    item.GoodsDisplay = false;
                }

                // GoodsSelects의 Visible을 StaticGoodsSelectWidthCnt개 단위로 true로 변경
                for (int i = 0; i < StaticGoodsSelectWidthCnt; i++)
                {
                    GoodsSelects[GoodsSelects.Count - 1 - i].GoodsDisplay = true;
                }
            }

            // 상품을 선택하면 항상 마지막 index를 가리키도록 함
            GoodsSelectCurrentIndex = GoodsSelects.Count;
        }

        #endregion

        #region KioskGoodsShortDisplay
        private double _goodsSelectDisplayHight;
        public double GoodsShortDisplayHight
        {
            get { return _goodsSelectDisplayHight; }
            set
            {
                _goodsSelectDisplayHight = value;
                Notify("GoodsShortDisplayHight");
            }
        }

        private ObservableCollection<GoodsShortDisplayBtn> _goodsShortDisplayBtns = new ObservableCollection<GoodsShortDisplayBtn>();
        public ObservableCollection<GoodsShortDisplayBtn> GoodsShortDisplayBtns
        {
            get { return _goodsShortDisplayBtns; }
            set
            {
                _goodsShortDisplayBtns = value;
                Notify("GoodsShortDisplayBtns");
            }
        }

        private Command _onEvent;
        public ICommand OnEvent
        {
            get { return _onEvent = new Command(OnOnEvent); }
        }

        private void OnOnEvent(object BtnNum)
        {
            // 상품의 인덱스는 StaticGoodsItemsWidthCnt* StaticGoodsItemsHightCnt * 페이지로 구한후 StaticGoodsItemsWidthCnt* StaticGoodsItemsHightCnt개를 보여준다
            GoodsItemCurrentIndex = StaticGoodsItemsWidthCnt * StaticGoodsItemsHightCnt * (int)BtnNum;

            // 전체 GoodsItems의 Visible을 false로 변경
            foreach (var item in GoodsItems)
            {
                item.GoodsDisplay = false;
            }

            // GoodsItems의 Visible을 StaticGoodsItemsWidthCnt* StaticGoodsItemsHightCnt개 단위로 true로 변경
            for (int i = GoodsItemCurrentIndex; i < Math.Min(GoodsItemCurrentIndex + StaticGoodsItemsWidthCnt * StaticGoodsItemsHightCnt, GoodsItems.Count); i++)
            {
                GoodsItems[i].GoodsDisplay = true;
            }

            GoodsItemCurrentIndex += StaticGoodsItemsWidthCnt * StaticGoodsItemsHightCnt;
        }

        private Command _goodsPageClickLeft;
        public ICommand GoodsPageClickLeft
        {
            get { return _goodsPageClickLeft = new Command(OnGoodsPageClickLeft); }
        }

        private void OnGoodsPageClickLeft(object obj)
        {
            // 첫 페이지가 아닐 경우
            if (GoodsItemCurrentIndex > StaticGoodsItemsWidthCnt * StaticGoodsItemsHightCnt)
            {
                // 전체 GoodsItems의 Visible을 false로 변경
                foreach (var item in GoodsItems)
                {
                    item.GoodsDisplay = false;
                }

                GoodsItemCurrentIndex -= StaticGoodsItemsWidthCnt * StaticGoodsItemsHightCnt;

                // GoodsItems의 Visible을 StaticGoodsItemsWidthCnt* StaticGoodsItemsHightCnt개 단위로 true로 변경
                for (int i = GoodsItemCurrentIndex - 1; i > GoodsItemCurrentIndex - StaticGoodsItemsWidthCnt * StaticGoodsItemsHightCnt - 1; i--)
                {
                    GoodsItems[i].GoodsDisplay = true;
                }

                // 상품 넘기는 버튼 클릭후에는, short버튼도 같이 변경
                // Short버튼의 체크를 하나 왼쪽으로 옮김
                int index = 0;
                for (int i = 0; i < GoodsShortDisplayBtns.Count; i++)
                {
                    if (GoodsShortDisplayBtns[i].BtnChecked == true)
                    {
                        index = i;
                        break;
                    }
                }
                GoodsShortDisplayBtns[index].BtnChecked = false;
                GoodsShortDisplayBtns[index - 1].BtnChecked = true;
            }
        }

        private Command _goodsPageClickRight;
        public ICommand GoodsPageClickRight
        {
            get { return _goodsPageClickRight = new Command(OnGoodsPageClickRight); }
        }

        private void OnGoodsPageClickRight(object obj)
        {
            // 마지막 페이지가 아닐 경우
            if (GoodsItemCurrentIndex < GoodsItems.Count)
            {
                // 전체 GoodsItems의 Visible을 false로 변경
                foreach (var item in GoodsItems)
                {
                    item.GoodsDisplay = false;
                }


                // GoodsItems의 Visible을 StaticGoodsItemsWidthCnt* StaticGoodsItemsHightCnt개 단위로 true로 변경
                for (int i = GoodsItemCurrentIndex; i < Math.Min(GoodsItemCurrentIndex + StaticGoodsItemsWidthCnt * StaticGoodsItemsHightCnt, GoodsItems.Count); i++)
                {
                    GoodsItems[i].GoodsDisplay = true;
                }

                GoodsItemCurrentIndex += StaticGoodsItemsWidthCnt * StaticGoodsItemsHightCnt;

                // 상품 넘기는 버튼 클릭후에는, short버튼도 같이 변경
                // Short버튼의 체크를 하나 오른쪽으로 옮김
                int index = 0;
                for (int i = 0; i < GoodsShortDisplayBtns.Count; i++)
                {
                    if (GoodsShortDisplayBtns[i].BtnChecked == true)
                    {
                        index = i;
                        break;
                    }
                }
                GoodsShortDisplayBtns[index].BtnChecked = false;
                GoodsShortDisplayBtns[index + 1].BtnChecked = true;
            }
        }
        #endregion

        #region KioskGoodsSelects
        private ObservableCollection<GoodsItems> _goodsSelects = new ObservableCollection<GoodsItems>();
        public ObservableCollection<GoodsItems> GoodsSelects
        {
            get { return _goodsSelects; }
            set
            {
                _goodsSelects = value;
                Notify("GoodsSelects");
            }
        }

        private double _goodsSelectsWidth;
        public double GoodsSelectsWidth
        {
            get { return _goodsSelectsWidth; }
            set
            {
                _goodsSelectsWidth = value;
                Notify("GoodsSelectsWidth");
            }
        }

        private double _goodsSelectsHight;
        public double GoodsSelectsHight
        {
            get { return _goodsSelectsHight; }
            set
            {
                _goodsSelectsHight = value;
                Notify("GoodsSelectsHight");
            }
        }

        private int _goodsSelectCurrentIndex = 0;
        public int GoodsSelectCurrentIndex
        {
            get { return _goodsSelectCurrentIndex; }
            set
            {
                _goodsSelectCurrentIndex = value;
                Notify("GoodsSelectCurrentIndex");
            }
        }

        private Command _deleteGoodsSelectItems;
        public ICommand DeleteGoodsSelectItems
        {
            get { return _deleteGoodsSelectItems = new Command(OnDeleteGoodsSelectItems); }
        }

        // 장바구니 상품 지우기
        private void OnDeleteGoodsSelectItems(object GoodsSelectItem)
        {
            GoodsSelects.Clear();
            GoodsSelectCurrentIndex = 0;
        }

        private Command _goodsSelectsPageClickLeft;
        public ICommand GoodsSelectsPageClickLeft
        {
            get { return _goodsSelectsPageClickLeft = new Command(OnGoodsSelectsPageClickLeft); }
        }

        // 장바구니 상품 페이지 이동
        private void OnGoodsSelectsPageClickLeft(object GoodsSelectItem)
        {
            // 현재 index가 전체 상품의 개수보다 더 큰값을 가리키고 있다면 왼쪽으로 페이지를 이동할것이 있다는것
            if (GoodsSelectCurrentIndex > StaticGoodsSelectWidthCnt)
            {
                GoodsSelects[GoodsSelectCurrentIndex - StaticGoodsSelectWidthCnt - 1].GoodsDisplay = true;
                GoodsSelects[GoodsSelectCurrentIndex - 1].GoodsDisplay = false;

                GoodsSelectCurrentIndex--;
            }
        }

        private Command _goodsSelectsPageClickRight;
        public ICommand GoodsSelectsPageClickRight
        {
            get { return _goodsSelectsPageClickRight = new Command(OnGoodsSelectsPageClickRight); }
        }

        // 장바구니 상품 페이지 이동
        private void OnGoodsSelectsPageClickRight(object GoodsSelectItem)
        {
            if (GoodsSelectCurrentIndex < GoodsSelects.Count)
            {
                GoodsSelects[GoodsSelectCurrentIndex].GoodsDisplay = true;
                GoodsSelects[GoodsSelectCurrentIndex - StaticGoodsSelectWidthCnt].GoodsDisplay = false;

                GoodsSelectCurrentIndex++;
            }
        }

        #endregion

        #region KioskGoodsDetail
        private double _goodsDetailGridWidth;
        public double GoodsDetailGridWidth
        {
            get { return _goodsDetailGridWidth; }
            set
            {
                _goodsDetailGridWidth = value;
                Notify("GoodsDetailGridWidth");
            }
        }

        private double _goodsDetailGridHight;
        public double GoodsDetailGridHight
        {
            get { return _goodsDetailGridHight; }
            set
            {
                _goodsDetailGridHight = value;
                Notify("GoodsDetailGridHight");
            }
        }

        #endregion

        // 펼칠 필요 X
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
