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
    /// Interaction logic for PlanningVerwijderen.xaml
    /// </summary>
    public partial class PlanningVerwijderen : Window
    {
        string sSelectedPlanning;
        string sGekozenLeerlingId;
        public PlanningVerwijderen()
        {
            InitializeComponent();
            PopulateLvLeerlingen();
        }
        struct LvLeerlingInfo
        {
            public string LeerlingVoornaam { get; set; }
            public string LeerlingAchternaam { get; set; }
            public string LeerlingId { get; set; }
        }
        struct LvPlanningInfo
        {
            public string Date { get; set; }
            public string PlanningLesId { get; set; }
            public string SelectedPlanningId { get; set; }
            public string LesNaam { get; set; }
        }

        private void PopulateLvLeerlingen()
        {
            DataTable dtLeerlingen = new DBS().Search("users", "RolID", "2");
            List<LvLeerlingInfo> lstLeerlingen = new List<LvLeerlingInfo>();

            foreach (DataRow drLeerlingen in dtLeerlingen.Rows)
            {
                lstLeerlingen.Add(new LvLeerlingInfo() { LeerlingId = drLeerlingen[0].ToString(), LeerlingVoornaam = drLeerlingen[3].ToString(), LeerlingAchternaam = drLeerlingen[4].ToString() });
            }
            lvLeerlingen.ItemsSource = lstLeerlingen;
        }
        private void PopulateLvPlanningen()
        {
            DataTable dtPlanningen = new DBS().Search("planning", "leerlingid", sGekozenLeerlingId);
            List<LvPlanningInfo> lstPlanninginfo = new List<LvPlanningInfo>();
            int iCounterDatum = 0;

            foreach (DataRow drPlanningen in dtPlanningen.Rows)
            {
                lstPlanninginfo.Add(new LvPlanningInfo() { SelectedPlanningId = drPlanningen[0].ToString(), PlanningLesId = drPlanningen[2].ToString(), Date = Convert.ToDateTime(dtPlanningen.Rows[iCounterDatum]["datum"]).ToString("dd/MM/yyyy"), LesNaam = drPlanningen[4].ToString() });
                iCounterDatum++;
            }

            lvPlanningen.ItemsSource = lstPlanninginfo;
        }
        private void btVerwijderPlanning_Click(object sender, RoutedEventArgs e)
        {
            if (lvLeerlingen.SelectedItem != null)
            {
                if (lvPlanningen.SelectedItem != null)
                {
                    MessageBoxResult DeleteYesNo = MessageBox.Show("Weet je zeker dat je deze planning wilt verwijderen?", "Foutmelding", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
                    if (DeleteYesNo == MessageBoxResult.Yes)
                    {
                        new DBS().DeletePlanning(sSelectedPlanning);
                        PopulateLvPlanningen();
                    }
                }
                else
                {
                    MessageBox.Show("U moet een planning selecteren voordat u er een kan verwijderen", "Selecteer een planning");
                }
            }
            else
            {
                MessageBox.Show("U moet een leerling selecteren voordat u een planning kan verwijderen", "Selecteer een leerling");
            }
        }

        private void lvPlanningen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvPlanningen.SelectedItem != null)
            {
                sSelectedPlanning = ((LvPlanningInfo)(lvPlanningen.SelectedItem)).SelectedPlanningId;
            }
        }

        private void lvLeerlingen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvLeerlingen.SelectedItem != null)
            {
                sGekozenLeerlingId = ((LvLeerlingInfo)(lvLeerlingen.SelectedItem)).LeerlingId;
                PopulateLvPlanningen();
            }
        }
    }
}
