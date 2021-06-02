using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DEMOEX
{
    /// <summary>
    /// Логика взаимодействия для adminvhod.xaml
    /// </summary>
    public partial class adminvhod : Window
    {
        public adminvhod()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (pass.Text == "12345")
            {
                admin taskWindow = new admin();
                taskWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login or password filed is empty!", "Error.", MessageBoxButton.OK);
            }
        }
    }
}
