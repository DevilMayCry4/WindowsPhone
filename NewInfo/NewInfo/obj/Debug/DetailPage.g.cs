﻿#pragma checksum "C:\Users\virgil\Documents\GitHub\WindowsPhone\NewInfo\NewInfo\DetailPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "22BC9CEBD75F3D2AEA554AC266D767C4"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.17929
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Phone.Controls;
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
        
        internal Phone.Controls.ScrollableTextBlock descBlock;
        
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
            this.descBlock = ((Phone.Controls.ScrollableTextBlock)(this.FindName("descBlock")));
        }
    }
}

