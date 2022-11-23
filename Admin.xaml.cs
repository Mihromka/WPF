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
using Глазки_SaveErshov.model;

namespace Глазки_SaveErshov
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        Random _random = new Random();
        public Admin()
        {
            InitializeComponent();
            UpdateCaptcha();
            Classes.ConnectDB.modeldb = new model.Entities2();
        }

        private void UpdateCaptcha()
        {
            SPanelSymbols.Children.Clear();
            CanvasNoise.Children.Clear();
            GenerateSymbols(3);
            GenerateNoise(5);
        }
        public string symbols = "";
        private void GenerateSymbols(int count)
        {
            string alphabet = "WERPASFHKXVBM234578";
            for (int i = 0; i < count; i++)
            {
                string symbol = alphabet.ElementAt(_random.Next(0, alphabet.Length)).ToString();
                TextBlock lbl = new TextBlock();



                lbl.Text = symbol;
                lbl.FontSize = _random.Next(15, 35);
                lbl.RenderTransform = new RotateTransform(_random.Next(-45, 45));
                lbl.Margin = new Thickness(20, 10, 20, 10);



                //lbl.Foreground = ra

                SPanelSymbols.Children.Add(lbl);
                symbols = symbols + symbol;
            }
        }
        
        private void GenerateNoise(int volumeNoise)
        {
            for (int i = 0; i < volumeNoise; i++)
            {
                Border border = new Border();
                border.Background = new SolidColorBrush(Color.FromArgb((byte)_random.Next(100, 200),
                                                                       (byte)_random.Next(0, 256),
                                                                       (byte)_random.Next(0, 256),
                                                                       (byte)_random.Next(0, 256)));
                border.Height = _random.Next(2, 10);
                border.Width = _random.Next(10, 40);



                border.RenderTransform = new RotateTransform(_random.Next(-20, 20));


                CanvasNoise.Children.Add(border);
                Canvas.SetLeft(border, _random.Next(10, 120));
                Canvas.SetTop(border, _random.Next(20, 35));

                Ellipse ellipse = new Ellipse();
                ellipse.Fill = new SolidColorBrush(Color.FromArgb((byte)_random.Next(100, 200),
                                                                       (byte)_random.Next(0, 256),
                                                                       (byte)_random.Next(0, 256),
                                                                       (byte)_random.Next(0, 256)));
                ellipse.Height = ellipse.Width = _random.Next(20, 40);



                CanvasNoise.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, _random.Next(10, 120));
                Canvas.SetTop(ellipse, _random.Next(20, 35));
            }
        }

        private void BtnUpdateCaptcha_Click(object sender, RoutedEventArgs e)
        {
            UpdateCaptcha();
        }



        private void TbxShowPass_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TxbPassword.Visibility = Visibility.Visible;
            PsbPassword.Visibility = Visibility.Collapsed;
            TxbPassword.Text = PsbPassword.Password;
        }

        private void TbxShowPass_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TxbPassword.Visibility = Visibility.Collapsed;
            PsbPassword.Visibility = Visibility.Visible;
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = Classes.ConnectDB.modeldb.User.FirstOrDefault(x =>
                x.Name == TxbLogin.Text && x.Password == PsbPassword.Password);

                if (userObj != null && (GetCaptcha.Text == symbols))
                {
                    MessageBox.Show("Здравствуйте " + userObj.Role.Title + ", " + userObj.Name, "Уведомление",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    Entities2.CurentStaff = userObj;
                    switch (userObj.ID)
                    {
                        case 1:
                            NavigationService.Navigate(new Administrator());
                            break;
                        case 2:
                            NavigationService.Navigate(new StarshiySmen());
                            break;
                        case 3:
                            NavigationService.Navigate(new Manager());
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены!", "Уведомление",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }

                else MessageBox.Show("Пользователя в БД нет", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                
               // if(TxbLogin.Text=="1" && PsbPassword.Password=="1")
                //{
              //      Classes.manager.MainFraim.Navigate(new Administrator());
               // }

                

            }

            catch
            {

            }
        }














    }
}
