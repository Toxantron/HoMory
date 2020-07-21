using System.ComponentModel;
using Moryx.AbstractionLayer.Resources;

namespace HoMory.Resources.Building
{
    /// <summary>
    /// Outdoors is another important part for a complete building automation
    /// </summary>
    [Description("Area outside of the building like driveway or garden")]
    public class Outdoor : Resource, IBuildingPart
    {
        [ReferenceOverride(nameof(Children))]
        public IReferences<IDevice> Devices { get; set; }
    }
}