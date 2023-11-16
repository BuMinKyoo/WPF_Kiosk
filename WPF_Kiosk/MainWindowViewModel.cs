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
            // 윈도우 화면을 가져와서 비율에 따라 크기를 조절
            WindowWidth = SystemParameters.PrimaryScreenWidth;
            WindowHight = SystemParameters.PrimaryScreenHeight;

            // 상품의 크기를 화면 비율에 따라 조절
            GoodsItemsWidth = WindowWidth / 4;
            GoodsItemsHight = (WindowHight * 4/6) / 4; // Grid비율에 따라 변경 되는 값

            // 카테고리 크기를 화면 비율에 따라 조절
            CategoryWidth = (WindowWidth - 200) / 5; // 양 옆 < > 버튼을 제외한것
            CategoryHight = (WindowHight * 0.3 / 6); // Grid비율에 따라 변경 되는 값


            #region GoodsItems테스트
            GoodsItems.Add(new GoodsItems() { GoodsName = "1", Discount = "0", GoodsPrice = 5000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "2", Discount = "0", GoodsPrice = 10000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "3", Discount = "0", GoodsPrice = 15000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "4", Discount = "0", GoodsPrice = 2000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "5", Discount = "0", GoodsPrice = 2000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "6", Discount = "0", GoodsPrice = 2000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "7", Discount = "0", GoodsPrice = 3000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "8", Discount = "0", GoodsPrice = 3000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "9", Discount = "0", GoodsPrice = 4000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "10", Discount = "0", GoodsPrice = 4000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "11", Discount = "0", GoodsPrice = 4000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "12", Discount = "0", GoodsPrice = 1000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "13", Discount = "0", GoodsPrice = 2000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "14", Discount = "0", GoodsPrice = 3000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "15", Discount = "0", GoodsPrice = 4000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "16", Discount = "0", GoodsPrice = 5000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "17", Discount = "0", GoodsPrice = 5000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "18", Discount = "0", GoodsPrice = 5000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "19", Discount = "0", GoodsPrice = 5000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "20", Discount = "0", GoodsPrice = 5000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "21", Discount = "0", GoodsPrice = 5000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "22", Discount = "0", GoodsPrice = 5000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "23", Discount = "0", GoodsPrice = 5000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "24", Discount = "0", GoodsPrice = 5000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "25", Discount = "0", GoodsPrice = 5000 });
            GoodsItems.Add(new GoodsItems() { GoodsName = "26", Discount = "0", GoodsPrice = 10000 });
            GoodsItems.Add(new GoodsItems() { GoodsName = "27", Discount = "0", GoodsPrice = 15000 });
            GoodsItems.Add(new GoodsItems() { GoodsName = "28", Discount = "0", GoodsPrice = 2000 });
            GoodsItems.Add(new GoodsItems() { GoodsName = "29", Discount = "0", GoodsPrice = 2000 });
            GoodsItems.Add(new GoodsItems() { GoodsName = "30", Discount = "0", GoodsPrice = 2000 });
            GoodsItems.Add(new GoodsItems() { GoodsName = "31", Discount = "0", GoodsPrice = 3000 });
            GoodsItems.Add(new GoodsItems() { GoodsName = "32", Discount = "0", GoodsPrice = 3000 });
            GoodsItems.Add(new GoodsItems() { GoodsName = "33", Discount = "0", GoodsPrice = 4000 });
            GoodsItems.Add(new GoodsItems() { GoodsName = "34", Discount = "0", GoodsPrice = 4000 });
            GoodsItems.Add(new GoodsItems() { GoodsName = "35", Discount = "0", GoodsPrice = 4000 });
            GoodsItems.Add(new GoodsItems() { GoodsName = "36", Discount = "0", GoodsPrice = 1000 });
            GoodsItems.Add(new GoodsItems() { GoodsName = "37", Discount = "0", GoodsPrice = 2000 });
            GoodsItems.Add(new GoodsItems() { GoodsName = "38", Discount = "0", GoodsPrice = 3000 });
            GoodsItems.Add(new GoodsItems() { GoodsName = "39", Discount = "0", GoodsPrice = 4000 });
            GoodsItems.Add(new GoodsItems() { GoodsName = "40", Discount = "0", GoodsPrice = 5000 });
            GoodsItems.Add(new GoodsItems() { GoodsName = "41", Discount = "0", GoodsPrice = 5000 });
            GoodsItems.Add(new GoodsItems() { GoodsName = "42", Discount = "0", GoodsPrice = 5000 });
            GoodsItems.Add(new GoodsItems() { GoodsName = "43", Discount = "0", GoodsPrice = 5000 });
            GoodsItems.Add(new GoodsItems() { GoodsName = "44", Discount = "0", GoodsPrice = 5000 });
            GoodsItems.Add(new GoodsItems() { GoodsName = "45", Discount = "0", GoodsPrice = 5000 });
            GoodsItems.Add(new GoodsItems() { GoodsName = "46", Discount = "0", GoodsPrice = 5000 });
            GoodsItems.Add(new GoodsItems() { GoodsName = "47", Discount = "0", GoodsPrice = 5000 });
            GoodsItems.Add(new GoodsItems() { GoodsName = "48", Discount = "0", GoodsPrice = 5000 });
            GoodsItems.Add(new GoodsItems() { GoodsName = "49", Discount = "0", GoodsPrice = 5000 });
            GoodsItems.Add(new GoodsItems() { GoodsName = "50", Discount = "0", GoodsPrice = 10000 });
            #endregion

            // 초기에 보여지는 상품 16개
            for (int i = 0; i < 16; i++)
            {
                GoodsItems[i].GoodsDisplay = true;
                GoodsItemCurrentIndex++;
            }

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

        }

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

        #region KioskGoods
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
            if (GoodsItemCurrentIndex != 16)
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
            Categorys[CatecoryCurrentIndex-5].CategoryDisplay = false;
            CatecoryCurrentIndex++;
        }

        #endregion

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
