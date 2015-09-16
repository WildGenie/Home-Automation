using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Windows;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
    public sealed partial class Page_Devices : Page
    {
        private List<Library.Core.Device> Devices;
        private ushort RoomNumber;

        class _Device
        {
            public ushort Id { get; set; }
            public string DeviceName { get; set; }
            public string DeviceImagePath { get; set; }
            public string DeviceToolTip { get; set; }
            public SolidColorBrush DeviceStatusColor { get; set; }
        }

        public Page_Devices()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var myList = e.Parameter as object[];
            LoadDevices((Library.Core.Room)myList[0], (ushort)myList[1]);

            Task Task_UpdateSensors = new Task(async () =>
            {
                if (((Library.Core.Room)myList[0]).Sensors.AmbientLight == null)
                {
                    ((Library.Core.Room)myList[0]).Sensors.AmbientLight = new Library.Core.Sensor.AmbientLight();
                }
                if (((Library.Core.Room)myList[0]).Sensors.PassiveIR == null)
                {
                    ((Library.Core.Room)myList[0]).Sensors.PassiveIR = new Library.Core.Sensor.PassiveIR();
                }
                if (((Library.Core.Room)myList[0]).Sensors.Temperature == null)
                {
                    ((Library.Core.Room)myList[0]).Sensors.Temperature = new Library.Core.Sensor.Temperature();
                }

                while (true)
                {
                    await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                                        () =>
                                        {
                                            lbl_PIR_Status.Text = (((Library.Core.Room)myList[0]).Sensors.PassiveIR.HumanDetected == true) ? "Detected" : "None";
                                            lbl_LightIntensity.Text = ((Library.Core.Room)myList[0]).Sensors.AmbientLight.RawData.ToString();
                                            lbl_Temp_C.Text = ((Library.Core.Room)myList[0]).Sensors.Temperature.Celsius.ToString() + " °C";

                                        });

                    await Task.Delay(1000);
                }
            });
            Task_UpdateSensors.Start();
        }

        public void LoadDevices(Library.Core.Room Room, ushort RoomNumber)
        {
            this.InitializeComponent();

            Devices = Room.Devices;
            this.RoomNumber = RoomNumber;

            foreach (var _Device in Room.Devices)
            {
                _Device _Dev = new _Device();
                _Dev.DeviceImagePath = _Device.ImagePath;
                _Dev.DeviceName = _Device.Name;

                if (_Device.Status == Library.Core.Device.StatusEnum.On)
                {
                    _Dev.DeviceStatusColor = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 99, 0));
                }
                else
                {
                    _Dev.DeviceStatusColor = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 128, 128, 128));
                }

                _Dev.Id = _Device.Id;
                _Dev.DeviceToolTip = "R" + RoomNumber.ToString() + "\\Dev" + _Device.Id.ToString();

                ListView_Devices.Items.Add(_Dev);
            }
            txt_RoomName.Text = Room.RoomName;
        }

        private void ListView_Devices_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            Library.Core.Device SelectedDevice = null;

            foreach (var _Dev in Devices)
            {
                if (((_Device)(ListView_Devices.SelectedItem)).Id == _Dev.Id)
                {
                    SelectedDevice = _Dev;
                    break;
                }
            }

            if (SelectedDevice.Status == Library.Core.Device.StatusEnum.On)
            {
                SelectedDevice.TurnOff();
            }
            else if (SelectedDevice.Status == Library.Core.Device.StatusEnum.Off)
            {
                SelectedDevice.TurnOn();
            }

            ListView_Devices.Items.Clear();

            foreach (var _Device in Devices)
            {
                _Device _Dev = new _Device();
                _Dev.DeviceImagePath = _Device.ImagePath;
                _Dev.DeviceName = _Device.Name;

                if (_Device.Status == Library.Core.Device.StatusEnum.On)
                {
                    _Dev.DeviceStatusColor = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 99, 0));
                }
                else
                {
                    _Dev.DeviceStatusColor = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 128, 128, 128));
                }

                _Dev.Id = _Device.Id;
                _Dev.DeviceToolTip = "R" + RoomNumber.ToString() + "\\Dev" + _Device.Id.ToString();

                ListView_Devices.Items.Add(_Dev);
            }
        }
    }
}
