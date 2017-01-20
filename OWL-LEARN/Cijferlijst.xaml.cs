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
    /// Interaction logic for Cijferlijst.xaml
    /// </summary>
    public partial class Cijferlijst : Window
    {
        DBS db = new DBS();
        string user;
        
        public Cijferlijst(string username)
        {
            InitializeComponent();
            user = username;
            PopulateTabel();
        }

        struct CijferTabel
        {
            public string Vak { get; set; }
            public string Lesonderwerp { get; set; }
            public string Cijfer { get; set; }
            public string Score { get; set; }
        }

        public void PopulateTabel()
        {
            List<CijferTabel> lstCijfers = new List<CijferTabel>();
            string sScore = "";

            DataTable dtCijfers = db.CijferlijstOphalen(user);

            foreach (DataRow row in dtCijfers.Rows)
            {
                switch (row[0].ToString())        //Switch voor de verschillende vakken & de ID's
                {
                    case "10":
                        sScore = "20 van de 20";
                        break;
                    case "9.6":
                        sScore = "19 van de 20";
                        break;
                    case "9.2":
                        sScore = "18 van de 20";
                        break;
                    case "8.8":
                        sScore = "17 van de 20";
                        break;
                    case "8.4":
                        sScore = "16 van de 20";
                        break;
                    case "8":
                        sScore = "15 van de 20";
                        break;
                    case "7.5":
                        sScore = "14 van de 20";
                        break;
                    case "7.1":
                        sScore = "13 van de 20";
                        break;
                    case "6.8":
                        sScore = "12 van de 20";
                        break;
                    case "6.3":
                        sScore = "11 van de 20";
                        break;
                    case "5.9":
                        sScore = "10 van de 20";
                        break;
                    case "5.5":
                        sScore = " 9 van de 20";
                        break;
                    case "5":
                        sScore = " 8 van de 20";
                        break;
                    case "4.5":
                        sScore = " 7 van de 20";
                        break;
                    case "4":
                        sScore = " 6 van de 20";
                        break;
                    case "3.5":
                        sScore = " 5 van de 20";
                        break;
                    case "3":
                        sScore = " 4 van de 20";
                        break;
                    case "2.5":
                        sScore = " 3 van de 20";
                        break;
                    case "2":
                        sScore = " 2 van de 20";
                        break;
                    case "1.5":
                        sScore = " 1 van de 20";
                        break;
                    case "1":
                        sScore = " 0 van de 20";
                        break;
                    default:
                        sScore = "Kan niet worden opgehaald";
                        break;
                }

                lstCijfers.Add(new CijferTabel() { Vak = row[2].ToString(), Lesonderwerp = row[1].ToString(), Cijfer = row[0].ToString(), Score = sScore });
            }

            dgCijfers.ItemsSource = lstCijfers;
        }

        private void btTerug_Click(object sender, RoutedEventArgs e)
        {
            LeerlingForm lf = new LeerlingForm(user);
            lf.Show();
            this.Close();
        }
    }
}
