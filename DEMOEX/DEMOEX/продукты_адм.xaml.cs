using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
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
    /// Логика взаимодействия для продукты_адм.xaml
    /// </summary>
    public partial class продукты_адм : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source = LAPTOP-LQGSO1AN\SQLEXPRESS; Initial Catalog = kurs3;Integrated Security = True ");
        SqlCommand sqlCommand = new SqlCommand();

        public продукты_адм()
        {

            InitializeComponent();
            connection.Open();

            string cmd = "SELECT *FROM [Продукты питания]";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("[Продукты питания]");
            dataAdp.Fill(dt);
            
            Продукты.ItemsSource = dt.DefaultView;

            connection.Close();
        }

        private void Продукты_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            string sql = string.Format("Insert into [Продукты питания] ([Количество на складе] ,[Название] ,[Цена])values(@kol,@nm,@mon)");

            using (SqlCommand cmd = new SqlCommand(sql, this.connection))
            {
                cmd.CommandText = "Insert into [Продукты питания] ([Количество на складе] ,[Название] ,[Цена])values(@kol,@nm,@mon)";
                cmd.Parameters.AddWithValue("@kol", Колич.Text);
                cmd.Parameters.AddWithValue("@nm", Название.Text);
                cmd.Parameters.AddWithValue("@mon", Цена.Text);
                
                try
                { cmd.ExecuteNonQuery(); }
                catch
                { MessageBox.Show("Облом!"); }
                finally { connection.Close(); }
            }
            продукты_адм taskWindow = new продукты_адм();
            taskWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataGrid dg = Продукты;
            dg.SelectAllCells();
            dg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dg);
            dg.UnselectAllCells();
            String Clipboardresult = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            StreamWriter swObj = new StreamWriter("exportToExcel.csv");
            swObj.WriteLine(Clipboardresult);
            swObj.Close();
            Process.Start("exportToExcel.csv");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
