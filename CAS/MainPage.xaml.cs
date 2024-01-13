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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Sells_Frame_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SellsPage());
        }
        private void Products_Frame_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductsPage());
        }
        private void ComboBoxItem_Products_Selected(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductsPage());
        }

        private void ComboBoxItem_Sells_Selected(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SellsPage());
        }

        private void Cart_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ShoppingCart());
        }
    }
}
