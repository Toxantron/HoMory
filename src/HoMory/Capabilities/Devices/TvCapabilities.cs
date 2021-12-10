using Moryx.AbstractionLayer.Capabilities;

namespace HoMory.Capabilities.Devices
{
    /// <summary>
    /// Capabilities of the TV
    /// </summary>
    public class TvCapabilities : DeviceCapabilities
    {
        /// <summary>
        /// Check if the given device capabilities represent a TV
        /// </summary>
        protected override bool ProvidedBy(ICapabilities provided)
        {
            return provided is TvCapabilities;
        }
    }
}