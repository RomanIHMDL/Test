using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DEMOEX
{
    /// <summary>
    /// Логика взаимодействия для admin.xaml
    /// </summary>
    public partial class admin : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source = LAPTOP-LQGSO1AN\SQLEXPRESS; Initial Catalog = kurs3;Integrated Security = True ");
        SqlCommand sqlCommand = new SqlCommand();
        public admin()
        {
            InitializeComponent();
            connection.Open();
       
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Договора_адм taskWindow = new Договора_адм();
            taskWindow.Show();
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Доставка_адм taskWindow = new Доставка_адм();
            taskWindow.Show();
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            клиенты_адм taskWindow = new клиенты_адм();
            taskWindow.Show();
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            продукты_адм taskWindow = new продукты_адм();
            taskWindow.Show();
            
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            заказы_адм taskWindow = new заказы_адм();
            taskWindow.Show();
            
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Оплата_адм taskWindow = new Оплата_адм();
            taskWindow.Show();
            
        }
    }
}
