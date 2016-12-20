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
    /// Interaction logic for LeerlingForm.xaml
    /// </summary>
    public partial class LeerlingForm : Window
    {
        public LeerlingForm()
        {
            InitializeComponent();
            PopulateListBox();
        }

        struct Vak
        {
            public string ID { get; set; }
            public string VakNaam { get; set; }
        }

        struct LesOnderdeel
        {
            public string loID { get; set; }
            public string loNaam { get; set; }
        }
        struct Les
        {
            public string lID { get; set; }
            public string lNaam { get; set; }
        }

        private void PopulateListBox()
        {
            List<Vak> lstVakken = new List<Vak>();

            DataTable dtVakken = new DBS().GetVakken();

            foreach (DataRow row in dtVakken.Rows)
            {
                lstVakken.Add(new Vak() { ID = row["VakID"].ToString(), VakNaam = row["Omschrijving"].ToString() });
            }
            lbVakken.ItemsSource = lstVakken;
            
        }

        private void lbVakken_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sVakID = "";
            List<LesOnderdeel> lstLesOnderdeel = new List<LesOnderdeel>();
            if (lbVakken.SelectedItem != null)
            {
                sVakID = ((Vak)(lbVakken.SelectedItem)).ID;
            }

            DataTable dtLesOnderdeel = new DBS().getLO(sVakID);

            foreach (DataRow row in dtLesOnderdeel.Rows)
            {
                lstLesOnderdeel.Add(new LesOnderdeel() { loID = row["LesonderwerpID"].ToString(), loNaam = row["Omschrijving"].ToString() });
            }
            lbLesOnderdelen.ItemsSource = lstLesOnderdeel;
        }

        private void btTerug_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
            this.Close();
        }

        private void lbLesOnderdelen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sLO = "";
            List<Les> lstLes = new List<Les>();
            if (lbLesOnderdelen.SelectedItem != null)
            {
                sLO = ((LesOnderdeel)(lbLesOnderdelen.SelectedItem)).loID;
                DataTable dtLes = new DBS().getLes(sLO);

                foreach (DataRow row in dtLes.Rows)
                {
                    lstLes.Add(new Les() { lID = row["LesID"].ToString(), lNaam = row["LesNaam"].ToString() });
                }
                lbLes.ItemsSource = lstLes;
               
            }


        }

        private void btVerder_Click(object sender, RoutedEventArgs e)
        {
            if (lbLes.SelectedIndex == -1)
            {
                MessageBox.Show("Kies eerst een les om verder te gaan =)", "Oh!");
            }
            else
            {
                string sLesID = ((Les)(lbLes.SelectedItem)).lID;
                LesForm Les = new LesForm(sLesID);
                Les.Show();
                this.Close();
            }
        }
    }
}
