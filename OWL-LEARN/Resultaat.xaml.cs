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
    /// Interaction logic for Resultaat.xaml
    /// </summary>
    public partial class Resultaat : Window
    {
        DBS db = new DBS();
        public string user;
        public string lesonderwerp;
        public string voldoende_onvoldoende;
        public string resultaat;
        public string message;

        public Resultaat(string username, string sVolOnv, string sLesonderwerp, string sResultaat)
        {
            InitializeComponent();
            user = username;
            resultaat = sResultaat;
            voldoende_onvoldoende = sVolOnv;
            lesonderwerp = sLesonderwerp;
            PopulateForm();
        }

        private void btVerder_Click(object sender, RoutedEventArgs e)
        {
            LeerlingForm lf = new LeerlingForm(user);
            lf.Show();
            this.Close();
        }

        private void PopulateForm()
        {

            DataTable dtMessage = db.ResultaatMessage(lesonderwerp);

            foreach (DataRow row in dtMessage.Rows)
            {
                if (voldoende_onvoldoende == "perfect")
                {
                    message =   "Super gedaan! Je hebt gewoon een dikke vette " + resultaat + " gehaald voor de toets " + row[0].ToString() + " van " + row[1].ToString() 
                                + ". Daar kun je zeker trots op zijn! Dit punt wordt nu opgeslagen en kun je terugzien op jouw cijferlijst.";
                    imPerf.Visibility = System.Windows.Visibility.Visible;
                }
                else if (voldoende_onvoldoende == "voldoende")
                {
                    message =   "Wat goed gedaan! Je hebt een " + resultaat + " gehaald voor de toets " + row[0].ToString() + " van " + row[1].ToString()
                                + ". Ga zo door! Dit punt wordt nu opgeslagen en kun je terugzien op jouw cijferlijst.";
                    imGud.Visibility = System.Windows.Visibility.Visible;
                }
                else if (voldoende_onvoldoende == "onvoldoende")
                {
                    message =   "Oh, wat jammer.. Je hebt een " + resultaat + " gehaald voor de toets " + row[0].ToString() + " van " + row[1].ToString()
                                + ". Volgende keer beter! Dit punt wordt nu opgeslagen en kun je terugzien op jouw cijferlijst.";
                    imBad.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    message = "Sorry er is iets mis gegaan, roep de meester of juf.";
                }
            }
            
            lbCijfer.Content = resultaat;
            tbMessage.Text = message;

        }
    }
}
