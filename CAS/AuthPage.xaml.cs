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

namespace CAS
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void Button_Page_Reg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EnterPage());
        }
        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage/*тут должен быть переход в кабинет, а не MainPage*/());
            return;
            string login = TextBoxLogin.Text.Trim();
            string pass = PassBox.Password.Trim();

            if (login.Length < 3)
            {
                TextBoxLogin.ToolTip = "Логин должен состоять из минимум 3 символов.";
                TextBoxLogin.Background = Brushes.LightCoral;
            }
            else if (pass.Length < 8)
            {
                PassBox.ToolTip = "Пароль должен быть не менее 8 символов.";
                PassBox.Background = Brushes.LightCoral;
            }
            else
            {
                TextBoxLogin.ToolTip = "";
                TextBoxLogin.Background = Brushes.Transparent;
                PassBox.ToolTip = "";
                PassBox.Background = Brushes.Transparent;
                User authUser = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();
                }
                if (authUser != null)
                {
                    MessageBox.Show("Вход выполнен успешно!");
                    NavigationService.Navigate(new MainPage/*тут должен быть переход в кабинет, а не MainPage*/());
                }
                else
                    MessageBox.Show("Логин/Пароль введены некорректно!");
            }
        }
    }
}
