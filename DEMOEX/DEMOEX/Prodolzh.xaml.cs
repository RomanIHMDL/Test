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
    /// Логика взаимодействия для Prodolzh.xaml
    /// </summary>
    public partial class Prodolzh : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source = LAPTOP-LQGSO1AN\SQLEXPRESS; Initial Catalog = kurs3;Integrated Security = True ");
        SqlCommand sqlCommand = new SqlCommand();
        public Prodolzh()
        {
            
            InitializeComponent();
            connection.Open();
            string cmd = "SELECT *FROM [Состав заказа]";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("[Состав заказа]");
            dataAdp.Fill(dt);
            Test.ItemsSource = dt.DefaultView;
            
            connection.Close();

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            connection.Open();
            string sql = string.Format("Insert into [Состав заказа] ([Количеситво] ,[Код продукта питания] ,[Номер заказа])values(@kol,@kod,@no)");

            using (SqlCommand cmd = new SqlCommand(sql, this.connection))
            {
                cmd.CommandText = "Insert into [Состав заказа] ([Количеситво] ,[Код продукта питания] ,[Номер заказа])values(@kol,@kod,@no)";
                cmd.Parameters.AddWithValue("@kol", Колич.Text);
                cmd.Parameters.AddWithValue("@kod", код.Text);
                cmd.Parameters.AddWithValue("@no", Номер_заказа.Text);
                
                try
                { cmd.ExecuteNonQuery(); }
                catch
                { MessageBox.Show("Облом!"); }
                finally { connection.Close(); }
            }

            connection.Close();
           
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            { MessageBox.Show("Ваш заказ принят!"); }
            Каталог taskWindow = new Каталог();
            taskWindow.Show();
            this.Close();
        }

        private void фильтр_TextChanged(object sender, TextChangedEventArgs e)
        {
            {


                DataView dv =Test.ItemsSource as DataView;

                string filter = фильтр.Text;
                if (string.IsNullOrEmpty(filter))
                {
                    dv.RowFilter = null;

                }
                else
                {
                    dv.RowFilter = "[Номер заказа] = " + фильтр.Text;

                }

            }
        }
    }
}
