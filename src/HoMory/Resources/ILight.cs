using HoMory.Structs;

namespace HoMory.Resources
{
    /// <summary>
    /// API for all resources that represent some sort of light
    /// </summary>
    public interface ILight : IDevice
    {
        /// <summary>
        /// Get the current intensity of the light
        /// or set the desired value
        /// </summary>
        LightIntensity Intensity { get; set; }
    }
}