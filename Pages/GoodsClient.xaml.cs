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
using System.Windows.Shapes;

namespace Exam.Pages
{
    /// <summary>
    /// Логика взаимодействия для GoodsClient.xaml
    /// </summary>
    public partial class GoodsClient : Window
    {
        private User user = Store.user;
        public GoodsClient()
        {
            InitializeComponent();
            goodsListElem.ItemsSource = Helpers.connection.Product.ToList();
            fioElem.Content = $"{user.UserSurname} {user.UserName} {user.UserPatronymic}";

            List<string> manufacturers = new List<string>();
            manufacturers.Add("Все производители");
            manufacturers.AddRange(Helpers.connection.Product.Select(x => x.ProductManufacturer).Distinct().ToList());
            manufacturersElem.ItemsSource = manufacturers;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void searchElem_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Product> products = Helpers.connection.Product.Where(x=>x.ProductName.Contains(searchElem.Text)).ToList();
            goodsListElem.ItemsSource = products;
        }

        private void manufacturersElem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string manufacturers = manufacturersElem.SelectedItem.ToString();
            List<Product> products;

            if(manufacturers =="Все производители")
            {
                products = Helpers.connection.Product.ToList();
            }
            else
            {
                products = Helpers.connection.Product.Where(x => x.ProductManufacturer == manufacturers).ToList();
            }

            goodsListElem.ItemsSource = products;
        }
    }
}
