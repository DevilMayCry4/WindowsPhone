﻿#pragma checksum "C:\Users\virgil\Documents\GitHub\WindowsPhone\NewInfo\NewInfo\DetailPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E12D0C5F75D017A6D12CD2C1FF0302A1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace NewInfo {
    
    
    public partial class DetailPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.TextBlock titleBlock;
        
        internal System.Windows.Controls.Image image;
        
        internal System.Windows.Controls.TextBlock desBlock;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/NewInfo;component/DetailPage.xaml", System.UriKind.Relative));
            this.titleBlock = ((System.Windows.Controls.TextBlock)(this.FindName("titleBlock")));
            this.image = ((System.Windows.Controls.Image)(this.FindName("image")));
            this.desBlock = ((System.Windows.Controls.TextBlock)(this.FindName("desBlock")));
        }
    }
}

