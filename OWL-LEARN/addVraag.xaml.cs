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

        private void btTerug_Click(object sender, RoutedEventArgs e)
        {
            lesWijzigen terug = new lesWijzigen(sloID, user, lesID);
            terug.Show();
            this.Close();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
