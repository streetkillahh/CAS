using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для MotherboardsPage.xaml
    /// </summary>
    public partial class MotherboardsPage : Page
    {
        public MotherboardsPage()
        {
            InitializeComponent();
            ProcessorsI = new ObservableCollection<Processor>
            {
                new Processor() { Name = "LGA 1151", Series = new ObservableCollection<string>() { "H110", "B150" } },
                new Processor() { Name = "LGA 1200", Series = new ObservableCollection<string>() { "H510", "B560" } },
                new Processor() { Name = "LGA 2066", Series = new ObservableCollection<string>() { "X299" } },
                new Processor() { Name = "AM4", Series = new ObservableCollection<string>() { "X570", "B550", "B450" } },
                new Processor() { Name = "TR4", Series = new ObservableCollection<string>() { "X399" } },
                new Processor() { Name = "STRX4", Series = new ObservableCollection<string>() { "TRX40" } }
            };
            DataContext = this;
        }
        public ObservableCollection<Processor> ProcessorsI { get; set; }
        public ObservableCollection<Processor> ProcessorsA { get; set; }

        public class Processor
        {
            public string Name { get; set; }
            public ObservableCollection<string> Series { get; set; }
        }

        private void Click_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddShoppingCart_Click(object sender, RoutedEventArgs e)
        {
            string Manufacturer = "";
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

            var model = new List<string>();
            foreach (UIElement item in ДичьКакаяТо.Children)
            {
                if (item is ComboBox)
                {
                    var CB = (ComboBox)item;
                    if (CB.IsEnabled)
                        model.Add($"{CB.Text} ");
                }
            }

            if (model.Count != 2)
            {
                MessageBox.Show("вы не указали все необходимые параметры");
                return;
            }

            var list = (List<CreateBorder>)App.Current.Properties["ListOrders"];
            list.Add(new CreateBorder("Images/Motherboard.png", $"{model[0]} {model[1]}", Manufacturer));

        }
    }
}
