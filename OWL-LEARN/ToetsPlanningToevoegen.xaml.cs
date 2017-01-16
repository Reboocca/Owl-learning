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
    /// Interaction logic for ToetsPlanningToevoegen.xaml
    /// </summary>
    public partial class ToetsPlanningToevoegen : Window
    {
        string sGekozenLeerlingUsername;
        string sGekozenVakId;
        string sGekozenLesonderdeelId;
        string sGekozenLesonderdeelNaam;
        string sGekozenVakID;
        string sToetsNaam;
        string sGekozenLeerlingId;
        DateTime dtChosenDate;
        struct Vakken
        {
            public string VakNaam { get; set; }
            public string VakId { get; set; }
        }
        struct LvLeerlingInfo
        {
            public string LeerlingVoornaam { get; set; }
            public string LeerlingAchternaam { get; set; }
            public string LeerlingUsername { get; set; }
            public string LeerlingId { get; set; }
        }
        struct Lesonderdelen
        {
            public string Lesonderdeel { get; set; }
            public string LesonderdeelId { get; set; }
        }

        string user;
        
        public ToetsPlanningToevoegen(string username)
        {
            InitializeComponent();
            PopulateLvLeerlingen();
            FillCbKiesVak();
            cbKiesLesonderdeel.IsEnabled = false;
            user = username;
        }

        private void PopulateLvLeerlingen()
        {
            DataTable dtLeerlingen = new DBS().Search("users", "RolID", "2");
            List<LvLeerlingInfo> lstLeerlingen = new List<LvLeerlingInfo>();

            foreach (DataRow drLeerlingen in dtLeerlingen.Rows)
            {
                lstLeerlingen.Add(new LvLeerlingInfo() { LeerlingUsername = drLeerlingen[1].ToString(), LeerlingVoornaam = drLeerlingen[3].ToString(), LeerlingId = drLeerlingen[0].ToString(), LeerlingAchternaam = drLeerlingen[4].ToString() });
            }
            lvLeerlingen.ItemsSource = lstLeerlingen;
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
            DataTable dtLesonderwerpen = new DBS().Search("lesonderwerp", "VakID", sGekozenVakId);
            List<Lesonderdelen> lstLesonderwerpen = new List<Lesonderdelen>();
            if (dtLesonderwerpen.Rows.Count != 0)
            {
                foreach (DataRow drVakken in dtLesonderwerpen.Rows)
                {
                    lstLesonderwerpen.Add(new Lesonderdelen() { LesonderdeelId = drVakken[0].ToString(), Lesonderdeel = drVakken[1].ToString() });
                }
                cbKiesLesonderdeel.ItemsSource = lstLesonderwerpen;
                cbKiesLesonderdeel.IsEnabled = true;
            }
            else
            {
                cbKiesLesonderdeel.IsEnabled = false;
                cbKiesLesonderdeel.ItemsSource = null;
                MessageBox.Show("Het gekozen vak heeft nog geen lesonderwerpen, voeg deze allereerst toe.", "Voeg een lesonderwerp toe");
            }
        }

        private void lvLeerlingen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvLeerlingen.SelectedItem != null)
            {
                sGekozenLeerlingUsername = ((LvLeerlingInfo)(lvLeerlingen.SelectedItem)).LeerlingUsername;
                sGekozenLeerlingId = ((LvLeerlingInfo)(lvLeerlingen.SelectedItem)).LeerlingId;
            }
        }

        private void cbKiesLesonderdeel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbKiesLesonderdeel.SelectedItem != null)
            {
                sGekozenLesonderdeelId = ((Lesonderdelen)(cbKiesLesonderdeel.SelectedItem)).LesonderdeelId;
                sGekozenLesonderdeelNaam = ((Lesonderdelen)(cbKiesLesonderdeel.SelectedItem)).Lesonderdeel;
                sGekozenVakID = ((Vakken)(cbKiesVak.SelectedItem)).VakId;
                sToetsNaam = "Toets - " + sGekozenLesonderdeelNaam ;
                lblToetsNaam.Content = "De toetsnaam zal worden: " + sToetsNaam;
            }
        }

        private void btOpslaan_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtCheckExistance = new DBS().CheckExistancePlanning("toetsplanning", sGekozenLeerlingUsername, sGekozenLesonderdeelId, "lesonderwerpid");
            if (dtCheckExistance.Rows.Count != 0)
            {
                MessageBox.Show("De toetsplanning van de les in combinatie met de leerling bestaat al. Verwijder de huidige toetsplanning en maak een nieuwe aan.", "Toetsplanning bestaat al");
            }
            else
            {
                if (sGekozenLeerlingUsername != null)
                {
                    if (cbKiesLesonderdeel.SelectedItem != null)
                    {
                        if (cdCalendar.SelectedDate != null)
                        {
                            dtChosenDate = cdCalendar.SelectedDate.Value.Date;
                            new DBS().ToetsPlanningToevoegen(sGekozenLesonderdeelId, sGekozenLeerlingUsername, dtChosenDate, sGekozenLesonderdeelNaam, sGekozenLeerlingId, sGekozenVakID);
                        }
                        else
                        {
                            MessageBox.Show("U moet een datum selecteren in de kalender!", "Selecteer een datum");
                        }
                    }
                    else
                    {
                        MessageBox.Show("U heeft geen les geselecteerd waarvoor u deze planning wilt toevoegen", "Selecteer een les");
                    }
                }
                else
                {
                    MessageBox.Show("U heeft geen leerling geselecteerd waarvoor u deze planning wilt toevoegen", "Selecteer een leerling");
                }
            }
        }

        private void btTerug_Click(object sender, RoutedEventArgs e)
        {
            ToetsPlanningBeheren form = new ToetsPlanningBeheren(user);
            form.Show();
            this.Close();
        }
    }
}
