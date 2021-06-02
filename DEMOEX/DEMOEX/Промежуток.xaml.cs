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
    /// Логика взаимодействия для Промежуток.xaml
    /// </summary>
    public partial class Промежуток : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source = LAPTOP-LQGSO1AN\SQLEXPRESS; Initial Catalog = kurs3;Integrated Security = True ");
        SqlCommand sqlCommand = new SqlCommand();
        public Промежуток(string name)
        {
            InitializeComponent();
            InitializeComponent();
            connection.Open();
            string cmd = "SELECT *FROM [Заказ]";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("[Заказ]");
            dataAdp.Fill(dt);
            zak.ItemsSource = dt.DefaultView;
            connection.Close();
            поиск.Text += name;

        }

        private void поиск_TextChanged(object sender, TextChangedEventArgs e)
        {
            {


                DataView dv = zak.ItemsSource as DataView;

                string filter = поиск.Text;
                if (string.IsNullOrEmpty(filter))
                {
                    dv.RowFilter = null;

                }
                else
                {
                    dv.RowFilter = "[Номер договора] = " + поиск.Text;

                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Prodolzh taskWindow = new Prodolzh();
            taskWindow.Show();
            this.Close();
        }
    }
}
