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
    /// Interaction logic for Lestoevoegen.xaml
    /// </summary>
    public partial class Lestoevoegen : Window
    {
        public string user;
        public string loID;
        public Lestoevoegen(string sloID, string username)
        {
            InitializeComponent();
            loID = sloID;
            user = username;
        }
        DBS dbs = new DBS();
        private void btOpslaan_Click(object sender, RoutedEventArgs e)
        {
            string sUitleg = new TextRange(rbUitleg.Document.ContentStart, rbUitleg.Document.ContentEnd).Text;
            dbs.newLes(loID, tbNaam.Text, sUitleg, this, user);
        }

        private void btTerug_Click(object sender, RoutedEventArgs e)
        {
            LesonderwerpWijzig form = new LesonderwerpWijzig(loID, user);
            form.Show();
            this.Close();
        }
    }
}
