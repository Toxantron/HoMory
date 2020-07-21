using Moryx.AbstractionLayer.Capabilities;

namespace HoMory.Capabilities
{
    /// <summary>
    /// Capabilities of devices that can be automatically turned on or off
    /// if the current power situation requires it. Examples for either case
    /// are freezers or washing machines.
    /// </summary>
    /// <example>
    /// A freezer has a default target temperature of -15°C in standby. It can
    /// consume excessive power to cool down to -25°C when turned on or can save
    /// power if turned off until it reaches -5°C. 
    /// </example> 
    public class SmartDeviceCapabilities : DeviceCapabilities
    {
        /// <summary>
        /// The device has capacitities to save power in times
        /// of power shortage.
        /// </summary>
        public bool CanSavePower { get; set; }

        /// <summary>
        /// The device can consume power that can be stored or
        /// would be used later anyway. 
        /// </summary>
        public bool CanConsumePower { get; set; }

        /// <summary>
        /// Check if the smart device can meet the current demands
        /// </summary>
        protected override bool ProvidedBy(ICapabilities provided)
        {
            var smartDevCapa = provided as SmartDeviceCapabilities;
            if (smartDevCapa == null)
                return false;

            if (CanSavePower && !smartDevCapa.CanSavePower)
                return false;

            if (CanConsumePower && !smartDevCapa.CanConsumePower)
                return false;

            return true;
        }
    }
}