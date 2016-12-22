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
    /// Interaction logic for lesWijzigen.xaml
    /// </summary>
    public partial class lesWijzigen : Window
    {
        string user;
        string lesID;
        string loID;
        public lesWijzigen(string sloID, string username, string leswijzigID)
        {
            InitializeComponent();
            user = username;
            lesID = leswijzigID;
            getlesInformatie();
            loID = sloID;
        }

        DBS dbs = new DBS();

        private void getlesInformatie()
        {
            DataTable dtGegevens = dbs.getLesInfo(lesID);
            foreach (DataRow row in dtGegevens.Rows)
            {
                tbNaam.Text = row["lesNaam"].ToString();
                rbUitleg.Document.Blocks.Add(new Paragraph(new Run(row["Uitleg"].ToString())));
            }
        }


        private void btTerug_Click(object sender, RoutedEventArgs e)
        {
            LesonderwerpWijzig terug = new LesonderwerpWijzig(loID, user);
            terug.Show();
            this.Close();
        }

        private void btWijzigNaam_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btBewerk_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btVerwijder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btVoegToe_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

