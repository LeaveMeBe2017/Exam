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
    /// Логика взаимодействия для GoodsGuest.xaml
    /// </summary>
    public partial class GoodsGuest : Window
    {
        public GoodsGuest()
        {
            InitializeComponent();
            goodsListElem.ItemsSource = Helpers.connection.Product.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
