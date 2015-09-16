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
        public class ImageListClass
        {
            public string ImagePath { get; set; }
        }

        public Page_Configuration()
        {
            this.InitializeComponent();

            foreach (var Room in MainPage._Home.Rooms)
            {
                Lst_Main.Items.Add(Room);
            }

            Lst_RoomImage.Items.Add(new ImageListClass { ImagePath = "ms-appx:///Resource/Images/RoomTile/Attic.png" });
            Lst_RoomImage.Items.Add(new ImageListClass { ImagePath = "ms-appx:///Resource/Images/RoomTile/Basement.png" });
            Lst_RoomImage.Items.Add(new ImageListClass { ImagePath = "ms-appx:///Resource/Images/RoomTile/Fireplace.png" });
            Lst_RoomImage.Items.Add(new ImageListClass { ImagePath = "ms-appx:///Resource/Images/RoomTile/Flower1.png" });
            Lst_RoomImage.Items.Add(new ImageListClass { ImagePath = "ms-appx:///Resource/Images/RoomTile/Flower2.png" });
            Lst_RoomImage.Items.Add(new ImageListClass { ImagePath = "ms-appx:///Resource/Images/RoomTile/Flower3.png" });
            Lst_RoomImage.Items.Add(new ImageListClass { ImagePath = "ms-appx:///Resource/Images/RoomTile/Kitchen.png" });
            Lst_RoomImage.Items.Add(new ImageListClass { ImagePath = "ms-appx:///Resource/Images/RoomTile/Pillow.png" });
            Lst_RoomImage.Items.Add(new ImageListClass { ImagePath = "ms-appx:///Resource/Images/RoomTile/Room.png" });
            Lst_RoomImage.Items.Add(new ImageListClass { ImagePath = "ms-appx:///Resource/Images/RoomTile/TV.png" });
            Lst_RoomImage.Items.Add(new ImageListClass { ImagePath = "ms-appx:///Resource/Images/RoomTile/Window.png" });

            Lst_DeviceImage.Items.Add(new ImageListClass { ImagePath = "ms-appx:///Resource/Images/Devices/Bulb_130.png" });
            Lst_DeviceImage.Items.Add(new ImageListClass { ImagePath = "ms-appx:///Resource/Images/Devices/Fan_130.png" });
            Lst_DeviceImage.Items.Add(new ImageListClass { ImagePath = "ms-appx:///Resource/Images/Devices/Lamp1_130.png" });
            Lst_DeviceImage.Items.Add(new ImageListClass { ImagePath = "ms-appx:///Resource/Images/Devices/Lamp2_130.png" });
            Lst_DeviceImage.Items.Add(new ImageListClass { ImagePath = "ms-appx:///Resource/Images/Devices/Plug_130.png" });
            Lst_DeviceImage.Items.Add(new ImageListClass { ImagePath = "ms-appx:///Resource/Images/Devices/Socket_130.png" });

        }

        private void Img_Btn_Save_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (Lst_Main.SelectedIndex > -1)
            {
                int SelectedIndex = Lst_Main.SelectedIndex;

                ((Library.Core.Room)(Lst_Main.SelectedItem)).RoomName = txt_RoomName.Text;
                ((Library.Core.Room)(Lst_Main.SelectedItem)).I2C_Slave_Address = txt_Room_I2C_Slave_Address.Text;

                ((Library.Core.Room)(Lst_Main.SelectedItem)).RoomImagePath = ((ImageListClass)Lst_RoomImage.SelectedItem).ImagePath;

                if (((Library.Core.Room)(Lst_Main.SelectedItem)).Devices != null && ((Library.Core.Room)(Lst_Main.SelectedItem)).Devices.Count > 0)
                {
                    ((Library.Core.Room)(Lst_Main.SelectedItem)).Devices[Lst_Devices.SelectedIndex].Name = txt_DeviceName.Text;

                    ((Library.Core.Room)(Lst_Main.SelectedItem)).Devices[Lst_Devices.SelectedIndex].Pin = (Library.Core.Device.PinsEnum)Enum.Parse(typeof(Library.Core.Device.PinsEnum), ((ComboBoxItem)cmb_DevicePin.SelectedItem).Content.ToString());

                    try
                    {
                        ((Library.Core.Room)(Lst_Main.SelectedItem)).Devices[Lst_Devices.SelectedIndex].ImagePath = ((ImageListClass)Lst_DeviceImage.SelectedItem).ImagePath;
                    }
                    catch (Exception) { }

                }

                Library.Core.Home.SaveHome(MainPage._Home);

                Lst_Main.Items.Clear();
                foreach (var Room in MainPage._Home.Rooms)
                {
                    Lst_Main.Items.Add(Room);
                }

                Lst_Main.SelectedIndex = SelectedIndex;

            }
            else
            {
                Library.Core.Home.SaveHome(MainPage._Home);
            }
            
            RefreshDeviceList();
        }

        private void Img_Btn_AddNewRoom_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainPage._Home.Rooms.Add(new Library.Core.Room() { RoomName = "MyRoom", Devices = new List<Library.Core.Device>(), I2C_Slave_Address = "", RoomImagePath = "ms-appx:///Resource/Images/RoomTile/Room.png" });
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
                if (Room == (Library.Core.Room)Lst_Main.SelectedItem)
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

            if (Lst_Main.Items.Count > 0)
            {
                Lst_Main.SelectedIndex = ((SelectedIndex - 1) > -1) ? SelectedIndex - 1 : 0;
            }

            Lst_Main_Tapped(null, null);
        }


        // Update Right Pane with room details
        private void Lst_Main_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (Lst_Main.SelectedItem != null)
            {
                Library.Core.Room _SelectedRoom = (Library.Core.Room)Lst_Main.SelectedItem;

                foreach (var _ImageListClass in Lst_RoomImage.Items)
                {
                    ImageListClass _Image = (ImageListClass)_ImageListClass;
                    if (_Image.ImagePath == _SelectedRoom.RoomImagePath)
                    {
                        Lst_RoomImage.SelectedItem = _Image;
                        break;
                    }
                }

                txt_RoomName.Text = _SelectedRoom.RoomName;
                txt_Room_I2C_Slave_Address.Text = _SelectedRoom.I2C_Slave_Address;

                // Update Devices
                RefreshDeviceList();
            }
        }

        private void RefreshDeviceList()
        {
            if (Lst_Main.SelectedItem != null)
            {
                Library.Core.Room _SelectedRoom = (Library.Core.Room)Lst_Main.SelectedItem;

                try
                {
                    Lst_Devices.Items.Clear();
                }
                catch (Exception) { }

                if (_SelectedRoom.Devices != null && _SelectedRoom.Devices.Count > 0)
                {
                    foreach (var _Device in _SelectedRoom.Devices)
                    {
                        Lst_Devices.Items.Add(_Device);
                    }
                    Lst_Devices.SelectedIndex = 0;
                    Lst_Devices_Tapped(null, null);
                    txt_DeviceName.Text = ((Library.Core.Device)Lst_Devices.SelectedItem).Name;

                    foreach (var item in cmb_DevicePin.Items)
                    {
                        if (((string)((ComboBoxItem)item).Content) == ((Library.Core.Device)Lst_Devices.SelectedItem).Pin.ToString())
                        {
                            cmb_DevicePin.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
            else
            {
                try
                {
                    Lst_Devices.Items.Clear();
                }
                catch (Exception) { }
                txt_DeviceName.Text = "N/A";
                txt_RoomName.Text = "N/A";
                txt_Room_I2C_Slave_Address.Text = "N/A";
            }

        }

        private void Lst_Main_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            Lst_Main_Tapped(sender, null);
        }

        private void Lst_Devices_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Library.Core.Room _SelectedRoom = (Library.Core.Room)Lst_Main.SelectedItem;
            if (_SelectedRoom.Devices.Count > 0)
            {
                txt_DeviceName.Text = ((Library.Core.Device)Lst_Devices.SelectedItem).Name;

                foreach (var item in cmb_DevicePin.Items)
                {
                    if (((string)((ComboBoxItem)item).Content) == ((Library.Core.Device)Lst_Devices.SelectedItem).Pin.ToString())
                    {
                        cmb_DevicePin.SelectedItem = item;
                        break;
                    }
                }

                // Update Device Image
                foreach (var _ImageListClass in Lst_DeviceImage.Items)
                {
                    ImageListClass _Image = (ImageListClass)_ImageListClass;
                    if (_Image.ImagePath == ((Library.Core.Device)Lst_Devices.SelectedItem).ImagePath)
                    {
                        Lst_DeviceImage.SelectedItem = _Image;
                        break;
                    }
                }

            }
        }

        private void Img_Btn_AddNewDevice_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Library.Core.Room _SelectedRoom = (Library.Core.Room)Lst_Main.SelectedItem;

            if (_SelectedRoom.Devices == null)
            {
                _SelectedRoom.Devices = new List<Library.Core.Device>();
            }

            _SelectedRoom.Devices.Add(new Library.Core.Device() { Name = "NewDevice", Id = (ushort)_SelectedRoom.Devices.Count, ImagePath = "ms-appx:///Resource/Images/Devices/Plug_130.png" });
            RefreshDeviceList();
        }

        private void Img_Btn_RemoveDevice_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Library.Core.Room _SelectedRoom = (Library.Core.Room)Lst_Main.SelectedItem;

            if (_SelectedRoom.Devices != null && _SelectedRoom.Devices.Count > 0)
            {
                _SelectedRoom.Devices.Remove(((Library.Core.Device)Lst_Devices.SelectedItem));
                RefreshDeviceList();
            }
        }
    }
}
