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
        public string _psVraagID;
        public string _psLesonderwerpID;
        int _piRadioButton = 99;
        List<string> _lsVragen = new List<string>();
        List<string> _lstVraagIDs = new List<string>();
        List<string> _lstAntwoorden = new List<string>();
        int _iIndex = 0;
        int _iScore = 0;

        public LesForm(string slesID, string username, string sLesonderwerpID)
        {
            InitializeComponent();
            user = username;
            GetUser();
            _psLesID = slesID;
            _psLesonderwerpID = sLesonderwerpID;
            PopulateUitleg();
            PopulateVraagLijst();
            NextQuestion();
            
        }

        private void PopulateUitleg()
        {
            DataTable dtUitleg = db.Search("les", "lesID", _psLesID);

            foreach (DataRow row in dtUitleg.Rows)
            {
                _psUitleg = row["Uitleg"].ToString();
            }

            tblUitleg.Text = _psUitleg;
        }

        private void PopulateVraagLijst()
        {
            DataTable dtVraag = db.Search("vragen", "lesID", _psLesID);

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
                if (_piRadioButton != 99)
                {
                    DataTable dtJuist_onjuist = db.GetGoedFout(_lstAntwoorden[_piRadioButton], _psVraagID);

                    foreach (DataRow row in dtJuist_onjuist.Rows)
                    {
                        if (row["Juist_onjuist"].ToString() == "1")
                        {
                            _iScore++;
                        }

                        else
                        {
                            MessageBox.Show("Er is iets mis gegaan met het controleren van je antwoord, sluit de les af en probeer het opnieuw!", "Oops");
                        }
                    }
                }


                if (_iIndex < _lsVragen.Count)
                {
                    lbVraag.Content = _lsVragen[_iIndex];
                    _psVraagID = _lstVraagIDs[_iIndex];

                    int iVraagNummer = _iIndex + 1;
                    lbVraagNummer.Content =  iVraagNummer.ToString() + " van " + _lsVragen.Count.ToString();

                    _iIndex++;


                    rbAntwoord1.IsChecked = false;
                    rbAntwoord2.IsChecked = false;
                    rbAntwoord3.IsChecked = false;
                    rbAntwoord4.IsChecked = false;

                    _lstAntwoorden.Clear();
                    PopulateAntwoordLijst();
                }

                else
                {
                    //MessageBox.Show("Je hebt alle vragen beantwoord, klik op opslaan om verder te gaan.", "Done");
                    btVerder.Content = "Opslaan";
                }
            }

            if (sContentButton == "Opslaan")
            {
                if (_iScore >= (_lsVragen.Count / 2))
                {
                    MessageBox.Show("Je hebt " + _iScore.ToString() + " van de " + _lsVragen.Count.ToString() + " vragen goed beantwoord, de les is voltooid.", "Goed gedaan!");
                    db.findIDVoorVoortgang(user, _psLesonderwerpID, _psLesID, this);
                }
                else
                {
                    MessageBox.Show("Je hebt " + _iScore.ToString() + " van de " + _lsVragen.Count.ToString() + " vragen goed beantwoord, maak de les opnieuw.", "Volgende keer beter!");
                }

            }

        }

        private void PopulateAntwoordLijst()
        {
            DataTable dtAntwoorden = db.Search("antwoorden", "VraagID", _psVraagID);

            foreach (DataRow row in dtAntwoorden.Rows)
            {
                _lstAntwoorden.Add(row["Antwoord"].ToString());
            }

            rbAntwoord1.Content = _lstAntwoorden[0];
            rbAntwoord2.Content = _lstAntwoorden[1];
            rbAntwoord3.Content = _lstAntwoorden[2];
            rbAntwoord4.Content = _lstAntwoorden[3];
        }

        private void btVerder_Click(object sender, RoutedEventArgs e)
        {
            if (rbAntwoord1.IsChecked == true)
            {
                _piRadioButton = 0;
                NextQuestion();
            }
            else if (rbAntwoord2.IsChecked == true)
            {
                _piRadioButton = 1;
                NextQuestion();
            }
            else if (rbAntwoord3.IsChecked == true)
            {
                _piRadioButton = 2;
                NextQuestion();
            }
            else if (rbAntwoord4.IsChecked == true)
            {
                _piRadioButton = 3;
                NextQuestion();
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
