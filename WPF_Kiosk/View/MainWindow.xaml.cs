using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Kiosk.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // LoginWindow를 실행하고, 윈도우를 화면의 중앙에 맞춤
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.WindowStartupLocation = WindowStartupLocation.Manual;
            loginWindow.Left = SystemParameters.PrimaryScreenWidth / 2 - (SystemParameters.PrimaryScreenWidth * StaticValue.Stc_DblLoginWindowRatioW) / 2;
            loginWindow.Top = SystemParameters.PrimaryScreenHeight / 2 - (SystemParameters.PrimaryScreenHeight * StaticValue.Stc_DblLoginWindowRatioH) / 2;

            loginWindow.ShowDialog();

            InitializeComponent();
        }
    }
}
