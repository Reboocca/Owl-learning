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
    /// Interaction logic for Toetsform.xaml
    /// </summary>
    public partial class Toetsform : Window
    {
        DBS db = new DBS();
        public List<string> _plstVraagID = new List<string>();
        public List<string> _psltSelectieVragen = new List<string>();
        public List<string> _lstAntwoorden = new List<string>();
        public string user;
        public string lesonderwerp;
        public string _psVraagID;
        static Random rnd = new Random();
        int _iIndex = 0;
        int _piRadioButton = 99;
        int _iScore = 0;

        public Toetsform(string sUser, string sLesonderwerp)
        {
            InitializeComponent();
            user = sUser;
            lesonderwerp = sLesonderwerp;

            PopulateVraagLijst();
            SelectVragen();
            NextQuestion();
        }

        public void PopulateVraagLijst()
        {
            DataTable dtToetsVraag = db.GetToetsVraag(lesonderwerp);

            foreach (DataRow row in dtToetsVraag.Rows)
            {
                _plstVraagID.Add(row["VraagID"].ToString());
            }

        }

        private void SelectVragen()
        {
            for (int i = _psltSelectieVragen.Count; i < 10; i++)
            {
                int r = rnd.Next(_plstVraagID.Count - 1);
                bool contains = _psltSelectieVragen.Contains((string)_plstVraagID[r]);

                if (!contains)
                {
                    _psltSelectieVragen.Add((string)_plstVraagID[r]);
                }
                else
                {
                    i -= 1;
                }
            }

        }
        public void NextQuestion()
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
                            //MessageBox.Show("Je hebt het goede antwoord ingevuld.", "Goed zo");
                        }

                        else if (row["Juist_onjuist"].ToString() == "2")
                        {
                            //MessageBox.Show("Je een foutje gemaakt.", "Oh nee");
                        }

                        else
                        {
                            MessageBox.Show("Er is iets mis gegaan met het controleren van je antwoord, sluit de les af en probeer het opnieuw!", "Oops");
                        }
                    }
                }


                if (_iIndex < _psltSelectieVragen.Count)
                 {
                     _psVraagID = _psltSelectieVragen[_iIndex];
                    DataTable dtVraag = db.GetToetsVraagByID(_psVraagID);
                    foreach (DataRow row in dtVraag.Rows)
                     {
                         lbVraag.Content = row["Vraag"].ToString();
                     }
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
                if (_iScore >= (_psltSelectieVragen.Count / 2))
                {
                    MessageBox.Show("Je hebt " + _iScore.ToString() + " van de " + _psltSelectieVragen.Count.ToString() + " vragen goed beantwoord", "Goed gedaan!");
                }
                else
                {
                    MessageBox.Show("Je hebt " + _iScore.ToString() + " van de " + _psltSelectieVragen.Count.ToString() + " vragen goed beantwoord", "Volgende keer beter!");
                }

            }
        }

        private void PopulateAntwoordLijst()
        {
            DataTable dtAntwoorden = db.GetAntwoorden(_psVraagID);

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

        }
    }
}
