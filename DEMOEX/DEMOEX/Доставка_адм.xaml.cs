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
    /// Логика взаимодействия для Доставка_адм.xaml
    /// </summary>
    public partial class Доставка_адм : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source = LAPTOP-LQGSO1AN\SQLEXPRESS; Initial Catalog = kurs3;Integrated Security = True ");
        SqlCommand sqlCommand = new SqlCommand();
        public Доставка_адм()
        {
            InitializeComponent();
            connection.Open();
            string cmd = "SELECT *FROM [Доставка]";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("[Доставка]");
            dataAdp.Fill(dt);
            Доставки.ItemsSource = dt.DefaultView;
            connection.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            {
                connection.Open();
                string sql = string.Format("Insert into [Доставка] ([Дата] ,[ФИО Курьера] ,[Номер заказа])values(@dt,@fio,@no)");

                using (SqlCommand cmd = new SqlCommand(sql, this.connection))
                {
                    cmd.CommandText = "Insert into [Доставка] ([Дата] ,[ФИО Курьера] ,[Номер заказа])values(@dt,@fio,@no)";
                    cmd.Parameters.AddWithValue("@dt", Дата.Text);
                    cmd.Parameters.AddWithValue("@fio", ФИОКУР.Text);
                    cmd.Parameters.AddWithValue("@no", НОМЕРЗАК.Text);

                    try
                    { cmd.ExecuteNonQuery(); }
                    catch
                    { MessageBox.Show("Облом!"); }
                    finally { connection.Close(); }
                }
                Доставка_адм taskWindow = new Доставка_адм();
                taskWindow.Show();
                this.Close();
            }
        }
    }
}
