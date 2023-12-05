using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_Kiosk.Model
{
    public class MainCategory : INotifyPropertyChanged
    {
        private int _inMainCategoryNum;
        public int InMainCategoryNum
        {
            get { return _inMainCategoryNum; }
            set
            {
                if (_inMainCategoryNum != value)
                {
                    _inMainCategoryNum = value;
                    Notify();
                }
            }
        }

        private string _strMainCategoryName;
        public string StrMainCategoryName
        {
            get { return _strMainCategoryName; }
            set
            {
                if (_strMainCategoryName != value)
                {
                    _strMainCategoryName = value;
                    Notify();
                }
            }
        }

        private bool _blMainCategoryVis = false;
        public bool BlMainCategoryVis
        {
            get { return _blMainCategoryVis; }
            set
            {
                if (_blMainCategoryVis != value)
                {
                    _blMainCategoryVis = value;
                    Notify();
                }
            }
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
