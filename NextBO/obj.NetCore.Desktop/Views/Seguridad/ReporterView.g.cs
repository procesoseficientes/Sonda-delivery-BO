﻿#pragma checksum "..\..\..\Views\Seguridad\ReporterView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0DAB21587B8ECB5B37F48A323918B9017611B9AE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Core;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Mvvm.UI.Interactivity.TypedStyles;
using DevExpress.Mvvm.UI.ModuleInjection;
using DevExpress.Mvvm.UI.TypedStyles;
using DevExpress.Mvvm.ViewModel;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.ConditionalFormatting;
using DevExpress.Xpf.Core.ConditionalFormatting.TypedStyles;
using DevExpress.Xpf.Core.DataSources;
using DevExpress.Xpf.Core.DataSources.TypedStyles;
using DevExpress.Xpf.Core.Serialization;
using DevExpress.Xpf.Core.Serialization.TypedStyles;
using DevExpress.Xpf.Core.ServerMode;
using DevExpress.Xpf.Core.ServerMode.TypedStyles;
using DevExpress.Xpf.Core.TypedStyles;
using DevExpress.Xpf.Printing;
using DevExpress.Xpf.Printing.TypedStyles;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.TypedStyles;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Primitives.TypedStyles;
using System.Windows.Controls.TypedStyles;
using System.Windows.Data;
using System.Windows.Data.TypedStyles;
using System.Windows.Documents;
using System.Windows.Documents.TypedStyles;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Input.TypedStyles;
using System.Windows.Markup;
using System.Windows.Markup.TypedStyles;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Animation.TypedStyles;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Media.TypedStyles;
using System.Windows.Navigation;
using System.Windows.Navigation.TypedStyles;
using System.Windows.Shapes;
using System.Windows.Shapes.TypedStyles;
using System.Windows.Shell;
using System.Windows.TypedStyles;


namespace NextBO.Wpf.Views {
    
    
    /// <summary>
    /// Reporter
    /// </summary>
    public partial class Reporter : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\Views\Seguridad\ReporterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Core.DXSplashScreenService splashScreenService;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Views\Seguridad\ReporterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Printing.DocumentPreviewControl viewer;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/NextBO.Wpf;component/views/seguridad/reporterview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\Seguridad\ReporterView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.splashScreenService = ((DevExpress.Xpf.Core.DXSplashScreenService)(target));
            return;
            case 2:
            this.viewer = ((DevExpress.Xpf.Printing.DocumentPreviewControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

