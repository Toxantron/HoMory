using System.ComponentModel;
using HoMory.Capabilities.Devices;

namespace HoMory.Resources.Building.Devices
{
    public class Television : Device
    {
        protected override void OnInitialize()
        {
            base.OnInitialize();

            Capabilities = new TvCapabilities();
        }

        [EditorBrowsable, Description("Toogle the TV on or off")]
        public override void Switch(bool on)
        {
            State = on ? DeviceState.On : DeviceState.Off;
        }
    }
}