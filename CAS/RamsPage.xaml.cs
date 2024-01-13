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
    /// Логика взаимодействия для RamsPage.xaml
    /// </summary>
    public partial class RamsPage : Page
    {
        public RamsPage()
        {
            InitializeComponent();
        }

        private void Click_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddShoppingCart_Click(object sender, RoutedEventArgs e)
        {
            string Manufacturer = "";
            foreach (UIElement item in Opt.Children)
            {
                if (item is ComboBox)
                {
                    var CB = (ComboBox)item;
                    var checkTXT = CB.Text;
                    if (string.IsNullOrWhiteSpace(checkTXT))
                    {
                        MessageBox.Show($"вы не указали значение \"{CB.Name}\"");
                        return;
                    }
                }
            }
            string type = Типа.Text;
            string volume = Объема.Text;
            string frequency = Частоты.Text;

            foreach (var item in Производителя.Children)
            {
                if (item is RadioButton &&
                    ((RadioButton)item).IsChecked == true)
                {
                    Manufacturer = ((RadioButton)item).Name;
                }
            }

            if (Manufacturer == "")
            {
                MessageBox.Show("вы не выбрали производителя");
                return;
            }
            var list = (List<CreateBorder>)App.Current.Properties["ListOrders"];
            list.Add(new CreateBorder("Images/RAM.png", $"{type} {volume} {frequency}", Manufacturer));
        }
    }
}
