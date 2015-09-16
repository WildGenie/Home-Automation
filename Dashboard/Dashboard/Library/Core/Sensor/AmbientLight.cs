using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Library.Core.Sensor
{
    /// <summary>
    /// Provides access to Ambient Light of the room
    /// </summary>
    public class AmbientLight
    {
        /// <summary>
        /// Provides raw voltage data based upon light intensity.
        /// Please refer datasheet of the LDR you have used.
        /// </summary>
        public short RawData { get; set; }
    }
}
