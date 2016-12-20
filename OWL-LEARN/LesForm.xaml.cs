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
    /// Interaction logic for LesForm.xaml
    /// </summary>
    public partial class LesForm : Window
    {
        public LesForm(string slesID)
        {
            InitializeComponent();
            MessageBox.Show(slesID);
        }
        
    }
}
