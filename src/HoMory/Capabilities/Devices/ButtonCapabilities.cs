using Moryx.AbstractionLayer.Capabilities;

namespace HoMory.Capabilities.Devices
{
    /// <summary>
    /// Buttons are a special sort of device 
    /// </summary>
    public class ButtonCapabilities : DeviceCapabilities
    {
        protected override bool ProvidedBy(ICapabilities provided)
        {
            return provided is ButtonCapabilities;
        }
    }
}