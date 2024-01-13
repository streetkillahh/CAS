using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using static CAS.ProcessorsPage;
using static CAS.VideocardsPage;

namespace CAS
{
    public partial class ProcessorsPage : Page
    {
        public ProcessorsPage()
        {
            InitializeComponent();
            ProcessorsI = new ObservableCollection<Processor>();
            ProcessorsI.Add(new Processor() { Name = "LGA 1151", Series = new ObservableCollection<string>() { "Core i7 7700K", "Core i5 7600K", "Core i3 7350K" } });
            ProcessorsI.Add(new Processor() { Name = "LGA 1200", Series = new ObservableCollection<string>() { "Core I9 10900K", "Core i7 11700K", "Core I5 10600K" } });
            ProcessorsI.Add(new Processor() { Name = "LGA 2066", Series = new ObservableCollection<string>() { "Core i9 10980XE", "Xeon W 2295", "Core i9 9980XE" } });
            DataContext = this;
            ProcessorsA = new ObservableCollection<Processor>();
            ProcessorsA.Add(new Processor() { Name = "AM4", Series = new ObservableCollection<string>() { "Ryzen 7 5800X3D", "Ryzen 9 5950X", "Ryzen 7 3800XT", "Ryzen 7 5800X", "Ryzen 7 2700X", "Ryzen 7 3700X" } });
            ProcessorsA.Add(new Processor() { Name = "TR4", Series = new ObservableCollection<string>() { "Ryzen Threadripper 2990WX", "Ryzen Threadripper 2950X", "Ryzen Threadripper 1950X" } });
            ProcessorsA.Add(new Processor() { Name = "STRX4", Series = new ObservableCollection<string>() { "Ryzen Threadripper 3990X", "Ryzen Threadripper PRO 3995WX", "Ryzen Threadripper 3970X", "Ryzen Threadripper PRO 3975WX" } });
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
            if (IntelC.IsChecked == false && AMDC.IsChecked== false) 
            {
                MessageBox.Show("вы не выбрали производителя");
                return;
            }
            
            string Manufacturer = IntelC.IsChecked == true ? "Intel" : "AMD";
            
            var model = new List<string>();
            if (comboBox1.IsEnabled == true)
                model.Add(comboBox1.Text);
            if (comboBox2.IsEnabled == true)
                model.Add(comboBox2.Text);
            if (comboBox3.IsEnabled == true)
                model.Add(comboBox3.Text);
            if (comboBox4.IsEnabled == true)
                model.Add(comboBox4.Text);

            if (model.Count != 2)
            {
                MessageBox.Show("вы не указали все необходимые параметры");
                return;
            }

            var list = (List<CreateBorder>)App.Current.Properties["ListOrders"];
            list.Add(new CreateBorder("Images/PROCESSOR.png", $"{model[0]} {model[1]}", Manufacturer));
        }
    }
}
