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
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace DEMOEX
{
    /// <summary>
    /// Логика взаимодействия для Оплата_адм.xaml
    /// </summary>
    public partial class Оплата_адм : System.Windows.Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source = LAPTOP-LQGSO1AN\SQLEXPRESS; Initial Catalog = kurs3;Integrated Security = True ");
        SqlCommand sqlCommand = new SqlCommand();
        public Оплата_адм()
        {
            InitializeComponent();
            connection.Open();
            string cmd = "SELECT *FROM [Оплата]";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("[Оплата]");
            dataAdp.Fill(dt);
            Оплата.ItemsSource = dt.DefaultView;
            connection.Close();
        }

        private void Оплата_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            {
                connection.Open();
                string sql = string.Format("Insert into [Оплата] ([Дата оплаты] ,[Сумма] ,[Номер договора])values(@dt,@sum,@no)");

                using (SqlCommand cmd = new SqlCommand(sql, this.connection))
                {
                    cmd.CommandText = "Insert into [Оплата] ([Дата оплаты] ,[Сумма] ,[Номер договора])values(@dt,@sum,@no)";
                    cmd.Parameters.AddWithValue("@dt", дата.Text);
                    cmd.Parameters.AddWithValue("@sum", сумма.Text);
                    cmd.Parameters.AddWithValue("@no", номер.Text);

                    try
                    { cmd.ExecuteNonQuery(); }
                    catch
                    { MessageBox.Show("Облом!"); }
                    finally { connection.Close(); }
                }
                Оплата_адм taskWindow = new Оплата_адм();
                taskWindow.Show();
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;
                Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

                for (int j = 0; j < Оплата.Columns.Count; j++)
                {
                    Range myRange = (Range)sheet1.Cells[1, j + 1];
                    sheet1.Cells[1, j + 1].Font.Bold = true;
                    sheet1.Columns[j + 1].ColumnWidth = 15;
                    myRange.Value2 = Оплата.Columns[j].Header;
                }
                for (int i = 0; i < Оплата.Columns.Count; i++)
                {
                    for (int j = 0; j < Оплата.Items.Count; j++)
                    {
                        TextBlock b = Оплата.Columns[i].GetCellContent(Оплата.Items[j]) as TextBlock;
                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                        myRange.Value2 = b.Text;
                    }
                }
            }
        }
    }
}
