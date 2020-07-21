using System.ComponentModel;
using System.Runtime.Serialization;
using Moryx.AbstractionLayer.Resources;

namespace HoMory.Resources.Building
{
    /// <summary>
    /// A floor within the building
    /// </summary>
    public class Floor : Resource, IBuildingPart
    {
        [ReferenceOverride(nameof(Children))]
        public IReferences<IRoom> Rooms { get; set; }

        [DataMember, EditorBrowsable]
        public int Level { get; set; }

        [ResourceConstructor]
        public void CreateFloor(int level, string name)
        {
            Name = name;
            Level = level;
        }
    }
}