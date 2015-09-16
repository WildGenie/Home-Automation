using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Library.Core
{
    [DataContract]
    public class Room
    {
        /// <summary>
        /// Get or set user-friendly name for room
        /// </summary>
        [DataMember]
        public string RoomName { get; set; }

        [DataMember]
        public string RoomImagePath { get; set; }

        /// <summary>
        /// Get or set Arduino's slave I2C address for the room
        /// </summary>
        [DataMember]
        public string I2C_Slave_Address { get; set; }


        /// <summary>
        /// Maintains list of devices, room have
        /// </summary>
        [DataMember]
        public List<Device> Devices;

        /// <summary>
        /// Provides access to the sensors of the room
        /// </summary>
        public struct Sensors
        {
            public Sensor.AmbientLight AmbientLight;
            public Sensor.PassiveIR PassiveIR;
            public Sensor.Temperature Temperature;
        }
        

    }
}
