using Moryx.AbstractionLayer.Capabilities;

namespace HoMory.Capabilities
{
    /// <summary>
    /// Capabilities of a room
    /// </summary>
    public class RoomCapabilities : ConcreteCapabilities
    {
        /// <summary>
        /// Check if the given capabilities are room capabilities
        /// </summary>
        protected override bool ProvidedBy(ICapabilities provided)
        {
            return provided is RoomCapabilities;
        }
    }
}