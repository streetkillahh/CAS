using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using MaterialDesignThemes.Wpf;

namespace CAS
{
    public class CreateBorder
    {
        public string image { get; set; }
        public string Product { get; set; }
        public int Price { get; set; }
        public int count { get; set; }
        public int sum { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }



        public CreateBorder() { }
        
        public Border GetName()
        {
            string image = this.image;
            image = image.Replace(@"Images/", "");
            return image == "Motherboard.png" ? Motherboard() : image == "PROCESSOR.png" ? PROCESSOR() :
                image == "RAM.png" ? RAM() : image == "VIDEOCARD.png" ? VIDEOCARD() : null;
        }
        public CreateBorder(string image, string Name, string manufacturer)
        {
            this.image = image;
            this.Product = Name;
            this.Manufacturer = manufacturer;
        }

        

        public Border Motherboard()
        {
            return createBorder(image, Product, "Материнская плата");
        }

        public Border PROCESSOR()
        {
            return createBorder(image, Product, "Процессор");
        }
        public Border RAM()
        {
            return createBorder(image, Product, "ОЗУ");
        }
        public Border VIDEOCARD()
        {
            return createBorder(image, Product, "Видеокарта");
        }

        private Border createBorder(string path, string Product, string Category)
        {

            Border border = new Border();
            border.Background = new SolidColorBrush(Color.FromRgb(57, 62, 70));
            border.Padding = new Thickness(5, 15, 5, 15);
            border.Margin = new Thickness(10);
            border.HorizontalAlignment = HorizontalAlignment.Left;
            border.CornerRadius = new CornerRadius(10);


            DropShadowEffect shadow = new DropShadowEffect();
            shadow.Opacity = 0.15;
            shadow.BlurRadius = 30;
            shadow.ShadowDepth = 0;
            shadow.Color = Color.FromRgb(57, 62, 70);
            border.Effect = shadow;

            Grid grid = new Grid();
            
            grid.Width = 388;
            grid.Margin = new Thickness(5);


            Image image = new Image(); //созд изображения
            image.Source = new BitmapImage(new Uri("pack://application:,,,/" + path));//


            image.MaxHeight = 120;
            image.HorizontalAlignment = HorizontalAlignment.Left;
            image.Margin = new Thickness(10, 0, 10, 10);
            grid.Children.Add(image);//

            TextBlock nazvanie = new TextBlock();
            nazvanie.Margin = new Thickness(25, -10, 25, -10);
            nazvanie.Text = Product;
            nazvanie.FontWeight = FontWeights.Bold;
            nazvanie.Foreground = new SolidColorBrush(Colors.White);
            nazvanie.VerticalAlignment = VerticalAlignment.Bottom;
            nazvanie.HorizontalAlignment = HorizontalAlignment.Left;
            grid.Children.Add(nazvanie);//

            StackPanel stack = new StackPanel();
            stack.HorizontalAlignment = HorizontalAlignment.Right;
            stack.VerticalAlignment = VerticalAlignment.Top;
            stack.Margin = new Thickness(10);
                                                                                //я это сделал
            ComboBox comboBox = new ComboBox();                                 //я это сделал
            Style CBView = (Style)App.Current.TryFindResource("ComboBoxTest2"); //я это сделал
            comboBox.Style = CBView;                                            //я это сделал
            for (int i = 1; i <= 6; i++)
                comboBox.Items.Add(i);
            comboBox.SelectedItem = comboBox.Items[0];
            comboBox.Margin = new Thickness(20, 10, 20, 10);
            comboBox.Foreground = new SolidColorBrush(Colors.White);
            comboBox.FontWeight = FontWeights.Bold;
            comboBox.Width = 100;
            comboBox.Padding = new Thickness(0, 5, 5, 35);
            stack.Children.Add(comboBox);

            //TextBox countOfProduct = new TextBox();
            //countOfProduct.Text = "1";
            //countOfProduct.Margin = new Thickness(20, 10, 20, 10);
            //countOfProduct.TextAlignment = TextAlignment.Center;
            //countOfProduct.Foreground = new SolidColorBrush(Colors.White);
            //countOfProduct.FontWeight = FontWeights.Bold;
            //stack.Children.Add(countOfProduct);

            //< TextBox Margin = "20 0"
            //                             Width = "100"
            //                             materialDesign: HintAssist.Foreground = "white"
            //                             Style = "{StaticResource MaterialDesignFloatingHintTextBox}"
            //                             materialDesign: HintAssist.Hint = "цена" />

            TextBox textBox = new TextBox();
            textBox.Margin = new Thickness(20, 0, 20, 0);
            textBox.Width = 100;
            var TBView = (Style)App.Current.TryFindResource("MaterialDesignFloatingHintTextBox");
            textBox.Style = TBView;
            HintAssist.SetForeground(textBox, new SolidColorBrush((Color)Colors.White));
            HintAssist.SetHint(textBox, "цена");

            textBox.PreviewTextInput += (s, a) =>   //что за уебанский способ
            {                                       //ограничить ввод 
                if (!(Char.IsDigit(a.Text, 0))
                    )    //только цифр
                {                                   //в впф
                    a.Handled = true;               //ладно, к этому привыкаешь
                }
            };
            stack.Children.Add(textBox);

            Border sumBord = new Border();
            sumBord.Background = new SolidColorBrush(Color.FromRgb(30, 32, 34));
            sumBord.Margin = new Thickness(20, 10, 20, 10);
            sumBord.Padding = new Thickness(10);
            sumBord.CornerRadius = new CornerRadius(10);

            TextBlock sumText = new TextBlock();
            int res = 0;
            int.TryParse(comboBox.Text, out res);
            count = res;
            int price = 0;
            sumText.Text = $"сумма за товар : {price * count}";
            sumText.Foreground = new SolidColorBrush(Colors.White); sumText.FontWeight = FontWeights.Bold;
            sumText.VerticalAlignment = VerticalAlignment.Center;
            sumBord.Child = sumText;
            stack.Children.Add(sumBord);

            grid.Children.Add(stack);



            textBox.TextChanged += (s, a) =>
            {

                int.TryParse(comboBox.Text, out res);
                count = res;
                price = int.Parse(textBox.Text);
                this.sum = price * count;
                this.count = count;
                this.Price = price;
                sumText.Text = $"сумма за товар : {price * count}";
            };

            border.Child = grid;

            this.Product = Product;
            this.Category = Category;   
            

            return border;
        }
    }
}
