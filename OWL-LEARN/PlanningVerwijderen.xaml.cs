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
        public PlanningVerwijderen()
        {
            InitializeComponent();
        }


       /* struct Leerlingen
        {
            public string LeerlingVoornaam { get; set; }
            public string LeerlingAchternaam { get; set; }
            public string LeerlingId { get; set; }
        }
        struct Lessen
        {
            public string LesNaam { get; set; }
            public string LesId { get; set; }
        }*/
        struct Datum
        {
            public string Date { get; set; }
            public string PlanningLeerlingId { get; set; }
            public string PlanningLesId { get; set; }
            public string SelectedPlanningId { get; set; }
        }

        private void PupulateLvPlanningen()
        {
            
        }
        private void btVerwijderPlanning_Click(object sender, RoutedEventArgs e)
        {
            if (lvPlanningen.SelectedItem != null)
            {

            }
            else
            {
                MessageBox.Show("U moet een planning selecteren voordat u er een kan verwijderen", "Selecteer een planning");
            }
        }

        private void lvPlanningen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sSelectedPlanning != null)
            {
                sSelectedPlanning = "";
            }
        }
    }
}
