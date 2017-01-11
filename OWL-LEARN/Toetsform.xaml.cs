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
        public string user;
        public string lesonderwerp;

        public Toetsform(string sUser, string sLesonderwerp)
        {
            InitializeComponent();
            user = sUser;
            lesonderwerp = sLesonderwerp;

            PopulateVraagLijst();
            NextQuestion();
        }

        public void PopulateVraagLijst()
        {
            DataTable dtToetsVraag = db.GetToetsVraag(lesonderwerp);

            foreach (DataRow row in dtToetsVraag.Rows)
            {
                _plstVraagID.Add(row["VraagID"].ToString());
            }

            //shfl.Shuffle(_plstVraagID);
        }

        /* 
          private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
         */
        public void NextQuestion()
        {
           // lstbTest.ItemsSource = _plstVraagID;
        }

        private void btVerder_Click(object sender, RoutedEventArgs e)
        {
            NextQuestion();
        }

        private void btTerug_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
