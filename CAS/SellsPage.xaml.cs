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
using CAS.DataGridPages;

namespace CAS
{
    /// <summary>
    /// Логика взаимодействия для SellsPage.xaml
    /// </summary>
    public partial class SellsPage : Page
    {
        MainWindow MW = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        
        public SellsPage()
        {
            InitializeComponent();
        }

        private void Click_Back(object sender, RoutedEventArgs e)
        {
            MW.MainFrame.NavigationService.Navigate(new MainPage());
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            string name = btn.Content.ToString();
            switch (name)
            {
                case "История покупок":
                    this.MainFrame.NavigationService.Navigate(new HistoryPage());
                    break;
                default:
                    this.MainFrame.NavigationService.Navigate(new DevicesPage());
                    break;
            }
            
        }
    }
}
