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
    // test
    /// <summary>
    /// Interaction logic for PlanningenBeheren.xaml
    /// </summary>
    public partial class PlanningenBeheren : Window
    {
        //sCurrentDate = DateTime.Now;
        string sGekozenVakId;
        string sGekozenLesonderwerpId;
        string sGekozenLesNaam = "";
        string sGekozenLeerlingId;
        string sGekozenLeerlingUsrname;
        string sGekozenLesId;
        public string user;


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

        struct Lessen
        {
            public string LesNaam { get; set; }
            public string LesId { get; set; }
        }
        struct leerlingen
        {
            public string LeerlingUsrname { get; set; }
            public string LeerlingVoornaam { get; set; }
            public string LeerlingAchternaam { get; set; }
            public string LeerlingId { get; set; }
        }
        public PlanningenBeheren(string username)
        {
            InitializeComponent();
            FillCbKiesVak();
            PopulateLVLeerlingen();
            cbKiesLes.IsEnabled = false;
            cbKiesLesonderdeel.IsEnabled = false;
            user = username;
        }
        #region Vullen van de comboboxen en listview
        public void PopulateLVLeerlingen()
        {
            DataTable dtLeerlingen = new DBS().Search("users", "RolID", "2");
            List<leerlingen> lstLeerlingen = new List<leerlingen>();

            foreach (DataRow drLeerlingen in dtLeerlingen.Rows)
            {
                lstLeerlingen.Add(new leerlingen() { LeerlingId = drLeerlingen[0].ToString(), LeerlingVoornaam = drLeerlingen[3].ToString(), LeerlingAchternaam = drLeerlingen[4].ToString(), LeerlingUsrname = drLeerlingen[1].ToString() });
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
        public void FillCbKiesLes()
        {
            DataTable dtLessen = new DBS().Search("Les", "LesOnderwerpID", sGekozenLesonderwerpId);
            List<Lessen> lstLes = new List<Lessen>();

            if (dtLessen.Rows.Count != 0)
            {
                foreach (DataRow drLessen in dtLessen.Rows)
                {
                    lstLes.Add(new Lessen() { LesId = drLessen[0].ToString(), LesNaam = drLessen[4].ToString() });
                }
                cbKiesLes.ItemsSource = lstLes;
                cbKiesLes.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Het gekozen lesonderwerp heeft nog geen lessen, voeg deze allereerst toe.", "Voeg een les toe");
                cbKiesLes.IsEnabled = false;
                cbKiesLes.ItemsSource = null;
            }
        }
        #endregion
        private void btOpslaan_Click(object sender, RoutedEventArgs e)
        {
             
            DataTable dtCheckExistancePlanning = new DBS().CheckExistancePlanning("planning", sGekozenLeerlingUsrname, sGekozenLesId, "lesid");
            if (dtCheckExistancePlanning.Rows.Count != 0)
            {
                MessageBox.Show("De planning van de les in combinatie met de leerling bestaat al. Verwijder de huidige planning en maak een nieuwe aan.", "Planning bestaat al");
            }
            else
            {
               
                if (cdCalendar.SelectedDate != null)
                {
                    DateTime dtChosenDate = cdCalendar.SelectedDate.Value.Date;
                    if (sGekozenLeerlingId != null)
                    {
                        if (sGekozenLesNaam != "")
                        {
                            new DBS().PlanningToevoegen(sGekozenLeerlingId, sGekozenLesId, dtChosenDate, sGekozenLesNaam, sGekozenLeerlingUsrname);
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
                else
                {
                    MessageBox.Show("U moet een datum selecteren in de kalender!", "Selecteer een datum");
                }
            }
        }

        private void cbKiesVak_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbKiesVak.SelectedItem != null)
            {
                sGekozenVakId = ((Vakken)(cbKiesVak.SelectedItem)).VakId;
                FillCbLesonderdelen();
            }
        }

        private void cbKiesLesonderdeel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbKiesLesonderdeel.SelectedItem != null)
            {
                sGekozenLesonderwerpId = ((Lesonderdelen)(cbKiesLesonderdeel.SelectedItem)).LesonderdeelId;
                FillCbKiesLes();
            }
        }

        private void lvLeerlingen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvLeerlingen.SelectedItem != null)
            {
                sGekozenLeerlingId = ((leerlingen)(lvLeerlingen.SelectedItem)).LeerlingId;
                sGekozenLeerlingUsrname = ((leerlingen)(lvLeerlingen.SelectedItem)).LeerlingUsrname;
            }
        }

        private void btPlanningVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            PlanningVerwijderen PV = new PlanningVerwijderen(user);
            PV.Show();
            this.Close();
        }

        private void btTerug_Click(object sender, RoutedEventArgs e)
        {
            PlanningVerwijderen PV = new PlanningVerwijderen(user);
            PV.Show();
            this.Close();
        }

        private void cbKiesLes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbKiesLes.SelectedItem != null)
            {
               sGekozenLesId = ((Lessen)(cbKiesLes.SelectedItem)).LesId;
               sGekozenLesNaam = ((Lessen)(cbKiesLes.SelectedItem)).LesNaam;
            }
        }
    }
}
