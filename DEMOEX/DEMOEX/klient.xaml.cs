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
    /// Логика взаимодействия для klient.xaml
    /// </summary>
    public partial class klient : Window
    {
        public klient()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Zakluchenie_dogovora taskWindow = new Zakluchenie_dogovora();
            taskWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Каталог taskWindow = new Каталог();
            taskWindow.Show();
            this.Close();
        }

        private void Заказать_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
