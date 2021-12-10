using System;
using HoMory.Structs;
using Moryx.AbstractionLayer.Resources;

namespace HoMory.Resources
{
    /// <summary>
    /// Resource that represents a room of 
    /// </summary>
    public interface IRoom : IPublicResource
    {
        /// <summary>
        /// Get the current intensity of the light
        /// or set the desired value
        /// </summary>
        LightIntensity Intensity { get; set; }

        /// <summary>
        /// Current and desired temperature of the room
        /// </summary>
        RoomTemperature Temperature { get; }

        /// <summary>
        /// Set the target temperature
        /// </summary>
        void SetTargetTemperature(double temperature);

        /// <summary>
        /// Event raised when the rooms light intensity changed
        /// </summary>
        event EventHandler<LightIntensity> IntensityChanged;
    }
}