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
using MySql.Data.MySqlClient;
using System.Data;

namespace OWL_LEARN
{
    /// <summary>
    /// Interaction logic for ConsulentForm.xaml
    /// </summary>
    public partial class ConsulentForm : Window
    {
        DBS dbs = new DBS();
        public string user;
        
        public ConsulentForm(string username)
        {
            InitializeComponent();
            user = username;
            GetUser();
        }
        
        private void btUit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow form = new MainWindow();
            form.Show();
            this.Close();
        }

        private void btLO_Click(object sender, RoutedEventArgs e)
        {
            LesOnderwerpCMS lo = new LesOnderwerpCMS(user);
            lo.Show();
            this.Close();
        }

        private void GetUser()
        {
            string sUserNaam = dbs.getUserNaam(user).ToString();
            lbUser.Content = sUserNaam;

        }

        private void btUser_Click(object sender, RoutedEventArgs e)
        {
            UserCMS ac = new UserCMS(user);
            ac.Show();
            this.Close();
        }

        private void btPlanningMaken_Click(object sender, RoutedEventArgs e)
        {
            PlanningenBeheren PB = new PlanningenBeheren();
            PB.Show();
            this.Close();
        }
    }
}
