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

namespace Глазки_SaveErshov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    

    public partial class MainWindowGlazki : Window
    {
        public MainWindowGlazki()
        {
            InitializeComponent();
            MainFrame.Navigate(new User());
            Classes.manager.MainFraim = MainFrame;
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Admin());
        }
        private void User_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new User());
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }

        private void MainFrame_Back(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack) Back_btn.Visibility = Visibility.Visible;
            else Back_btn.Visibility = Visibility.Hidden;
        }
    }
}
