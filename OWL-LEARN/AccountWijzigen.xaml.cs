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
    /// Interaction logic for AccountWijzigen.xaml
    /// </summary>
    public partial class AccountWijzigen : Window
    {
        string user;
        string userID;
        public AccountWijzigen(string username, string userIDbewerk)
        {
            InitializeComponent();
            user = username;
            userID = userIDbewerk;
            PopulateTextBox();
        }
        DBS dbs = new DBS();
       
        private void PopulateTextBox()
        {
            DataTable dtGegevens = dbs.getGegevens(userID);
            foreach (DataRow row in dtGegevens.Rows)
            {
                tbVoorNaam.Text = row["firstName"].ToString();
                tbAchterNaam.Text = row["lastName"].ToString();
                tbGebruikersNaam.Text = row["Username"].ToString();
                tbWachtwoord.Text = row["Password"].ToString();
            }
        }

        private void btTerug_Click(object sender, RoutedEventArgs e)
        {
            UserCMS form = new UserCMS(user);
            form.Show();
            this.Close();
        }

        private void btOpslaan_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtCheckUserNameUnique = dbs.CheckUserExistance(tbGebruikersNaam.Text);
            if (dtCheckUserNameUnique.Rows.Count != 0)
            {
                string sCheckGebruikersnaamID = dtCheckUserNameUnique.Rows[0]["UserID"].ToString();
                if (sCheckGebruikersnaamID != userID)
                {
                    MessageBox.Show("Deze gebruikersnaam is al door iemand anders in gebruik, kies een andere, of de bij jouw behorende gebruikersnaam", "Kies een andere gebruikersnaam");
                }
                else
                {
                    ModifyUser();
                }
            }
            else
            {
                ModifyUser();
            }
        }
        
        public void ModifyUser()
        {
            dbs.safeAccount(user, tbVoorNaam.Text, tbAchterNaam.Text, tbGebruikersNaam.Text, tbWachtwoord.Text, userID, this);
        }
    }
}
