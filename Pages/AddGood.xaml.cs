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
    /// Логика взаимодействия для AddGood.xaml
    /// </summary>
    public partial class AddGood : Window
    {
        public AddGood()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string article = articleElem.Text;
            string name = nameElem.Text;
            string description = descrElem.Text;
            ComboBoxItem item = (ComboBoxItem)categoryElem.SelectedItem;
            if(item== null)
            {
                MessageBox.Show("Выберите категорию товара!");
                return;
            }
            string category = item.Content.ToString();
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
            if(!int.TryParse(discountElem.Text, out discount))
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
            if(!int.TryParse(quantityElem.Text, out quantity))
            {
                MessageBox.Show("Количество должно быть записано числом!");
                return;
            }
            if(quantity < 0)
            {
                MessageBox.Show("Количество на складе не может быть меньше ноля!");
                return;
            }

            bool result = Helpers.AddGood(article, name, description, category, manufacturer, price, discount, quantity);

            if (result == true)
            {
                MessageBox.Show("Товар добавлен!");
            }

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
