﻿using System;
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
    /// Interaction logic for AccountToevoeg.xaml
    /// </summary>
    public partial class AccountToevoeg : Window
    {
        string user;
        string rolID;

        public AccountToevoeg(string username, string srolID)
        {
            InitializeComponent();
            user = username;
            rolID = srolID;
        }

        private void btOpslaan_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btTerug_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
