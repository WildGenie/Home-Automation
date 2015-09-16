using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Library.Core
{
    [DataContract]
    public class Device
    {
        public enum StatusEnum
        {
            Off,
            On,
            NotAvailable
        }
        
        public enum PinsEnum
        {
            /// <summary>
            /// Also used for Serial RX
            /// </summary>
            D0,
            /// <summary>
            /// Also used for Serial TX
            /// </summary>
            D1,
            /// <summary>
            /// Also provides PWM
            /// </summary>
            D3,
            D4,
            /// <summary>
            /// Also provides PWM
            /// </summary>
            D5,
            /// <summary>
            /// Also provides PWM
            /// </summary>
            D6,
            D7,
            D8,
            /// <summary>
            /// Also provides PWM
            /// </summary>
            D9,
            /// <summary>
            /// Also provides PWM
            /// </summary>
            D10,
            /// <summary>
            /// Also provides PWM
            /// </summary>
            D11,
            D12,
            A2,
            A3
        }

        [DataMember]
        public UInt16 Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ImagePath { get; set; }

        /// <summary>
        /// Arduino pin number (usable pins are Digital [0-1, 3-12] & Analog [A2-A3]).
        /// Do not use D13 because it flickers when Arduino boots, so it may fries sensitive device.
        /// </summary>
        [DataMember]
        public PinsEnum Pin { get; set; }

        /// <summary>
        /// Provides current status of the device
        /// </summary>
        public StatusEnum Status { get; set; }

        /// <summary>
        /// Turns on device
        /// </summary>
        /// <returns>Returns the status of device after operation</returns>
        public StatusEnum TurnOn()
        {
            // Todo : Device -> TurnOn
            Status = StatusEnum.On;
            return StatusEnum.NotAvailable;
        }

        /// <summary>
        /// Turns off device
        /// </summary>
        /// <returns>Returns the status of device after operation</returns>
        public StatusEnum TurnOff()
        {
            // Todo : Device -> TurnOff
            Status = StatusEnum.Off;
            return StatusEnum.NotAvailable;
        }
    }
}
