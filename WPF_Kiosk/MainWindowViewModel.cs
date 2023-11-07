using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPF_Kiosk
{
    public class MainWindowViewModel
    {
        private Command _windowLoadedCommand;
        public ICommand WindowLoadedCommand
        {
            get { return _windowLoadedCommand = new Command(OnWindowLoadedCommand); }
        }

        private void OnWindowLoadedCommand(object obj)
        {
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
        }
    }
}
