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
using CAS.classes;

namespace CAS
{
    public partial class VideocardsPage : Page
    {
        public VideocardsPage()
        {
            InitializeComponent();
            Videocards = new ObservableCollection<Videocard>();
            Videocards.Add(new Videocard() { Name = "GeForce RTX 40 Series", Series = new ObservableCollection<string>() { "NVIDIA GeForce RTX 4090", "NVIDIA GeForce RTX 4080", "NVIDIA GeForce RTX 4070Ti" } });
            Videocards.Add(new Videocard() { Name = "GeForce RTX 30 Series", Series = new ObservableCollection<string>() { "GeForce RTX 3090 Ti", "GeForce RTX 3090", "GeForce RTX 3080 Ti", "GeForce RTX 3080", "GeForce RTX 3070 Ti", "GeForce RTX 3070", "GeForce RTX 3060 Ti", "GeForce RTX 3060", "GeForce RTX 3050" } });
            Videocards.Add(new Videocard() { Name = "GeForce RTX 20 Series", Series = new ObservableCollection<string>() { "GeForce RTX 2080 Ti", "GeForce RTX 2080 SUPER", "GeForce RTX 2080", "GeForce RTX 2070 SUPER", "GeForce RTX 2070", "GeForce RTX 2060 SUPER", "GeForce RTX 2060" } });
            Videocards.Add(new Videocard() { Name = "GeForce GTX 16 Series", Series = new ObservableCollection<string>() { "GeForce GTX 1660 SUPER", "GeForce GTX 1650 SUPER", "GeForce GTX 1660 Ti", "GeForce GTX 1660", "GeForce GTX 1650", "GeForce GTX 1630" } });
            Videocards.Add(new Videocard() { Name = "GeForce GTX 10 Series", Series = new ObservableCollection<string>() { "GeForce GTX 1080 Ti", "GeForce GTX 1080", "GeForce GTX 1070 Ti", "GeForce GTX 1070", "GeForce GTX 1060", "GeForce GTX 1050 Ti", "GeForce GTX 1050", "GeForce GTX 1030", "GeForce GTX 1010" } });
            DataContext = this;
        }
        public ObservableCollection<Videocard> Videocards { get; set; }
            
        public class Videocard
        {
            public string Name { get; set; }
            public ObservableCollection<string> Series { get; set; }
        }


        private void Click_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private string GetManufacture()
        {
            foreach (RadioButton item in Manufactures.Children) //среди всех эл-тов вкл в stackpanel 
                if (item is RadioButton)                        //мы выявляем RadioButton
                    if (item.IsChecked == true)                 //и проверям чекнут ли он
                        return item.Name.ToString();            //позвращаем name того radiobutton
                                                                //который выбран
            MessageBox.Show("выберите производителя");
            return "";                                          //"" - типа ошибка
        }
        private void Add_ShoppingCart(object sender, RoutedEventArgs e)
        {
            string manufacture = GetManufacture();
            string series = comboBox1.Text;
            string models = comboBox2.Text;
            if (manufacture == "" || series == "" || models == "")
            {
                MessageBox.Show("вы не выбрали необходимые пункты");
                return;
            }
                //можно еще подобавлять, например цену 
            var videocard = new VideoCard(manufacture, series, models);
            GLOBALS.videoCards.Add(videocard);
            var list =  (List<CreateBorder>)App.Current.Properties["ListOrders"];
            list.Add(new CreateBorder("Images/VIDEOCARD.png", models, manufacture));
        }
        
    }
}
