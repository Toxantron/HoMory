using System.ComponentModel;
using Moryx.AbstractionLayer.Drivers;
using Moryx.AbstractionLayer.Resources;

namespace HoMory.Resources.Building
{
    /// <summary>
    /// Central control unit that has all drivers
    /// </summary>
    [Description("Central control unit of the building with its drivers and connectivity")]
    public class BuildingControl : Resource, IBuildingPart
    {
        [ReferenceOverride(nameof(Children))]
        public IReferences<IDriver> Drivers { get; set; }
    }
}