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
    /// Логика взаимодействия для EnterPage.xaml
    /// </summary>
    public partial class EnterPage : Page
    {
        ApplicationContext db;
        public EnterPage()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }
        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();
            string pass = PassBox.Password.Trim();
            string pass_2 = PassBox_2.Password.Trim();
            string email = TextBoxEmail.Text.Trim().ToLower();

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
            else if (pass_2 != pass)
            {
                PassBox_2.ToolTip = "Пароли не совпадают.";
                PassBox_2.Background = Brushes.LightCoral;
            }
            else if (email.Length < 7 || !email.Contains("@") || !email.Contains("."))
            {
                TextBoxEmail.ToolTip = "E-mail введён некорректно.";
                TextBoxEmail.Background = Brushes.LightCoral;
            }
            else
            {
                TextBoxLogin.ToolTip = "";
                TextBoxLogin.Background = Brushes.Transparent;
                PassBox.ToolTip = "";
                PassBox.Background = Brushes.Transparent;
                PassBox_2.ToolTip = "";
                PassBox_2.Background = Brushes.Transparent;
                TextBoxEmail.ToolTip = "";
                TextBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Регистрация успешна!");
                User user = new User(login, pass, email);
                db.Users.Add(user);
                db.SaveChanges();

                NavigationService.Navigate(new AuthPage());
            }
        }

        private void Button_Page_Auth_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
        }
    }
}

