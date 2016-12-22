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
    /// Interaction logic for LesForm.xaml
    /// </summary>
    public partial class LesForm : Window
    {
        DBS db = new DBS();
        public string user;
        public string _psLesID;
        public string _psUitleg;
        public int _piRadioButton;
        List<string> _lsVragen = new List<string>();
        List<string> _lstVraagIDs = new List<string>();
        List<string> _lstAntwoorden = new List<string>();
        int _iIndex = 0;

        public LesForm(string slesID, string username)
        {
            InitializeComponent();
            user = username;
            GetUser();
            _psLesID = slesID; 
            PopulateUitleg();
            PopulateVraagLijst();
            NextQuestion();
            
        }

        private void PopulateUitleg()
        {
            DataTable dtUitleg = db.GetUitleg(_psLesID);

            foreach (DataRow row in dtUitleg.Rows)
            {
                _psUitleg = row["Uitleg"].ToString();
            }

            tblUitleg.Text = _psUitleg;
        }

        private void PopulateVraagLijst()
        {
            DataTable dtVraag = db.GetVraag(_psLesID);

            foreach (DataRow row in dtVraag.Rows)
            {
                _lsVragen.Add(row["Vraag"].ToString());
                _lstVraagIDs.Add(row["VraagID"].ToString());
            }
        }

        private void NextQuestion()
        {
            string sContentButton = btVerder.Content.ToString();

            if (sContentButton == "Verder")
            {
                if (_iIndex < _lsVragen.Count)
                {
                    lbVraag.Content = _lsVragen[_iIndex];
                    lbVraagID.Content = _lstVraagIDs[_iIndex];
                    _iIndex++;

                    PopulateAntwoordLijst();
                }
                else
                {
                    MessageBox.Show("De les is voltooid!", "Done");
                    btVerder.Content = "Opslaan";
                }
            }
            if (sContentButton == "Opslaan")
            {
                MessageBox.Show("ALIWEJ0");
                btVerder.Content = "Verder";
            }

        }

        private void PopulateAntwoordLijst()
        {
            DataTable dtAntwoorden = db.GetAntwoorden(lbVraagID.Content.ToString());

            foreach (DataRow row in dtAntwoorden.Rows)
            {
                _lstAntwoorden.Add(row["Antwoord"].ToString());
            }

            rbAntwoord1.Content = _lstAntwoorden[0];
            rbAntwoord2.Content = _lstAntwoorden[1];
            rbAntwoord3.Content = _lstAntwoorden[2];
            rbAntwoord4.Content = _lstAntwoorden[3];

            _lstAntwoorden.Clear();
        }

        private void btVerder_Click(object sender, RoutedEventArgs e)
        {
            if (rbAntwoord1.IsChecked == true)
            {
                _piRadioButton = 0;
                NextQuestion();
                rbAntwoord1.IsChecked = false;
            }
            else if (rbAntwoord2.IsChecked == true)
            {
                _piRadioButton = 1;
                NextQuestion();
                rbAntwoord2.IsChecked = false;
            }
            else if (rbAntwoord3.IsChecked == true)
            {
                _piRadioButton = 2;
                NextQuestion();
                rbAntwoord3.IsChecked = false;
            }
            else if (rbAntwoord4.IsChecked == true)
            {
                _piRadioButton = 3;
                NextQuestion();
                rbAntwoord4.IsChecked = false;
            }
            else
            {
                MessageBox.Show("Zorg ervoor dat je een antwoord hebt aangevinkt!", "oops!");
            }
        }

        private void btTerug_Click(object sender, RoutedEventArgs e)
        {
            LeerlingForm form = new LeerlingForm(user);
            form.Show();
            this.Close();
        }

        private void GetUser()
        {
            string sUserNaam = db.getUserNaam(user).ToString();
            lbUser.Content = sUserNaam;
        }
    }
}
