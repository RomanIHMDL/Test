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
    /// Логика взаимодействия для Zakaz.xaml
    /// </summary>
    public partial class Zakaz : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source = LAPTOP-LQGSO1AN\SQLEXPRESS; Initial Catalog = kurs3;Integrated Security = True ");
        SqlCommand sqlCommand = new SqlCommand();
        public Zakaz()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            string sql = string.Format("Insert into [Заказ] ([Дата] ,[Статус] ,[Номер договора])values(@Date,@Stat),@no");

            using (SqlCommand cmd = new SqlCommand(sql, this.connection))
            {
                
                cmd.CommandText = "Insert into [Заказ] ([Дата] ,[Статус] ,[Номер договора])values(@Date,@Stat,@no)";
                cmd.Parameters.AddWithValue("@Date", Дата.Text);
                cmd.Parameters.AddWithValue("@Stat", "Ожидает отправки");
                cmd.Parameters.AddWithValue("@no", Номер_договора.Text);
                try
                { cmd.ExecuteNonQuery(); }
                catch
                { MessageBox.Show("Облом!"); }
                finally { connection.Close(); }

                

           
                

            }
            connection.Close();
            string name = Номер_договора.Text; // получаем имя из текстового поля
            new Промежуток(name).ShowDialog(); // вызываем окно, передавая данные
            this.Close();
        }

       // private void Номер_договора_TextChanged(object sender, TextChangedEventArgs e)
        //{
          //  DataView dv = zak.ItemsSource as DataView;

            //string filter = Номер_договора.Text;
            //if (string.IsNullOrEmpty(filter))
            //{
              //  dv.RowFilter = null;

//            }
  //          else
    //        {
      //          dv.RowFilter = "[Номер договора] = " + Номер_договора.Text;

        //    }
        //}
    }
}