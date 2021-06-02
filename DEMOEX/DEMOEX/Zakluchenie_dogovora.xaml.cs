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
    /// Логика взаимодействия для Zakluchenie_dogovora.xaml
    /// </summary>
    public partial class Zakluchenie_dogovora : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source = LAPTOP-LQGSO1AN\SQLEXPRESS; Initial Catalog = kurs3;Integrated Security = True ");
        SqlCommand sqlCommand = new SqlCommand();
        public Zakluchenie_dogovora()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            connection.Open();
            string sql = string.Format("Insert into [Договора] ([Дата договора] ,[Срок до] ,[Номер клиента])values(@Date,@Date1,@ID)");

            using (SqlCommand cmd = new SqlCommand(sql, this.connection))
            {
                cmd.CommandText = "Insert into [Договора] ([Дата договора] ,[Срок до] ,[Номер клиента])values(@Date,@Date1,@ID)";
                cmd.Parameters.AddWithValue("@Date", Дата_договора.Text);
                cmd.Parameters.AddWithValue("@Date1", Срок_до.Text);
                cmd.Parameters.AddWithValue("@ID", Номер_клиента.Text);
                { MessageBox.Show("Заявление подано. После согласования вам придет сообщение!"); }
                try
                { cmd.ExecuteNonQuery(); }
                catch
                { MessageBox.Show("Облом!"); }
                finally { connection.Close(); }
            }

            connection.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            klient taskWindow = new klient();
            taskWindow.Show();
            this.Close();
        }
    }



}
    


