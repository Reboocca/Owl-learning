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

namespace OWL_LEARN
{
    /// <summary>
    /// Interaction logic for addVraag.xaml
    /// </summary>
    public partial class addVraag : Window
    {
        string lesID;
        string user;
        string sloID;
        public addVraag(string lesAddID, string username, string loID)
        {
            InitializeComponent();
            lesID = lesAddID;
            user = username;
            sloID = loID;
        }

        DBS dbs = new DBS();

        private void btTerug_Click(object sender, RoutedEventArgs e)
        {
            lesWijzigen terug = new lesWijzigen(sloID, user, lesID);
            terug.Show();
            this.Close();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (tbVraag.Text == null || tbAntwoordA.Text == null || tbAntwoordB.Text == null || tbAntwoordC.Text == null || tbAntwoordD.Text == null)
            {
                MessageBox.Show("Zorg ervoor dat alle invoervelden ingevuld zijn voordat je de vraag opslaat.", "Let op!");
            }
            else
            {
                //Controleer of de consulent een van de checkboxes heeft aangevinkt
                if (A1.IsChecked == true)
                {
                    dbs.addVraag(tbVraag.Text, lesID, sloID);
                    dbs.addAntwoord(tbVraag.Text, lesID, sloID, 1, tbAntwoordA.Text, tbAntwoordB.Text, tbAntwoordC.Text, tbAntwoordD.Text);
                    lesWijzigen terug = new lesWijzigen(sloID, user, lesID);
                    terug.Show();
                    this.Close();
                }
                else if (A2.IsChecked == true)
                {
                    dbs.addVraag(tbVraag.Text, lesID, sloID);
                    dbs.addAntwoord(tbVraag.Text, lesID, sloID, 2, tbAntwoordA.Text, tbAntwoordB.Text, tbAntwoordC.Text, tbAntwoordD.Text);
                    lesWijzigen terug = new lesWijzigen(sloID, user, lesID);
                    terug.Show();
                    this.Close();
                }
                else if (A3.IsChecked == true)
                {
                    dbs.addVraag(tbVraag.Text, lesID, sloID);
                    dbs.addAntwoord(tbVraag.Text, lesID, sloID, 3, tbAntwoordA.Text, tbAntwoordB.Text, tbAntwoordC.Text, tbAntwoordD.Text);
                    lesWijzigen terug = new lesWijzigen(sloID, user, lesID);
                    terug.Show();
                    this.Close();
                }
                else if (A4.IsChecked == true)
                {
                    dbs.addVraag(tbVraag.Text, lesID, sloID);
                    dbs.addAntwoord(tbVraag.Text, lesID, sloID, 4, tbAntwoordA.Text, tbAntwoordB.Text, tbAntwoordC.Text, tbAntwoordD.Text);
                    lesWijzigen terug = new lesWijzigen(sloID, user, lesID);
                    terug.Show();
                    this.Close();
                }
                //Wanneer geen antwoord is aangevinkt, geef de consulent een bericht hierover
                else
                {
                    MessageBox.Show("Zorg ervoor dat je het juiste antwoord hebt aangevinkt!", "Whoops!");
                }
            }
           
        }
    }
}
