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
    /// Interaction logic for LesonderwerpToevoegen.xaml
    /// </summary>
    public partial class LesonderwerpToevoegen : Window
    {
        string user;
        string VakID;
        public LesonderwerpToevoegen(string SelectedVakID, string username)
        {
            InitializeComponent();
            user = username;
            VakID = SelectedVakID;
        }

        DBS Class = new DBS();

        private void btTerug_Click(object sender, RoutedEventArgs e)
        {
            LesOnderwerpCMS form = new LesOnderwerpCMS(user);
            form.Show();
            this.Close();
        }

        private void btOpslaan_Click(object sender, RoutedEventArgs e)
        {
            Class.VoegLesOnderwerpToe(VakID, tbNaam.Text);       

            LesOnderwerpCMS form = new LesOnderwerpCMS(user);
            form.Show();
            this.Close();
        }
    }
}
