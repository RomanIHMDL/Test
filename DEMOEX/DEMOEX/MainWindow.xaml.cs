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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source = LAPTOP-LQGSO1AN\SQLEXPRESS; Initial Catalog = log1;Integrated Security = True ");
        SqlCommand sqlCommand = new SqlCommand();

        bool loginResultConnection = false; // login result
        bool weGetErrorOnConnection = false; // connection to server is fail'd?
        public MainWindow()
        {
            InitializeComponent();
            connection.Open();
            string cmd = "SELECT *FROM logpas";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("log1");
            dataAdp.Fill(dt);
            Leads.ItemsSource = dt.DefaultView;
            connection.Close();
        }

        #region GridShow
        Grid getGrid(Grid exclude)
        {
            var grid = new List<Grid>()
            {
                Login,
                Lids,
            }.First(s => s.Visibility == Visibility.Visible);
            if (grid == exclude)
                return null;
            return grid;
        }
        Grid prev = null;
        Grid next = null;

        void ChangeMenu(Grid prev, Grid next)
        {
            this.prev = prev;
            this.next = next;
            next.Opacity = 0;
            next.Visibility = Visibility.Visible;
            prev.Visibility = Visibility.Hidden;

            Storyboard strprev = new Storyboard();
            Storyboard strnext = new Storyboard();

            DoubleAnimation animfro = new DoubleAnimation(1, 0, new Duration(new TimeSpan(0, 0, 0, 0, 50)));
            DoubleAnimation animto = new DoubleAnimation(0, 1, new Duration(new TimeSpan(0, 0, 0, 0, 150)));

            strnext.Children.Add(animto);
            Storyboard.SetTargetProperty(animto, new PropertyPath("Opacity"));
            Storyboard.SetTarget(animto, next);

            strprev.Children.Add(animfro);
            Storyboard.SetTargetProperty(animfro, new PropertyPath("Opacity"));
            Storyboard.SetTarget(animfro, prev);

            strprev.Begin();
            strnext.Begin();
        }
        #endregion
        #region Buttons
        private void Button_Click(object sender, RoutedEventArgs e)//Login
        {
            
            if (Login1.Text.Length > 0 && Password.Text.Length > 0)
            {
                try
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandTimeout = 12 * 3600;

                    // Start connection
                    connection.Open();

                    // Check database to containt user login
                    sqlCommand.CommandText = "SELECT login FROM logpas WHERE (login='" + Login1.Text + "' AND password='" + Password.Text + "')";
                    var serverAnswerResult = sqlCommand.ExecuteReader();

                    loginResultConnection = serverAnswerResult.HasRows;

                    // Close connection 
                    connection.Close();
                    
                }
                catch (Exception ex)
                {
                    // Close.  
                    connection.Close();

                    MessageBox.Show("Connection to servar failure\nError code (" + ex.ToString() + ")\nTry again later.", "Server error.", MessageBoxButton.OK);
                    weGetErrorOnConnection = true;
                }

                if (loginResultConnection)
                {
                    Grid ad = getGrid(Lids);
                    if (ad == null)
                        return;
                    ChangeMenu(ad, Lids);
                    connection.Close();
                    klient taskWindow = new klient();
                    taskWindow.Show();
                    this.Close();

                }
                else if (!weGetErrorOnConnection)
                {
                    MessageBox.Show("Login error, password or login dosen't not match!\nTry again.", "Login error.", MessageBoxButton.OK);
                    connection.Close();
                }
            }
            else
                MessageBox.Show("Login or password filed is empty!", "Error.", MessageBoxButton.OK);
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Grid ad = getGrid(Login);
            if (ad == null)
                return;
            ChangeMenu(ad, Login);
            connection.Close();
        }

        private void button_exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void hideapp(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            adminvhod taskWindow = new adminvhod();
            taskWindow.Show();
            this.Close();
        }
    }

        #endregion
    
}
