using Moryx.AbstractionLayer.Capabilities;

namespace HoMory.Capabilities
{
    /// <summary>
    /// Capabilities of devices within the house
    /// </summary>
    public class DeviceCapabilities : ConcreteCapabilities
    {
        /// <summary>
        /// Check if the given capabilities are device capabilities
        /// </summary>
        protected override bool ProvidedBy(ICapabilities provided)
        {
            return provided is DeviceCapabilities;
        }
    }
}