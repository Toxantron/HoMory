using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using HoMory.Structs;
using Moryx.AbstractionLayer.Resources;

namespace HoMory.Resources.Building.Devices
{
    /// <summary>
    /// Base class for different implementations of lights
    /// </summary>
    public abstract class Light : PublicResource, ILight
    {
        private LightIntensity _intensity;
        /// <summary>
        /// Current intensity of the light
        /// </summary>
        public LightIntensity Intensity
        {
            get { return _intensity; }
            set
            {
                var newIntensity = SetIntensity(value);
                if (newIntensity == _intensity)
                    return;

                _intensity = newIntensity;
                StateChanged?.Invoke(this, State);
            }
        }

        /// <summary>
        /// <see cref="Room"/> or <see cref="Floor"/> where this is located
        /// </summary>
        public IResource Location => Parent;

        /// <summary>
        /// Lights are either on or off
        /// </summary>
        public DeviceState State => Intensity.IsOn ? DeviceState.On : DeviceState.Off;

        /// <summary>
        /// Flag if the light is currently on
        /// </summary>
        [EditorBrowsable]
        public bool IsOn => Intensity.IsOn;

        /// <summary>
        /// Intensity value up to where this light is considered off
        /// </summary>
        [DataMember, EditorBrowsable]
        [Description("Intensity value up to where this light is considered off")]
        public int MinThreshold { get; set; }

        /// <summary>
        /// Intensity value up to which this light is considered on
        /// </summary>
        [DataMember, EditorBrowsable, DefaultValue(100)]
        [Description("Intensity value up to which this light is considered on")]
        public int MaxThreshold { get; set; }

        /// <summary>
        /// Set new light intensity in the real world
        /// </summary>
        /// <param name="intensity">The desired intensity</param>
        /// <returns>The resulting intensity</returns>
        protected abstract LightIntensity SetIntensity(LightIntensity intensity);

        /// <summary>
        /// Switch the light on or off
        /// </summary>
        [EditorBrowsable, DisplayName("Toggle")]
        public void Switch(bool on)
        {
            Intensity = on ? LightIntensity.Dimmed(MaxThreshold) : LightIntensity.Off;
        }

        /// <summary>
        /// Event raised when the lights state has changed
        /// </summary>
        public event EventHandler<DeviceState> StateChanged;
    }
}