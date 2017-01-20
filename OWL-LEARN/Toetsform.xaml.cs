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
        #region fields
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
        #endregion 

        public Toetsform(string sUser, string sLesonderwerp)
        {
            InitializeComponent();
            user = sUser;
            lesonderwerp = sLesonderwerp;

            PopulateVraagLijst();
            SelectVragen();
            NextQuestion();
            GetUser();
        }

        DBS dbs = new DBS();

        private void GetUser()
        {
            string sUserNaam = dbs.getUserNaam(user).ToString();
            lbUser.Content = sUserNaam;
        }

        //Lijst vullen met de vragen van alle lessen:
        public void PopulateVraagLijst()
        {
            DataTable dtToetsVraag = db.Search("vragen", "LesonderwerpID", lesonderwerp);

            foreach (DataRow row in dtToetsVraag.Rows)
            {
                _plstVraagID.Add(row["VraagID"].ToString());
            }

        }

        //Lijst vullen met een random selectie van de vragen -> max 10
        private void SelectVragen()
        {
            for (int i = _psltSelectieVragen.Count; i < 20; i++)
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

        //Handelingen om naar de volgende vraag te gaan
        public void NextQuestion()
        {
            //Om te kijken of er op verder of opslaan geklikt wordt
            string sContentButton = btVerder.Content.ToString();

            if (sContentButton == "Verder")
            {
                //Zolang er een van de radiobuttons is aangevinkt:
                if (_piRadioButton != 99)
                {
                    //Controleerd of het antwoord juist of onjuist is
                    DataTable dtJuist_onjuist = db.GetGoedFout(_lstAntwoorden[_piRadioButton], _psVraagID);

                    foreach (DataRow row in dtJuist_onjuist.Rows)
                    {
                        if (row["Juist_onjuist"].ToString() == "1")
                        {
                            _iScore += 2;
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

                //Zolang er nog vragen zijn om te beantwoorden: 
                if (_iIndex < _psltSelectieVragen.Count)
                 {
                    //Neem het VraagID
                     _psVraagID = _psltSelectieVragen[_iIndex];

                    //Haal de vraag op via het VraagID
                    DataTable dtVraag = db.Search("vragen", "VraagID", _psVraagID);
                    foreach (DataRow row in dtVraag.Rows)
                     {
                         lbVraag.Content = row["Vraag"].ToString();
                     }

                    int iVraagNummer = _iIndex + 1;
                    lbVraagNummer.Content = iVraagNummer.ToString() + " van " + _psltSelectieVragen.Count.ToString();

                    _iIndex++;

                    //Zorg dat alle radiobuttons uitgevinkt staan
                    rbAntwoord1.IsChecked = false;
                    rbAntwoord2.IsChecked = false;
                    rbAntwoord3.IsChecked = false;
                    rbAntwoord4.IsChecked = false;

                    //Verwijder alles uit de antwoord lijst en repopulate hem
                    _lstAntwoorden.Clear();
                    PopulateAntwoordLijst();
                }

                    //Wanneer alle vragen zijn beantwoord:
                else
                {
                    //MessageBox.Show("Je hebt alle vragen beantwoord, klik op opslaan om verder te gaan.", "Done");
                    btVerder.Content = "Opslaan";
                }
            }

            //Kleine melding of de student het goed of fout heeft gedaan:
            if (sContentButton == "Opslaan")
            {
                string sVol_Onv = "";
                string sResultaat = "";

                switch (_iScore)        //Switch voor de verschillende vakken & de ID's
                {
                    case 40:
                        sResultaat = "10";
                        sVol_Onv = "perfect";
                        break;
                    case 38:
                        sResultaat = "9.6";
                        sVol_Onv = "voldoende";
                        break;
                    case 36:
                        sResultaat = "9.2";
                        sVol_Onv = "voldoende";
                        break;
                    case 34:
                        sResultaat = "8.8";
                        sVol_Onv = "voldoende";
                        break;
                    case 32:
                        sResultaat = "8.4";
                        sVol_Onv = "voldoende";
                        break;
                    case 30:
                        sResultaat = "8";
                        sVol_Onv = "voldoende";
                        break;
                    case 28:
                        sResultaat = "7.5";
                        sVol_Onv = "voldoende";
                        break;
                    case 26:
                        sResultaat = "7.1";
                        sVol_Onv = "voldoende";
                        break;
                    case 24:
                        sResultaat = "6.8";
                        sVol_Onv = "voldoende";
                        break;
                    case 22:
                        sResultaat = "6.3";
                        sVol_Onv = "voldoende";
                        break;
                    case 20:
                        sResultaat = "5.9";
                        sVol_Onv = "voldoende";
                        break;
                    case 18:
                        sResultaat = "5.5";
                        sVol_Onv = "voldoende";
                        break;
                    case 16:
                        sResultaat = "5.0";
                        sVol_Onv = "onvoldoende";
                        break;
                    case 14:
                        sResultaat = "4.5";
                        sVol_Onv = "onvoldoende";
                        break;
                    case 12:
                        sResultaat = "4.0";
                        sVol_Onv = "onvoldoende";
                        break;
                    case 10:
                        sResultaat = "3.5";
                        sVol_Onv = "onvoldoende";
                        break;
                    case 8:
                        sResultaat = "3.0";
                        sVol_Onv = "onvoldoende";
                        break;
                    case 6:
                        sResultaat = "2.5";
                        sVol_Onv = "onvoldoende";
                        break;
                    case 4:
                        sResultaat = "2.0";
                        sVol_Onv = "onvoldoende";
                        break;
                    case 2:
                        sResultaat = "1.5";
                        sVol_Onv = "onvoldoende";
                        break;
                    case 0:
                        sResultaat = "1.0";
                        sVol_Onv = "onvoldoende";
                        break;
                }

               db.SaveResultaat(user, lesonderwerp, sResultaat);

                Resultaat rs = new Resultaat(user, sVol_Onv, lesonderwerp, sResultaat);
                rs.Show();
                this.Close();
            }
        }

        //Lijst vullen met de mogelijke antwoorden -> vul deze in de radiobuttons in.
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

        //Wanneer er op verder geklikt word:
        private void btVerder_Click(object sender, RoutedEventArgs e)
        {
            //Geef mee welke radiobutton is gecheckt voor het controleren of het antwoord juist is beantwoord
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
    }
}
