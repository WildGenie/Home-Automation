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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Dashboard.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page_Configuration : Page
    {
        public Page_Configuration()
        {
            this.InitializeComponent();

            foreach (var Room in MainPage._Home.Rooms)
            {
                lst_Main.Items.Add(Room);
            }

            Lst_RoomImage.Items.Add(new { ImagePath = "ms-appx:///Resource/Images/RoomTile/Attic.png" });
            Lst_RoomImage.Items.Add(new { ImagePath = "ms-appx:///Resource/Images/RoomTile/Basement.png" });
            Lst_RoomImage.Items.Add(new { ImagePath = "ms-appx:///Resource/Images/RoomTile/Fireplace.png" });
            Lst_RoomImage.Items.Add(new { ImagePath = "ms-appx:///Resource/Images/RoomTile/Flower1.png" });
            Lst_RoomImage.Items.Add(new { ImagePath = "ms-appx:///Resource/Images/RoomTile/Flower2.png" });
            Lst_RoomImage.Items.Add(new { ImagePath = "ms-appx:///Resource/Images/RoomTile/Flower3.png" });
            Lst_RoomImage.Items.Add(new { ImagePath = "ms-appx:///Resource/Images/RoomTile/Kitchen.png" });
            Lst_RoomImage.Items.Add(new { ImagePath = "ms-appx:///Resource/Images/RoomTile/Pillow.png" });
            Lst_RoomImage.Items.Add(new { ImagePath = "ms-appx:///Resource/Images/RoomTile/Room.png" });
            Lst_RoomImage.Items.Add(new { ImagePath = "ms-appx:///Resource/Images/RoomTile/TV.png" });
            Lst_RoomImage.Items.Add(new { ImagePath = "ms-appx:///Resource/Images/RoomTile/Window.png" });
        }

        private void lst_Main_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {

        }

        private void Img_Btn_Save_Tapped(object sender, TappedRoutedEventArgs e)
        {
            int SelectedIndex = Lst_Main.SelectedIndex;

            ((Library.Core.Room)(Lst_Main.SelectedItem)).RoomName = txt_RoomName.Text;
            ((Library.Core.Room)(Lst_Main.SelectedItem)).I2C_Slave_Address = txt_Room_I2C_Slave_Address.Text;

            Library.Core.Home.SaveHome(MainPage._Home);

            Lst_Main.Items.Clear();
            foreach (var Room in MainPage._Home.Rooms)
            {
                Lst_Main.Items.Add(Room);
            }

            Lst_Main.SelectedIndex = SelectedIndex;
        }

        private void Img_Btn_AddNewRoom_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainPage._Home.Rooms.Add(new Library.Core.Room() { RoomName = "MyRoom" });
            Lst_Main.Items.Clear();
            foreach (var Room in MainPage._Home.Rooms)
            {
                Lst_Main.Items.Add(Room);
            }
            Lst_Main.SelectedIndex = Lst_Main.Items.Count - 1;
        }

        private void Img_Btn_RemoveRoom_Tapped(object sender, TappedRoutedEventArgs e)
        {
            int SelectedIndex = Lst_Main.SelectedIndex;

            foreach (var Room in MainPage._Home.Rooms)
            {
                if(Room == (Library.Core.Room)Lst_Main.SelectedItem)
                {
                    MainPage._Home.Rooms.Remove(Room);
                    break;
                }
            }

            Lst_Main.Items.Clear();
            foreach (var Room in MainPage._Home.Rooms)
            {
                Lst_Main.Items.Add(Room);
            }
            
            if(Lst_Main.Items.Count>0)
            {
                Lst_Main.SelectedIndex = ((SelectedIndex - 1) > -1) ? SelectedIndex - 1 : 0;
            }
        }
    }
}
