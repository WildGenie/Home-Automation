using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.ApplicationModel;
using System.Reflection;
using System.Runtime.Serialization;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Dashboard
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static Library.Core.Home _Home;
        public static Frame _MainFrame;
        
        Pages.Page_Home _HomePage = new Pages.Page_Home();
        Pages.Page_Rooms _RoomPage;
        Pages.Page_Configuration _Page_Configuration;

        public MainPage()
        {
            this.InitializeComponent();
            Library.UI.DashboardButton.AddBorder(Border_Favorites);
            Library.UI.DashboardButton.AddBorder(Border_Geyser);
            Library.UI.DashboardButton.AddBorder(Border_Home);
            Library.UI.DashboardButton.AddBorder(Border_Rooms);
            Library.UI.DashboardButton.AddBorder(Border_Settings);
            Library.UI.DashboardButton.AddBorder(Border_WaterPump);

            Frame_MainFrame.Navigate(_HomePage.GetType());

           // Test_Save();
            Test_Load();

            _MainFrame = Frame_MainFrame;

        }

        public static void Test_Load()
        {
            _Home = Library.Core.Home.LoadHome().Result;
        }

        private void Test_Save()
        {
            Library.Core.Home _Home = new Library.Core.Home();
            _Home.Name = "Upwan Row House";

            _Home.Rooms = new List<Library.Core.Room>();

            _Home.Rooms.Add(new Library.Core.Room() { RoomName = "MummyPappa", RoomImagePath = "ms-appx:///Resource/Images/RoomTile/Flower1.png", I2C_Slave_Address="0x40" });
            _Home.Rooms.Add(new Library.Core.Room() { RoomName = "Kalpan", RoomImagePath = "ms-appx:///Resource/Images/RoomTile/Flower2.png", I2C_Slave_Address = "0x41" });
            _Home.Rooms.Add(new Library.Core.Room() { RoomName = "Anurag", RoomImagePath = "ms-appx:///Resource/Images/RoomTile/Flower3.png", I2C_Slave_Address = "0x42" });
            _Home.Rooms.Add(new Library.Core.Room() { RoomName = "Kitchen", RoomImagePath = "ms-appx:///Resource/Images/RoomTile/Kitchen.png", I2C_Slave_Address = "0x43" });
            _Home.Rooms.Add(new Library.Core.Room() { RoomName = "Garden", RoomImagePath = "ms-appx:///Resource/Images/RoomTile/Flower3.png", I2C_Slave_Address = "0x44" });
            _Home.Rooms.Add(new Library.Core.Room() { RoomName = "Backyard", RoomImagePath = "ms-appx:///Resource/Images/RoomTile/Flower2.png", I2C_Slave_Address = "0x45" });

            _Home.Rooms[2].Devices = new List<Library.Core.Device>();
            _Home.Rooms[2].Devices.Add(new Library.Core.Device() { Id = 0, ImagePath = "ms-appx:///Resource/Images/Devices/Fan_130.png", Name = "Light", Pin = Library.Core.Device.PinsEnum.A2, Status = Library.Core.Device.StatusEnum.Off });
            _Home.Rooms[2].Devices.Add(new Library.Core.Device() { Id = 1, ImagePath = "ms-appx:///Resource/Images/Devices/Fan_130.png", Name = "Fan", Pin = Library.Core.Device.PinsEnum.D1, Status = Library.Core.Device.StatusEnum.On });

            Library.Core.Home.SaveHome(_Home);
        }

        private void Border_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (sender.Equals(Border_Favorites))
            {
                Library.UI.DashboardButton.RaiseBorder(Border_Favorites);
            }
            if (sender.Equals(Border_Geyser))
            {
                Library.UI.DashboardButton.RaiseBorder(Border_Geyser);
            }
            if (sender.Equals(Border_Home))
            {
                Library.UI.DashboardButton.RaiseBorder(Border_Home);
                Frame_MainFrame.Navigate(_HomePage.GetType());
            }
            if (sender.Equals(Border_Rooms))
            {
                if (_RoomPage == null)
                {
                    _RoomPage = new Pages.Page_Rooms();
                }
                Library.UI.DashboardButton.RaiseBorder(Border_Rooms);
                Frame_MainFrame.Navigate(_RoomPage.GetType());
            }
            if (sender.Equals(Border_Settings))
            {
                if (_Page_Configuration == null)
                {
                    _Page_Configuration = new Pages.Page_Configuration();
                }
                Library.UI.DashboardButton.RaiseBorder(Border_Settings);
                Frame_MainFrame.Navigate(_Page_Configuration.GetType());
            }
            if (sender.Equals(Border_WaterPump))
            {
                Library.UI.DashboardButton.RaiseBorder(Border_WaterPump);
            }
        }
    }
}
