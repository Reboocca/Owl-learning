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
    /// Interaction logic for LesonderwerpWijzig.xaml
    /// </summary>
    public partial class LesonderwerpWijzig : Window
    {
        public string loID;
        public LesonderwerpWijzig(string sloID)
        {
            InitializeComponent();
            loID = sloID;
            PopulateListBox();
        }

        DBS dbs = new DBS();

        struct Les
        {
            public string lID { get; set; }
            public string lNaam { get; set; }
        }
        private void btTerug_Click(object sender, RoutedEventArgs e)
        {
            LesOnderwerpCMS terug = new LesOnderwerpCMS();
            terug.Show();
            this.Close();
        }

        private void btWijzigNaam_Click(object sender, RoutedEventArgs e)
        {
            if(tbNaam.Text != "")
            {
                string newName = tbNaam.Text;
                dbs.changeNameLO(loID, newName);
            }
            else
            {
                MessageBox.Show("Vul eerst een nieuwe naam in het invoerveld in.", "Oh jee..");
            }

        }

        private void PopulateListBox()
        {
            List<Les> lstLes = new List<Les>();
            DataTable dtLes = new DBS().getLes(loID);

            foreach (DataRow row in dtLes.Rows)
            {
                lstLes.Add(new Les() { lID = row["LesID"].ToString(), lNaam = row["LesNaam"].ToString() });
            }
            lbLijst.ItemsSource = lstLes;
        }

        private void btVerwijder_Click(object sender, RoutedEventArgs e)
        {
            if (lbLijst.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteer eerst een les om deze te verwijderen.", "Let op!");
            }
            else
            {
                string lID = ((Les)(lbLijst.SelectedItem)).lID;
                dbs.DeleteLes(lID);
            }
        }

        private void btVoegToe_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
