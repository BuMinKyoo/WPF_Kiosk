using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_Kiosk.Model
{
    public class Category : INotifyPropertyChanged
    {
        private int _categoryNum;
        public int CategoryNum
        {
            get { return _categoryNum; }
            set
            {
                if (_categoryNum != value)
                {
                    _categoryNum = value;
                    Notify("CategoryNum");
                }
            }
        }

        private string _categoryName;
        public string CategoryName
        {
            get { return _categoryName; }
            set
            {
                if (_categoryName != value)
                {
                    _categoryName = value;
                    Notify("CategoryName");
                }
            }
        }

        private bool _categoryDisplay = false;
        public bool CategoryDisplay
        {
            get { return _categoryDisplay; }
            set
            {
                if (_categoryDisplay != value)
                {
                    _categoryDisplay = value;
                    Notify("CategoryDisplay");
                }
            }
        }

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
