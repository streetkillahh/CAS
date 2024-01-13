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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace CAS
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public DropShadowEffect LightShadow = new DropShadowEffect();
        public DropShadowEffect RedShadow = new DropShadowEffect();
        public ProductsPage()
        {
            InitializeComponent();
            RedShadow.Color = Colors.Red; RedShadow.Opacity = 1; RedShadow.ShadowDepth = 0; RedShadow.BlurRadius = 30;
        }

        private void Click_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Videocards_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new VideocardsPage());
        }

        private void Processors_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProcessorsPage());
        }

        private void Motherboards_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MotherboardsPage());
        }

        private void RAMs_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RamsPage());
        }
        private void ComboBoxItem_Products_Selected(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductsPage());
        }

        private void ComboBoxItem_Sells_Selected(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SellsPage());
        }

        private void Videocards_MouseEnter(object sender, MouseEventArgs e)
        {
            LightShadow.BlurRadius = 30; LightShadow.Opacity = 0.6; LightShadow.Color = Colors.White; LightShadow.ShadowDepth = 0;
            Button image = sender as Button;
            image.Effect = image.Effect == RedShadow ? RedShadow : LightShadow;
        }

        private void Videocards_MouseLeave(object sender, MouseEventArgs e)
        {
            Button image = sender as Button;
            foreach (Button img in wrap.Children)
            {
                img.Effect = img.Effect == RedShadow ? RedShadow : null;
            }

        }
    }
}
