﻿#pragma checksum "..\..\Toetsform.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CAC3D13CB70144FA6A63798B6C98EFA9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace OWL_LEARN {
    
    
    /// <summary>
    /// Toetsform
    /// </summary>
    public partial class Toetsform : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\Toetsform.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btTerug;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\Toetsform.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbUser;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\Toetsform.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbVraag;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\Toetsform.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btVerder;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\Toetsform.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblUitleg;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\Toetsform.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbAntwoord1;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\Toetsform.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbAntwoord2;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\Toetsform.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbAntwoord3;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\Toetsform.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbAntwoord4;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/OWL-LEARN;component/toetsform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Toetsform.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btTerug = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\Toetsform.xaml"
            this.btTerug.Click += new System.Windows.RoutedEventHandler(this.btTerug_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lbUser = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.lbVraag = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.btVerder = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\Toetsform.xaml"
            this.btVerder.Click += new System.Windows.RoutedEventHandler(this.btVerder_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tblUitleg = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.rbAntwoord1 = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.rbAntwoord2 = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 8:
            this.rbAntwoord3 = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 9:
            this.rbAntwoord4 = ((System.Windows.Controls.RadioButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

