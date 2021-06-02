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
    /// Логика взаимодействия для клиенты_адм.xaml
    /// </summary>
    public partial class клиенты_адм : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source = LAPTOP-LQGSO1AN\SQLEXPRESS; Initial Catalog = kurs3;Integrated Security = True ");
        SqlCommand sqlCommand = new SqlCommand();
        public клиенты_адм()
        {
            InitializeComponent();
            connection.Open();
            string cmd = "SELECT *FROM [Клиент]";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("[Клиент]");
            dataAdp.Fill(dt);
            Клиенты.ItemsSource = dt.DefaultView;
            connection.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            connection.Open();
            string sql = string.Format("Insert into [Клиент] ([ФИО] ,[Количество заказов] ,[Организация],[Телефон])values(@FI,@kol,@org,@ph)");

            using (SqlCommand cmd = new SqlCommand(sql, this.connection))
            {
                cmd.CommandText = "Insert into [Клиент] ([ФИО] ,[Количество заказов] ,[Организация],[Телефон])values(@FI,@kol,@org,@ph)";
                cmd.Parameters.AddWithValue("@FI", Fio.Text);
                cmd.Parameters.AddWithValue("@kol", "0");
                cmd.Parameters.AddWithValue("@org", Орг.Text);
                cmd.Parameters.AddWithValue("@ph", Телефон.Text);

                try
                { cmd.ExecuteNonQuery(); }
                catch
                { MessageBox.Show("Облом!"); }
                finally { connection.Close(); }
                
            }
            клиенты_адм taskWindow = new клиенты_адм();
            taskWindow.Show();
            this.Close();
            connection.Close();
        }
    }
}
