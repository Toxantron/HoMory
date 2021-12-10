using Moryx.AbstractionLayer.Resources;

namespace HoMory.Resources
{
    /// <summary>
    /// Interface for a public resource that can adapt to the current mode
    /// </summary>
    public interface IModeAware : IPublicResource
    {
        /// <summary>
        /// Set the new building mode and let the resource reach upon it
        /// </summary>
        void SetMode(BuildingMode mode);
    }
}