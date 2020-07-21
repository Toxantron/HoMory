using Moryx.AbstractionLayer.Capabilities;

namespace HoMory.Capabilities.Devices
{
    /// <summary>
    /// Capabilities of different lights
    /// </summary>
    public class LightCapabilities : DeviceCapabilities
    {

        protected override bool ProvidedBy(ICapabilities provided)
        {
            return provided is LightCapabilities;
        }
    }
}