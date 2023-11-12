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

            // 상품의 크기를 비율에 따라 조절
            GoodsItemsWidth = WindowWidth / 4;
            GoodsItemsHight = (WindowHight * 4/6) / 4; // Grid비율에 따라 변경 되는 값

            GoodsItems.Add(new GoodsItems() { GoodsName = "햄버거", Discount = "0", GoodsPrice = 5000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "피자", Discount = "0", GoodsPrice = 10000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "치킨", Discount = "0", GoodsPrice = 15000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "콜라", Discount = "0", GoodsPrice = 2000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "사이다", Discount = "0", GoodsPrice = 2000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "환타", Discount = "0", GoodsPrice = 2000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "커피", Discount = "0", GoodsPrice = 3000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "주스", Discount = "0", GoodsPrice = 3000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "맥주", Discount = "0", GoodsPrice = 4000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "소주", Discount = "0", GoodsPrice = 4000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "막걸리", Discount = "0", GoodsPrice = 4000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "과자", Discount = "0", GoodsPrice = 1000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "아이스크림", Discount = "0", GoodsPrice = 2000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "초콜릿", Discount = "0", GoodsPrice = 3000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "과일", Discount = "0", GoodsPrice = 4000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "컵라면", Discount = "0", GoodsPrice = 5000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "라면", Discount = "0", GoodsPrice = 5000});
            GoodsItems.Add(new GoodsItems() { GoodsName = "김밥", Discount = "0", GoodsPrice = 5000});

            // 초기에 보여지는 상품 16개
            for (int i = 0; i < 16; i++)
            {
                GoodsItems[i].GoodsDisplay = true;
                CurrentIndex++;
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

        private void OnKioskLockMouseUp(object obj)
        {
            KioskLockVisibility = false;
        }

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

        #region KioskMain
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

        private int _currentIndex = 0;
        public int CurrentIndex
        {
            get { return _currentIndex; }
            set
            {
                _currentIndex = value;
                Notify("CurrentIndex");
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
            //if (CurrentIndex != 0)
            //{
            //    // 전체 GoodsItems의 Visible을 false로 변경
            //    foreach (var item in GoodsItems)
            //    {
            //        item.GoodsDisplay = false;
            //    }

            //    // GoodsItems의 Visible을 16개 단위로 true로 변경
            //    for (int i = CurrentIndex; i < Math.Min(CurrentIndex - 16, GoodsItems.Count); i++)
            //    {
            //        GoodsItems[i].GoodsDisplay = true;
            //    }

            //    CurrentIndex -= 16;
            //}
        }

        private Command _goodsPageClickRight;
        public ICommand GoodsPageClickRight
        {
            get { return _goodsPageClickRight = new Command(OnGoodsPageClickRight); }
        }

        private void OnGoodsPageClickRight(object obj)
        {
            // 마지막 페이지가 아닐 경우
            if (CurrentIndex < GoodsItems.Count)
            {
                // 전체 GoodsItems의 Visible을 false로 변경
                foreach (var item in GoodsItems)
                {
                    item.GoodsDisplay = false;
                }
            

                // GoodsItems의 Visible을 16개 단위로 true로 변경
                for (int i = CurrentIndex; i < Math.Min(CurrentIndex + 16, GoodsItems.Count); i++)
                {
                    GoodsItems[i].GoodsDisplay = true;
                }
            
                CurrentIndex += 16;
            }
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
