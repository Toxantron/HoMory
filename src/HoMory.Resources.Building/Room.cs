using System;
using System.ComponentModel;
using System.Linq;
using HoMory.Capabilities;
using HoMory.Resources.Building.Devices;
using HoMory.Structs;
using Moryx.AbstractionLayer.Resources;

namespace HoMory.Resources.Building
{
    [ResourceRegistration, Description("Default implementation of a room, that will cover most cases")]
    public class Room : PublicResource, IRoom
    {
        private LightIntensity _intensity = LightIntensity.Off;

        public LightIntensity Intensity
        {
            get { return _intensity; }
            set
            {
                _intensity = value;
                SetLightIntensity(_intensity);
                IntensityChanged?.Invoke(this, value);
            }
        }

        /// <summary>
        /// Temperature of the room. Assume standard temperature after boot
        /// </summary>
        public RoomTemperature Temperature { get; private set; } = new RoomTemperature(20, 20);

        /// <summary>
        /// Quick indicator from UI if light is currently on
        /// </summary>
        [EditorBrowsable]
        public bool IsOn => Intensity.IsOn;

        /// <summary>
        /// A room can only contain devices
        /// </summary>
        [ReferenceOverride(nameof(Children))]
        public IReferences<IDevice> Devices { get; set; }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            // We need initial capabilities to be public
            Capabilities = InitialCapabilities();

            // Register to state changes on buttons to activate all lights
            foreach (var button in Devices.OfType<Button>())
            {
                button.StateChanged += OnButtonChanged;
            }
        }

        /// <summary>
        /// Initial capabilities are virtual
        /// </summary>
        protected virtual RoomCapabilities InitialCapabilities()
        {
            return new RoomCapabilities();
        }

        protected override void OnDispose()
        {
            foreach (var button in Devices.OfType<Button>())
            {
                button.StateChanged -= OnButtonChanged;
            }

            base.OnDispose();
        }

        /// <summary>
        /// Set the target temperature of the room
        /// </summary>
        /// <param name="temperature"></param>
        [EditorBrowsable, DisplayName("Set Temperature")]
        public virtual void SetTargetTemperature([Description("Desired temperature in °C")]double temperature)
        {
            Temperature = Temperature.SetTarget(temperature);
        }

        /// <summary>
        /// Set light intensity
        /// </summary>
        protected virtual void SetLightIntensity(LightIntensity intensity)
        {
            foreach (var light in Devices.OfType<ILight>())
            {
                light.Intensity = intensity;
            }
        }

        /// <summary>
        /// Event raised when a button of the room changed its state
        /// </summary>
        private void OnButtonChanged(object sender, DeviceState state)
        {
            if (state == DeviceState.On)
                Intensity = Intensity.IsOn ? LightIntensity.Off : LightIntensity.On;
        }

        public event EventHandler<LightIntensity> IntensityChanged;


        [EditorBrowsable, DisplayName("Toggle")]
        public bool ToggleLights(bool on)
        {
            return (Intensity = on ? LightIntensity.On : LightIntensity.Off).IsOn;
        }

        [EditorBrowsable, DisplayName("Dimm")]
        public void DimmLights(int intensity)
        {
            Intensity = LightIntensity.Dimmed(intensity);
        }
    }
}