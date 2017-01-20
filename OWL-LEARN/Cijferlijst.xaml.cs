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

        struct Cijferlijst
        {
            public string VakNaam { get; set; }
            public string Lesonderwerp { get; set; }
            public string Cijfer { get; set; }
            public string Score { get; set; }
        }

        public void PopulateTabel()
        {

        }
    }
}
