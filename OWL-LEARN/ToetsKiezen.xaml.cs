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
    /// Interaction logic for ToetsKiezen.xaml
    /// </summary>
    public partial class ToetsKiezen : Window
    {
        string sGekozenVakId;
        string sGekozenLesonderwerpId;
        struct Vakken
        {
            public string VakNaam { get; set; }
            public string VakId { get; set; }
        }

        struct Lesonderdelen
        {
            public string Lesonderdeel { get; set; }
            public string LesonderdeelId { get; set; }
        }

        string user;

        public ToetsKiezen(string username)
        {
            InitializeComponent();
            user = username;
            FillCbKiesVak();
            cbKiesLesonderdeel.IsEnabled = false;
            GetUser();
        }

        DBS dbs = new DBS();

        private void GetUser()
        {
            string sUserNaam = dbs.getUserNaam(user).ToString();
            lbUser.Content = sUserNaam;
        }

        private void btVerder_Click(object sender, RoutedEventArgs e)
        {
            if (cbKiesLesonderdeel.SelectedIndex == -1)
            {
                MessageBox.Show("Kies eerst een lesonderwerp om verder te gaan =)", "Oh!");
            }

            else //Anders
            {
                string sLesOnderwerpID = ((Lesonderdelen)(cbKiesLesonderdeel.SelectedItem)).LesonderdeelId;

                if (dbs.CountLessen(sLesOnderwerpID) == dbs.CountLessenVoortgang(user, sLesOnderwerpID))
                {
                    Toetsform newform = new Toetsform(user, sLesOnderwerpID);
                    newform.Show();
                    this.Close(); 
                }
                else
                {
                    MessageBox.Show("Je hebt nog niet alle lessen voltooid die bij het lesonderwerp horen.", "Je kan de toets niet maken!");
                }
            } 
        }

        public void FillCbKiesVak()
        {
            DataTable dtVakken = new DBS().GetVakken();
            List<Vakken> lstVakken = new List<Vakken>();

            foreach (DataRow drVakken in dtVakken.Rows)
            {
                lstVakken.Add(new Vakken() { VakId = drVakken[0].ToString(), VakNaam = drVakken[1].ToString() });
            }
            cbKiesVak.ItemsSource = lstVakken;
        }
        private void cbKiesVak_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbKiesVak.SelectedItem != null)
            {
                sGekozenVakId = ((Vakken)(cbKiesVak.SelectedItem)).VakId;
                FillCbLesonderdelen();
            }
        }

        public void FillCbLesonderdelen()
        {
            DataTable dtLesonderwerpen = new DBS().Search("toetsplanning", "VakID", sGekozenVakId);
            List<Lesonderdelen> lstLesonderwerpen = new List<Lesonderdelen>();
            if (dtLesonderwerpen.Rows.Count != 0)
            {
                foreach (DataRow drVakken in dtLesonderwerpen.Rows)
                {
                    lstLesonderwerpen.Add(new Lesonderdelen() { LesonderdeelId = drVakken[1].ToString(), Lesonderdeel = drVakken["toetsnaam"].ToString() });
                }
                cbKiesLesonderdeel.ItemsSource = lstLesonderwerpen;
                cbKiesLesonderdeel.IsEnabled = true;
            }
            else
            {
                cbKiesLesonderdeel.IsEnabled = false;
                cbKiesLesonderdeel.ItemsSource = null;
                MessageBox.Show("Het gekozen vak heeft nog toetsen open staan, contacteer de docent", "Oh jeetje!");
            }
        }

        private void cbKiesLO_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbKiesLesonderdeel.SelectedItem != null)
            {
                sGekozenLesonderwerpId = ((Lesonderdelen)(cbKiesLesonderdeel.SelectedItem)).LesonderdeelId;
            }
        }

        private void btTerug_Click(object sender, RoutedEventArgs e)
        {
            LeerlingForm terug = new LeerlingForm(user);
            terug.Show();
            this.Close();
        }
    }
}
