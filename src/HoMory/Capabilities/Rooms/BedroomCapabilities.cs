using System;
using Moryx.AbstractionLayer.Capabilities;

namespace HoMory.Capabilities.Rooms
{
    /// <summary>
    /// Capabilities of different types of bedrooms
    /// </summary>
    public class BedroomCapabilities : RoomCapabilities
    {
        /// <summary>
        /// Type of bedroom
        /// </summary>
        public BedroomType Type { get; set; }

       
        protected override bool ProvidedBy(ICapabilities provided)
        {
            return ((provided as BedroomCapabilities)?.Type & Type) == Type;
        }
    }

    /// <summary>
    /// Flags of bedroom types. A room can have more then one type
    /// </summary>
    [Flags]
    public enum BedroomType
    {
        /// <summary>
        /// Explicit value for the enum
        /// </summary>
        Unset = 0,

        /// <summary>
        /// The parent or major bedroom of the house
        /// </summary>
        Parent = 1,

        /// <summary>
        /// A kids bedromm
        /// </summary>
        Children = 2,

        /// <summary>
        /// A guest room
        /// </summary>
        Guest = 4,

        /// <summary>
        /// The room is for rent
        /// </summary>
        ForRent = 8
    }
}