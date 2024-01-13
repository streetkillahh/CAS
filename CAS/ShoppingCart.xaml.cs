using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CAS.classes;
using static System.Net.Mime.MediaTypeNames;

namespace CAS
{
    /// <summary>
    /// Логика взаимодействия для ShoppingCart.xaml
    /// </summary>
    public partial class ShoppingCart : Page
    {
        List<CreateBorder> list;
        public ShoppingCart()
        {
            InitializeComponent();
            OrdersInBasket.Children.Clear(); // нах пример, мы ща корзину нагрузим
            list = (List<CreateBorder>)App.Current.Properties["ListOrders"];
            foreach (var item in list)
            {
                Border border = item.GetName();
                if (OrdersInBasket.Children.Contains(border) == false)
                    OrdersInBasket.Children.Add(border);
            }
            
        }
        
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            //var test = (Style)App.Current.TryFindResource("ComboBoxTest2");
            //var comboBox = new ComboBox();
            //comboBox.Style = test;
            OrdersInBasket.Children.Clear();
            App.Current.Properties["ListOrders"] = new List<CreateBorder>();
        }

        private void Count_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationContext())
            {
                var purchase = new HistoryPurchase();
                foreach (var item in list)
                {
                    purchase.Sum += item.sum;
                    purchase.Count += item.count;
                    purchase.Date = DateTime.Now.ToString();
                    purchase.Devices += $"{item.Product} x{item.count} ({item.sum})\n";

                    var dbDev = db.Devices.FirstOrDefault(p => p.Model == item.Product);
                    if (dbDev is null)
                    {
                        dbDev = new Device(item.Manufacturer, item.Product, item.Price * item.count, item.count, item.Category);
                        db.Devices.Add(dbDev);
                    }
                    else
                    {
                        dbDev.Count += item.count;
                        dbDev.Price += item.Price;
                    }
                    db.SaveChanges();
                }
                db.HistoryPurchases.Add(purchase);
                db.SaveChanges();
            }

            OrdersInBasket.Children.Clear();
            GLOBALS.videoCards = new System.Collections.Generic.List<VideoCard>();
            list = new List<CreateBorder>();

            MessageBox.Show("Данные о покупке отправлены на терминал");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
