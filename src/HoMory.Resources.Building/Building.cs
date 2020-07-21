using Moryx.AbstractionLayer.Resources;

namespace HoMory.Resources.Building
{
    public class Building : Resource
    {
        [ReferenceOverride(nameof(Children))]
        public IReferences<IBuildingPart> Parts { get; set; }
    }
}