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
    /// Логика взаимодействия для Каталог.xaml
    /// </summary>
    public partial class Каталог : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source = LAPTOP-LQGSO1AN\SQLEXPRESS; Initial Catalog = kurs3;Integrated Security = True ");
        SqlCommand sqlCommand = new SqlCommand();
        public Каталог()
        {
            InitializeComponent();
            connection.Open();
            string cmd = "SELECT *FROM [Продукты питания]";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("[Продукты питания]");
            dataAdp.Fill(dt);
            Меню.ItemsSource = dt.DefaultView;
            connection.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            klient taskWindow = new klient();
            taskWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Zakaz taskWindow = new Zakaz();
            taskWindow.Show();
           
        }

        private void Меню_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
