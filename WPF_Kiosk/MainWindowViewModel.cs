using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WPF_Kiosk.Model;

namespace WPF_Kiosk
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
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
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 1, GoodsName = "1", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 1, GoodsName = "2", Discount = "0", GoodsPrice = 10000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 1, GoodsName = "3", Discount = "0", GoodsPrice = 15000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 1, GoodsName = "4", Discount = "0", GoodsPrice = 2000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 1, GoodsName = "5", Discount = "0", GoodsPrice = 2000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 1, GoodsName = "13", Discount = "0", GoodsPrice = 2000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 1, GoodsName = "14", Discount = "0", GoodsPrice = 3000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 1, GoodsName = "15", Discount = "0", GoodsPrice = 4000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 1, GoodsName = "16", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 1, GoodsName = "17", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 2, GoodsName = "18", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 2, GoodsName = "19", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 2, GoodsName = "20", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 2, GoodsName = "21", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 2, GoodsName = "22", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 2, GoodsName = "23", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 2, GoodsName = "24", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 2, GoodsName = "25", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 2, GoodsName = "26", Discount = "0", GoodsPrice = 10000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 2, GoodsName = "27", Discount = "0", GoodsPrice = 15000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 2, GoodsName = "28", Discount = "0", GoodsPrice = 2000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 2, GoodsName = "29", Discount = "0", GoodsPrice = 2000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 2, GoodsName = "30", Discount = "0", GoodsPrice = 2000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 2, GoodsName = "31", Discount = "0", GoodsPrice = 3000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 2, GoodsName = "32", Discount = "0", GoodsPrice = 3000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 2, GoodsName = "33", Discount = "0", GoodsPrice = 4000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 2, GoodsName = "34", Discount = "0", GoodsPrice = 4000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 2, GoodsName = "35", Discount = "0", GoodsPrice = 4000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 2, GoodsName = "36", Discount = "0", GoodsPrice = 1000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 2, GoodsName = "37", Discount = "0", GoodsPrice = 2000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "38", Discount = "0", GoodsPrice = 3000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "39", Discount = "0", GoodsPrice = 4000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "40", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "41", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "42", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "43", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "44", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "45", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "46", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "47", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "48", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "49", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "50", Discount = "0", GoodsPrice = 10000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "51", Discount = "0", GoodsPrice = 15000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "52", Discount = "0", GoodsPrice = 2000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "53", Discount = "0", GoodsPrice = 2000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "54", Discount = "0", GoodsPrice = 2000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "55", Discount = "0", GoodsPrice = 3000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "56", Discount = "0", GoodsPrice = 3000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "57", Discount = "0", GoodsPrice = 4000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "58", Discount = "0", GoodsPrice = 4000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "59", Discount = "0", GoodsPrice = 4000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "60", Discount = "0", GoodsPrice = 1000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "61", Discount = "0", GoodsPrice = 2000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "62", Discount = "0", GoodsPrice = 3000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "63", Discount = "0", GoodsPrice = 4000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "64", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "65", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "66", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "67", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "68", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "69", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "70", Discount = "0", GoodsPrice = 5000 });
            AllGoodsItems.Add(new GoodsItems() { GoodsCategoryNum = 3, GoodsName = "71", Discount = "0", GoodsPrice = 5000 });

            // 초기에 보여지는 상품 16개(카테고리 1번)
            foreach (var allGoodsItem in AllGoodsItems)
            {
                if (allGoodsItem.GoodsCategoryNum == 1)
                {
                    GoodsItems.Add(allGoodsItem);
                }
            }
           
            for (int i = 0; i < Math.Min(16, GoodsItems.Count); i++)
            {
                GoodsItems[i].GoodsDisplay = true;
                GoodsItemCurrentIndex++;
            }
            #endregion

            #region Category테스트
            Categorys.Add(new Category() { CategoryNum = 1, CategoryName = "1" });
            Categorys.Add(new Category() { CategoryNum = 2, CategoryName = "2" });
            Categorys.Add(new Category() { CategoryNum = 3, CategoryName = "3" });
            Categorys.Add(new Category() { CategoryNum = 4, CategoryName = "4" });
            Categorys.Add(new Category() { CategoryNum = 5, CategoryName = "5" });
            Categorys.Add(new Category() { CategoryNum = 6, CategoryName = "6" });
            Categorys.Add(new Category() { CategoryNum = 7, CategoryName = "7" });
            Categorys.Add(new Category() { CategoryNum = 8, CategoryName = "8" });
            Categorys.Add(new Category() { CategoryNum = 9, CategoryName = "9" });
            Categorys.Add(new Category() { CategoryNum = 10, CategoryName = "10" });
            Categorys.Add(new Category() { CategoryNum = 11, CategoryName = "11" });
            Categorys.Add(new Category() { CategoryNum = 12, CategoryName = "12" });
            #endregion

            // 초기에 보여지는 카테고리 5개
            for (int i = 0; i < 5; i++)
            {
                Categorys[i].CategoryDisplay = true;
                CatecoryCurrentIndex++;
            }

            GetGoodsShortDisplayBtns();

        }

        // 컴포넌트 들의 모든 사이즈 조절
        #region ConponentSizeChange
        private void ConponentSizeChange()
        {
            // 상품의 크기를 화면 비율에 따라 조절
            GoodsItemsWidth = WindowWidth / 4;
            GoodsItemsHight = (WindowHight * 4 / 6) / 4; // Grid비율에 따라 변경 되는 값

            // 카테고리 크기를 화면 비율에 따라 조절
            CategoryWidth = (WindowWidth - 200) / 5; // 양 옆 < > 버튼을 제외한것
            CategoryHight = (WindowHight * 0.3 / 6); // Grid비율에 따라 변경 되는 값

            // KioskGoodsSelectDisplay의 크기를 화면 비율에 따라 조절
            GoodsShortDisplayHight = (int)(WindowHight * 0.3);

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
            if (CatecoryCurrentIndex == 5)
            {
                return;
            }

            Categorys[CatecoryCurrentIndex - 1].CategoryDisplay = false;
            Categorys[CatecoryCurrentIndex - 6].CategoryDisplay = true;
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
            Categorys[CatecoryCurrentIndex - 5].CategoryDisplay = false;
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
            for (int i = 0; i < Math.Min(16, GoodsItems.Count); i++)
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
            int quotient = GoodsItems.Count / 16;  // 몫
            int remainder = GoodsItems.Count % 16; // 나머지

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

        private Command _goodsPageClickLeft;
        public ICommand GoodsPageClickLeft
        {
            get { return _goodsPageClickLeft = new Command(OnGoodsPageClickLeft); }
        }

        private void OnGoodsPageClickLeft(object obj)
        {
            // 첫 페이지가 아닐 경우
            if (GoodsItemCurrentIndex > 16)
            {
                // 전체 GoodsItems의 Visible을 false로 변경
                foreach (var item in GoodsItems)
                {
                    item.GoodsDisplay = false;
                }

                GoodsItemCurrentIndex -= 16;

                // GoodsItems의 Visible을 16개 단위로 true로 변경
                for (int i = GoodsItemCurrentIndex - 1; i > GoodsItemCurrentIndex - 16 - 1; i--)
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
            

                // GoodsItems의 Visible을 16개 단위로 true로 변경
                for (int i = GoodsItemCurrentIndex; i < Math.Min(GoodsItemCurrentIndex + 16, GoodsItems.Count); i++)
                {
                    GoodsItems[i].GoodsDisplay = true;
                }

                GoodsItemCurrentIndex += 16;

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

        #region KioskGoodsShortDisplay
        private int _goodsSelectDisplayHight;
        public int GoodsShortDisplayHight
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
            // 상품의 인덱스는 16 * 페이지로 구한후 16개를 보여준다
            GoodsItemCurrentIndex = 16 * (int)BtnNum;

            // 전체 GoodsItems의 Visible을 false로 변경
            foreach (var item in GoodsItems)
            {
                item.GoodsDisplay = false;
            }

            // GoodsItems의 Visible을 16개 단위로 true로 변경
            for (int i = GoodsItemCurrentIndex; i < Math.Min(GoodsItemCurrentIndex + 16, GoodsItems.Count); i++)
            {
                GoodsItems[i].GoodsDisplay = true;
            }

            GoodsItemCurrentIndex += 16;
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
