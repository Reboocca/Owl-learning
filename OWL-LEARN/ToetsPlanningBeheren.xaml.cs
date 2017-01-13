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
    /// Interaction logic for ToetsPlanningBeheren.xaml
    /// </summary>
    public partial class ToetsPlanningBeheren : Window
    {
        struct LvLeerlingInfo
        {
            public string LeerlingVoornaam { get; set; }
            public string LeerlingAchternaam { get; set; }
            public string LeerlingId { get; set; }
        }
        public ToetsPlanningBeheren()
        {
            InitializeComponent();
            PopulateLvLeerlingen();
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

        private void btAddToetsPlanning_Click(object sender, RoutedEventArgs e)
        {
            ToetsPlanningToevoegen TPT = new ToetsPlanningToevoegen();
            TPT.Show();
            this.Close();
        }
    }
}
