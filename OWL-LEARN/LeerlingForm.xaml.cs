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
        string user;
        public LeerlingForm(string userRol)
        {
            InitializeComponent();
            PopulateListBox();
            user = userRol;
            GetUser();
        }

        DBS dbs = new DBS();

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
        struct Planningen
        {
            public string Date { get; set; }
            public string PlanningLesId { get; set; }
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

            DataTable dtLesOnderdeel = dbs.Search("lesonderwerp", "VakID", sVakID);

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
            DataTable dtPlanningen = new DBS().Search("planning", "leerlingid", user);
            List<Les> lstLes = new List<Les>();
            int iCounterLes = 0;
            if (lbLesOnderdelen.SelectedItem != null)
            {
                sLO = ((LesOnderdeel)(lbLesOnderdelen.SelectedItem)).loID;
                DataTable dtLes = dbs.Search("Les", "LesOnderwerpID", sLO);

                foreach (DataRow row in dtPlanningen.Rows)
                {
                    foreach (DataRow rowsplanningen in dtLes.Rows)
                    {
                        if (dtPlanningen.Rows[iCounterLes]["lesid"] == dtLes.Rows[iCounterLes]["LesID"])
                        {
                            lstLes.Add(new Les() { lID = row["LesID"].ToString(), lNaam = row["LesNaam"].ToString() });
                        }
                    }
                    
                }
                
                lbLes.ItemsSource = lstLes;

            }

            /*string sLO = "";
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
               
            }*/
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
                LesForm Les = new LesForm(sLesID, user);
                Les.Show();
                this.Close();
            }
        }

        private void GetUser()
        {
            string sUserNaam = dbs.getUserNaam(user).ToString();
            lbUser.Content = sUserNaam;
        }

        private void btToets_Click(object sender, RoutedEventArgs e)
        {
            Toetsform newform = new Toetsform(user, "6");
            newform.Show();
            this.Close();
        }
    }
}
