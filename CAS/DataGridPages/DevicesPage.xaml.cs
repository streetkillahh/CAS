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

namespace CAS.DataGridPages
{
    /// <summary>
    /// Логика взаимодействия для DevicesPage.xaml
    /// </summary>
    public partial class DevicesPage : Page
    {
        public DevicesPage()
        {
            InitializeComponent();
            using (var db = new ApplicationContext())
            {
                dgListOrders.ItemsSource = db.Devices.ToList();
            }
        }
    }
}
