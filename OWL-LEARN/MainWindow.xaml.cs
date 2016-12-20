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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OWL_LEARN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBS db = new DBS();


        public MainWindow()
        {
            InitializeComponent();
            tb_User.Focus();
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            db.try_login(tb_User.Text, pb_Pwd.Password, this);

        }

       
    }
}
