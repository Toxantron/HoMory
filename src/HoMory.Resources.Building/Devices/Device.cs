using System;
using System.ComponentModel;
using Moryx.AbstractionLayer.Resources;

namespace HoMory.Resources.Building.Devices
{
    /// <summary>
    /// Base class for devices
    /// </summary>
    public abstract class Device : PublicResource, IDevice
    {
        public IResource Location => Parent;

        private DeviceState _state;
        public DeviceState State
        {
            get { return _state; }
            set
            {
                _state = value;
                StateChanged?.Invoke(this, value);
            }
        }

        [EditorBrowsable]
        public abstract void Switch(bool on);

        public event EventHandler<DeviceState> StateChanged;
    }
}