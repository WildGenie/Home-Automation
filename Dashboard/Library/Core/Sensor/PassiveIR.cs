using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Library.Core.Sensor
{
    /// <summary>
    /// Provides access to PassiveIR (Human detector)
    /// </summary>
    public class PassiveIR
    {
        private bool _HumanDetected = false;

        /// <summary>
        /// Provides possible human detection scheme.
        /// </summary>
        public enum EnumHumanPresenseStatus : byte
        {
            HumanPresenceDetected,
            None
        }

        /// <summary>
        /// Automatically will be fired when detection status changed.
        /// </summary>
        public event Action<EnumHumanPresenseStatus> HumanPresenceChanged_EventHandler;

        /// <summary>
        /// Gets or set Human Detection Status. Also fires event (HumanPresenceChanged_EventHandler) if old status was different that current.
        /// </summary>
        public bool HumanDetected
        {
            get
            {
                return _HumanDetected;
            }

            set
            {
                // Check old value with new one to avoid frequently fire event for same detection status.
                if (_HumanDetected != value)
                {
                    // Fire appropriate event if event handler is not null.
                    if (HumanPresenceChanged_EventHandler != null)
                    {
                        if (value == true)
                        {
                            HumanPresenceChanged_EventHandler(EnumHumanPresenseStatus.HumanPresenceDetected);
                        }
                        else
                        {
                            HumanPresenceChanged_EventHandler(EnumHumanPresenseStatus.None);
                        }
                    }
                }

                // Update _HumanDetected variable after checking old value to fire event.
                _HumanDetected = value;
            }
        }
    }
}
