using System;
using System.Collections.Generic;
using System.Data;
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

namespace OWL_LEARN
{
    /// <summary>
    /// Interaction logic for AccountToevoeg.xaml
    /// </summary>
    public partial class AccountToevoeg : Window
    {
        string user;
        string rolID;

        public AccountToevoeg(string username, string srolID)
        {
            InitializeComponent();
            user = username;
            rolID = srolID;
        }

        DBS dbs = new DBS();
        private void btOpslaan_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtCheckUserExistance = dbs.CheckUserExistance(tbGebruikersNaam.Text);
            if (dtCheckUserExistance.Rows.Count != 0)
            {
                MessageBox.Show("Deze gebruikersnaam bestaat al, kies een andere, unieke, gebruikersnaam", "Kies een andere gebruikersnaam");
            }
            else
            {
                dbs.newAccount(user, rolID, tbVoorNaam.Text, tbAchterNaam.Text, tbGebruikersNaam.Text, tbWachtwoord.Text, this);
            }
        }

        private void btTerug_Click(object sender, RoutedEventArgs e)
        {
            UserCMS form = new UserCMS(user);
            form.Show();
            this.Close();

        }
    }
}
