using HoMory.Structs;
using Moryx.AbstractionLayer.Resources;

namespace HoMory.Resources.Building.Devices
{
    public class SplitLight : Light
    {
        /// <summary>
        /// Split spots can control individual spots
        /// </summary>
        [ReferenceOverride(nameof(Children))]
        public IReferences<ILight> SpotGroups { get; set; }

        protected override LightIntensity SetIntensity(LightIntensity intensity)
        {
            foreach (var spotGroup in SpotGroups)
            {
                spotGroup.Intensity = intensity;
            }
            return intensity;
        }
    }
}