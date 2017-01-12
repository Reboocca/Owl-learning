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
    /// Interaction logic for UserCMS.xaml
    /// </summary>
    public partial class UserCMS : Window
    {
        string user;
        public UserCMS(string username)
        {
            InitializeComponent();
            user = username;
        }
        DBS dbs = new DBS();
        string rolID = "0";
        struct Users
        {
            public string userID { get; set; }
            public string userName { get; set; }
        }

        private void btTerug_Click(object sender, RoutedEventArgs e)
        {
            ConsulentForm terug = new ConsulentForm(user);
            terug.Show();
            this.Close();
        }

        private void btBewerk_Click(object sender, RoutedEventArgs e)
        {
            if (lbLijst.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteer eerst een account om deze te bewerken.", "Let op!");
            }
            else
            {
               string userID = ((Users)(lbLijst.SelectedItem)).userID;
               AccountWijzigen Wform = new AccountWijzigen(user, userID);
               Wform.Show();
               this.Close();
            }
        }

        private void btVerwijder_Click(object sender, RoutedEventArgs e)
        {
            if (lbLijst.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteer eerst een account om deze te verwijderen.", "Let op!");
            }
            else
            {
                string userID = ((Users)(lbLijst.SelectedItem)).userID;
                dbs.DeleteUser(userID);
                FillLVLeerlingen();
            }
        }

        private void btVoegToe_Click(object sender, RoutedEventArgs e)
        {
            if (rolID == "0")
            {
                MessageBox.Show("Selecteer eerst een rol om een account hier aan toe te voegen.", "Let op!");
            }
            else
            {
                AccountToevoeg AcAdd = new AccountToevoeg(user, rolID);
                AcAdd.Show();
                this.Close();
            }
        }

        private void btDocent_Click(object sender, RoutedEventArgs e)
        {
            rolID = "1";
            List<Users> lstUsers = new List<Users>();

            DataTable dtUsers = dbs.getAccounts(rolID);

            foreach (DataRow row in dtUsers.Rows)
            {
                lstUsers.Add(new Users() { userID = row["userID"].ToString(), userName = row["firstName"].ToString()+" "+ row["lastName"].ToString() });
            }
            lbLijst.ItemsSource = lstUsers;
        }

        private void btLeerling_Click(object sender, RoutedEventArgs e)
        {
            FillLVLeerlingen();
        }

        public void FillLVLeerlingen()
        {
            rolID = "2";
            List<Users> lstUsers = new List<Users>();

            DataTable dtUsers = dbs.getAccounts(rolID);

            foreach (DataRow row in dtUsers.Rows)
            {
                lstUsers.Add(new Users() { userID = row["userID"].ToString(), userName = row["firstName"].ToString() + " " + row["lastName"].ToString() });
            }
            lbLijst.ItemsSource = lstUsers;
        }
    }
}
