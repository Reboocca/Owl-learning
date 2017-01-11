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
        string sCurrentDate = DateTime.Now.ToString("yyyy-MM-dd");
        string sChosenDate;
        string sGekozenVakId;
        string sGekozenLesonderwerpId;


        struct Vakken
        {
            public string VakNaam {get;set;}
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
            public string LeerlingVoornaam { get; set; }
            public string LeerlingAchternaam { get; set; }
            public string LeerlingId { get; set; }
        }
        public PlanningenBeheren()
        {
            InitializeComponent();
            FillCbKiesVak();
            cbKiesLes.IsEnabled = false;
            cbKiesLesonderdeel.IsEnabled = false;
        }
        #region Vullen van de comboboxen en listview
        public void PopulateLVLeerlingen()
        {
            DataTable dtLeerlingen = new DBS().getLeerlingen();
            List<Vakken> lstVakken = new List<Vakken>();

            foreach (DataRow drVakken in dtVakken.Rows)
            {
                lstVakken.Add(new Vakken() { VakId = drVakken[0].ToString(), VakNaam = drVakken[1].ToString() });
            }
            lvLeerlingen.ItemsSource = lstVakken;
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
            DataTable dtLesonderwerpen = new DBS().getLO(sGekozenVakId);
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
            DataTable dtLessen = new DBS().getLes(sGekozenLesonderwerpId);
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
                cbKiesLesonderdeel.IsEnabled = false;
                cbKiesLesonderdeel.ItemsSource = null;
                MessageBox.Show("Het gekozen lesonderwerp heeft nog geen lessen, voeg deze allereerst toe.", "Voeg een les toe");
                cbKiesLes.IsEnabled = false;
            }
        }
        #endregion
        private void btOpslaan_Click(object sender, RoutedEventArgs e)
        {
            if (cdCalendar.SelectedDate != null)
            {
                sChosenDate = cdCalendar.SelectedDate.Value.ToString("yyyy/MM/dd");
                MessageBox.Show(sChosenDate, sCurrentDate);
            }
            else
            {
                MessageBox.Show("U moet een datum selecteren in de kalender!", "Selecteer een datum");
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
    }
}
