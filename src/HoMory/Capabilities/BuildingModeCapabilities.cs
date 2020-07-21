using System.Runtime.Serialization;
using HoMory.Resources;
using Moryx.AbstractionLayer.Capabilities;

namespace HoMory.Capabilities
{
    /// <summary>
    /// Interface for building mode capabilities to provide them 
    /// either is combined capabilities or from other capabilities
    /// </summary>
    public interface IBuildingModeCapabilities : ICapabilities
    {
        /// <summary>
        /// Modes supported by this resource
        /// </summary>
        BuildingMode SupportedModes { get; }
    }

    /// <summary>
    /// Capabilities class to provide or search for <see cref="IModeAware"/> resources
    /// </summary>
    public class BuildingModeCapabilities : ConcreteCapabilities, IBuildingModeCapabilities
    {
        /// <summary>
        /// Required or supported building modes
        /// </summary>
        public BuildingMode SupportedModes { get; set; }

        /// <summary>
        /// Check if the provided capabilities are <see cref="IBuildingModeCapabilities"/>
        /// and if the support the required modes
        /// </summary>
        protected override bool ProvidedBy(ICapabilities provided)
        {
            return ((provided as IBuildingModeCapabilities)?.SupportedModes & SupportedModes) == SupportedModes;
        }
    }
}