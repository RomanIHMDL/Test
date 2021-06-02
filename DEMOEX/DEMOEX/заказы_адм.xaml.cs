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
using System.IO;


namespace DEMOEX
{
    /// <summary>
    /// Логика взаимодействия для заказы_адм.xaml
    /// </summary>
    public partial class заказы_адм : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source = LAPTOP-LQGSO1AN\SQLEXPRESS; Initial Catalog = kurs3;Integrated Security = True ");
        SqlCommand sqlCommand = new SqlCommand();
        public заказы_адм()
        {
            InitializeComponent();
            connection.Open();
            string cmd = "SELECT *FROM [Заказ]";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("[Заказ]");
            dataAdp.Fill(dt);
            заказы.ItemsSource = dt.DefaultView;
            connection.Close();
        }

        private void заказы_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }




        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            sqlCommand.CommandText = ("UPDATE [Заказ] SET [статус]  = '" + Stat.Text + "'  WHERE [Номер заказа] = '" + Nomer.Text + "'");


           
            { cmd.ExecuteNonQuery(); }
          

            connection.Close();
            заказы_адм taskWindow = new заказы_адм();
            taskWindow.Show();
            this.Close();
            
        }
    }



    
 }

