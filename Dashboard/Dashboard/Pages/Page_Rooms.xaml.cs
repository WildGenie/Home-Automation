using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Dashboard.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page_Rooms : Page
    {
        //class Room_ListView
        //{
        //    public string RoomName { get; set; }
        //    public string RoomImagePath { get; set; }
        //}

        public Page_Rooms()
        {
            this.InitializeComponent();

            foreach (var Room in MainPage._Home.Rooms)
            {
                //ListView_Rooms.Items.Add(new Room_ListView() { RoomName = Room.RoomName, RoomImagePath = Room.RoomImagePath });
                ListView_Rooms.Items.Add(Room);
            }
        }

        private void ListView_Rooms_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            Page_Devices Devices = new Page_Devices();
            MainPage._MainFrame.Navigate(Devices.GetType(), new object[] { (Library.Core.Room)ListView_Rooms.SelectedItem, (ushort)ListView_Rooms.SelectedIndex });
        }
    }
}
