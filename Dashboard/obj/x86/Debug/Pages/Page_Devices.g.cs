﻿#pragma checksum "C:\Users\Anurag\Desktop\OneDrive\Hackster.io\Challenge\Microsoft Challenge\Software\Dashboard\Dashboard\Pages\Page_Devices.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "673BD91B36B509405C2AD1D2E74432C9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dashboard.Pages
{
    partial class Page_Devices : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.ListView_Devices = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    #line 50 "..\..\..\Pages\Page_Devices.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ListView_Devices).DoubleTapped += this.ListView_Devices_DoubleTapped;
                    #line default
                }
                break;
            case 2:
                {
                    this.txt_RoomName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3:
                {
                    this.lbl_PIR_Status = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4:
                {
                    this.lbl_LightIntensity = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5:
                {
                    this.lbl_Temp_C = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

