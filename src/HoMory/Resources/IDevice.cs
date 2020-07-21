using System;
using Moryx.AbstractionLayer.Resources;

namespace HoMory.Resources
{
    /// <summary>
    /// Interface for all devices within the building
    /// </summary>
    public interface IDevice : IPublicResource
    {
        /// <summary>
        /// Parent resource where this device is located. Might be a room, area etc.
        /// </summary>
        IResource Location { get; }

        /// <summary>
        /// Current state of the device
        /// </summary>
        DeviceState State { get; }

        /// <summary>
        /// Switch device either on or off
        /// </summary>
        void Switch(bool on);

        /// <summary>
        /// Event raised, when the devices state changed
        /// </summary>
        event EventHandler<DeviceState> StateChanged;
    }

    /// <summary>
    /// Current state of the device
    /// </summary>
    public enum DeviceState
    {
        /// <summary>
        /// Device is off
        /// </summary>
        Off = 0,

        /// <summary>
        /// Device is currently in standby
        /// </summary>
        Standby = 1,

        /// <summary>
        /// Device is currently on
        /// </summary>
        On = 2
    }
}