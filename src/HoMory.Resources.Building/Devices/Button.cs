using HoMory.Capabilities.Devices;

namespace HoMory.Resources.Building.Devices
{
    /// <summary>
    /// Buttons are specialized devices
    /// </summary>
    public abstract class Button : Device
    {
        protected override void OnInitialize()
        {
            base.OnInitialize();

            Capabilities = new ButtonCapabilities();
        }

        public override void Switch(bool @on)
        {
            State = on ? DeviceState.On : DeviceState.Off;
        }
    }
}