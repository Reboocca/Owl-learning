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
        public PlanningenBeheren()
        {
            InitializeComponent();
            FillCbKiesVak();
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
            DataTable dtVakken = new DBS().getLOnaam(sGekozenVakId);
            List<Lesonderdelen> lstVakken = new List<Lesonderdelen>();

            foreach (DataRow drVakken in dtVakken.Rows)
            {
                lstVakken.Add(new Lesonderdelen() { LesonderdeelId = drVakken[0].ToString(), Lesonderdeel = drVakken[1].ToString() });
            }
            cbKiesLesonderdeel.ItemsSource = lstVakken;
        }
        public void FillCbKiesLes()
        {
            DataTable dtVakken = new DBS().getLOnaam(sGekozenVakId);
            List<Lesonderdelen> lstVakken = new List<Lesonderdelen>();

            foreach (DataRow drVakken in dtVakken.Rows)
            {
                lstVakken.Add(new Lesonderdelen() { LesonderdeelId = drVakken[0].ToString(), Lesonderdeel = drVakken[1].ToString() });
            }
            cbKiesLesonderdeel.ItemsSource = lstVakken;
        }
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
    }
}
