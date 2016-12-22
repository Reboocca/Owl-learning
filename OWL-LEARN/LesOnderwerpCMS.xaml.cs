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
    /// Interaction logic for LesOnderwerpCMS.xaml
    /// </summary>
    public partial class LesOnderwerpCMS : Window
    {
        public string user;
        public LesOnderwerpCMS(string username)
        {
            InitializeComponent();
            user = username;
        }

        public string selectedVak = "disabled";

        struct LesOnderdeel
        {
            public string loID { get; set; }
            public string loNaam { get; set; }
        }

        private void btGe_Click(object sender, RoutedEventArgs e)
        {
            selectedVak = "1";
            string sVakNaam = btGe.Content.ToString();
            List<LesOnderdeel> lstLesOnderdeel = new List<LesOnderdeel>();
            
            DataTable dtLesOnderdeel = new DBS().getLOcms(sVakNaam);

            foreach (DataRow row in dtLesOnderdeel.Rows)
            {
                lstLesOnderdeel.Add(new LesOnderdeel() { loID = row["LesonderwerpID"].ToString(), loNaam = row["Omschrijving"].ToString() });
            }
            lbLijst.ItemsSource = lstLesOnderdeel;
        }

        private void btEng_Click(object sender, RoutedEventArgs e)
        {
            selectedVak = "5";
            string sVakNaam = btEng.Content.ToString();
            List<LesOnderdeel> lstLesOnderdeel = new List<LesOnderdeel>();

            DataTable dtLesOnderdeel = new DBS().getLOcms(sVakNaam);

            foreach (DataRow row in dtLesOnderdeel.Rows)
            {
                lstLesOnderdeel.Add(new LesOnderdeel() { loID = row["LesonderwerpID"].ToString(), loNaam = row["Omschrijving"].ToString() });
            }
            lbLijst.ItemsSource = lstLesOnderdeel;
        }

        private void btRekenen_Click(object sender, RoutedEventArgs e)
        {
            selectedVak = "2";
            string sVakNaam = btRekenen.Content.ToString();
            List<LesOnderdeel> lstLesOnderdeel = new List<LesOnderdeel>();

            DataTable dtLesOnderdeel = new DBS().getLOcms(sVakNaam);

            foreach (DataRow row in dtLesOnderdeel.Rows)
            {
                lstLesOnderdeel.Add(new LesOnderdeel() { loID = row["LesonderwerpID"].ToString(), loNaam = row["Omschrijving"].ToString() });
            }
            lbLijst.ItemsSource = lstLesOnderdeel;
        }

        private void btBio_Click(object sender, RoutedEventArgs e)
        {
            selectedVak = "3";
            string sVakNaam = btBio.Content.ToString();
            List<LesOnderdeel> lstLesOnderdeel = new List<LesOnderdeel>();

            DataTable dtLesOnderdeel = new DBS().getLOcms(sVakNaam);

            foreach (DataRow row in dtLesOnderdeel.Rows)
            {
                lstLesOnderdeel.Add(new LesOnderdeel() { loID = row["LesonderwerpID"].ToString(), loNaam = row["Omschrijving"].ToString() });
            }
            lbLijst.ItemsSource = lstLesOnderdeel;
        }

        private void btNed_Click(object sender, RoutedEventArgs e)
        {
            selectedVak = "4";
            string sVakNaam = btNed.Content.ToString();
            List<LesOnderdeel> lstLesOnderdeel = new List<LesOnderdeel>();

            DataTable dtLesOnderdeel = new DBS().getLOcms(sVakNaam);

            foreach (DataRow row in dtLesOnderdeel.Rows)
            {
                lstLesOnderdeel.Add(new LesOnderdeel() { loID = row["LesonderwerpID"].ToString(), loNaam = row["Omschrijving"].ToString() });
            }
            lbLijst.ItemsSource = lstLesOnderdeel;
        }

        private void btTerug_Click(object sender, RoutedEventArgs e)
        {
            ConsulentForm terug = new ConsulentForm(user);
            terug.Show();
            this.Close();
        }

        private void btVoegToe_Click(object sender, RoutedEventArgs e)
        {
            if (selectedVak == "disabled")
            {
                MessageBox.Show("Klik eerst op een vak en lesonderwerp om verder te gaan", "Er is een fout opgetreden...");
            }
            else if (selectedVak != "disabled")
            {
                LesonderwerpToevoegen LOT = new LesonderwerpToevoegen(selectedVak, user);
                LOT.Show();
                this.Close();
            }
        }

        private void btVerwijder_Click(object sender, RoutedEventArgs e)
        {
            if (lbLijst.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteer eerst een Lesonderwerp om deze te verwijderen.", "Let op!");
            }
            else
            {
                string loID = ((LesOnderdeel)(lbLijst.SelectedItem)).loID;
                DBS Class = new DBS();
                Class.DeleteLO(loID);
            }
        }

        private void btBewerk_Click(object sender, RoutedEventArgs e)
        {
            if (lbLijst.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteer eerst een Lesonderwerp om deze te bewerken.", "Let op!");
            }
            else
            {
                string loID = ((LesOnderdeel)(lbLijst.SelectedItem)).loID;
                LesonderwerpWijzig LOW = new LesonderwerpWijzig(loID, user);
                LOW.Show();
                this.Close();
            }
        }
    }
}
