using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Library.Core.Sensor
{
    /// <summary>
    /// Provides room temperature
    /// </summary>
    public class Temperature
    {
        private double _Celsius;
        public double Celsius { get { return _Celsius; } set { _Celsius = value; } }
        public double Fahrenheit { get { return ((Celsius * 1.8) + 32); } }
        public double Kelvin { get { return (Celsius + 273); } }
    }
}
