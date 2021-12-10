namespace HoMory.Capabilities.Devices
{
    /// <summary>
    /// Specialized capabilities for lights outside of the house
    /// </summary>
    public class OutdoorLightCapabilities : LightCapabilities, IBuildingModeCapabilities
    {
        /// <summary>
        /// Outdoor lights can support building modes, but otherwise are normal lights
        /// </summary>
        public BuildingMode SupportedModes { get; set; }
    }
}