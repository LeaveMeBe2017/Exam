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
    /// Логика взаимодействия для EditGood.xaml
    /// </summary>
    public partial class EditGood : Window
    {
        Product product = null;
        public EditGood(Product _product)
        {
            InitializeComponent();
            articleElem.Text = _product.ProductArticleNumber;
            nameElem.Text = _product.ProductName;
            descrElem.Text = _product.ProductDescription;
            categoryElem.SelectedItem = _product.ProductCategory;
            manufactElem.Text = _product.ProductManufacturer;
            priceElem.Text = _product.ProductCost.ToString();
            discountElem.Text = _product.ProductDiscountAmount.ToString();
            quantityElem.Text = _product.ProductQuantityInStock.ToString();

            product = _product;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string article = articleElem.Text;
            string name = nameElem.Text;
            string descr = descrElem.Text;
            ComboBoxItem item = (ComboBoxItem)categoryElem.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Выберите категорию!");
                return;
            }
            string manufacturer = manufactElem.Text;
            int price;
            if (!int.TryParse(priceElem.Text, out price))
            {
                MessageBox.Show("Цена должна быть записана числом!");
                return;
            }

            if (price < 0)
            {
                MessageBox.Show("Цена не может быть отрицательной!");
                return;
            }

            int discount;
            if (!int.TryParse(discountElem.Text, out discount))
            {
                MessageBox.Show("Скидка должна быть записана числом!");
                return;
            }

            if (discount < 0)
            {
                MessageBox.Show("Скидка не может быть меньше ноля!");
                return;
            }
            int quantity;
            if (!int.TryParse(quantityElem.Text, out quantity))
            {
                MessageBox.Show("Количество должно быть записано числом!");
                return;
            }
            if (quantity < 0)
            {
                MessageBox.Show("Количество на складе не может быть меньше ноля!");
                return;
            }

            Product newProduct = Helpers.connection.Product.FirstOrDefault(x => x.ProductName == name && x.ProductManufacturer == manufacturer);

            if(newProduct != null)
            {
                MessageBox.Show("Такой товар уже есть в базе!");
                return;
            }

            Product editProduct = Helpers.connection.Product.FirstOrDefault(x => x.ProductArticleNumber == product.ProductArticleNumber);

            
            editProduct.ProductName = name;
            editProduct.ProductDescription = descr;
            editProduct.ProductCategory = item.Content.ToString();
            editProduct.ProductManufacturer = manufacturer;
            editProduct.ProductCost = price;
            editProduct.ProductDiscountAmount = discount;
            editProduct.ProductQuantityInStock = quantity;

            Helpers.connection.SaveChanges();

            MessageBox.Show("Товар отредактирован!");

            new GoodsAdmin().Show();
            Close();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
