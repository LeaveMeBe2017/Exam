using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Exam
{
    public class Helpers
    {
        public static Connection connection = new Connection();

        public static User Auth (string login, string password)
        {
            User user = connection.User.FirstOrDefault(x => x.UserLogin == login);

            if (user == null)
            {
                MessageBox.Show("Пользователь не найден!");
                return null;
            }

            if (user.UserPassword != password)
            {
                MessageBox.Show("Неверный пароль!");
                return null;
            }
            return user;
        }

        public static bool AddGood(string article, string name, string description, string category, string manufacturer, int price, int discount, int quantity)
        {
            Product newProduct = connection.Product.FirstOrDefault(x => x.ProductName == name && x.ProductManufacturer == manufacturer);

            if(newProduct != null)
            {
                MessageBox.Show("Такой товар уже есть в базе!");
                return false;
            }

            Product product = new Product();
            product.ProductArticleNumber = article;
            product.ProductName = name;
            product.ProductDescription = description;
            product.ProductCategory = category;
            product.ProductManufacturer = manufacturer;
            product.ProductCost = price;
            product.ProductDiscountAmount = discount;
            product.ProductQuantityInStock = quantity;

            connection.Product.Add(product);
            connection.SaveChanges();
            return true;
        }
    }
}
