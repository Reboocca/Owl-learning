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
        public ConsulentForm()
        {
            InitializeComponent();
        }

        struct LesOnderdeel
        {
            public string loID { get; set; }
            public string loNaam { get; set; }
        }

        struct Users
        {
            public string uID { get; set; }
            public string uFirstName { get; set; }
            public string uLastName { get; set; }
        }

        private void btTerug_Click(object sender, RoutedEventArgs e)
        {
            LesOnderwerpCMS login = new LesOnderwerpCMS();
            login.Show();
            this.Hide();
        }

        private void btLeerling_Click(object sender, RoutedEventArgs e)
        {
            lbContent.Content = "Kies een lesonderwerp";
        }

        private void btLes_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
