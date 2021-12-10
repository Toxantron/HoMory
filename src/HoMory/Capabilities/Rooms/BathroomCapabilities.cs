using System;
using System.Runtime.Serialization;
using Moryx.AbstractionLayer.Capabilities;

namespace HoMory.Capabilities.Rooms
{
    /// <summary>
    /// Capabilities of a bathroom
    /// </summary>
    public class BathroomCapabilities : RoomCapabilities
    {
        /// <summary>
        /// Provided or requested facilities
        /// </summary>
        public BathroomFacilities Facilities { get; set; }

        /// <inheritdoc cref="RoomCapabilities"/>
        protected override bool ProvidedBy(ICapabilities provided)
        {
            var providedBathCapa = provided as BathroomCapabilities;
            return providedBathCapa != null && (providedBathCapa.Facilities & Facilities) == Facilities;
        }
    }

    /// <summary>
    /// Provided facilities of that bathroom
    /// </summary>
    [Flags]
    public enum BathroomFacilities
    {
        /// <summary>
        /// No facilities requested. Used to find bathrooms
        /// </summary>
        None = 0,

        /// <summary>
        /// Bathroom has a sing
        /// </summary>
        Sink = 1,

        /// <summary>
        /// Bathroom has a toilet
        /// </summary>
        Toilet = 2,

        /// <summary>
        /// Bathroom offers a shower
        /// </summary>
        Shower = 4,

        /// <summary>
        /// The bathroom includes a bathtub
        /// </summary>
        Bathtub = 8,
    }
}