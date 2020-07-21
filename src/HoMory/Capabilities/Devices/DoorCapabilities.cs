using Moryx.AbstractionLayer.Capabilities;

namespace HoMory.Capabilities.Devices
{
    /// <summary>
    /// Capabilities for different types of door
    /// </summary>
    public class DoorCapabilities : DeviceCapabilities
    {
        public DoorType DoorType { get; set; }

        protected override bool ProvidedBy(ICapabilities provided)
        {
            return (provided as DoorCapabilities)?.DoorType == DoorType;
        }
    }

    /// <summary>
    /// Type of door
    /// </summary>
    public enum DoorType
    {
        /// <summary>
        /// Main entry of the building
        /// </summary>
        Entry = 1,

        /// <summary>
        /// Garage door
        /// </summary>
        Garage = 2
    }
}