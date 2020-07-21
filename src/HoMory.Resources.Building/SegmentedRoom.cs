using System;
using System.ComponentModel;
using System.Linq;
using HoMory.Structs;
using Moryx.AbstractionLayer.Resources;

namespace HoMory.Resources.Building
{
    [ResourceRegistration, Description("Implementation for big, open rooms that have different functions. For example dining AND living room")]
    public class SegmentedRoom : PublicResource, IRoom
    {
        [ReferenceOverride(nameof(Children))]
        public IReferences<Room> Segments { get; set; }

        public LightIntensity Intensity
        {
            get { return LightIntensity.Dimmed((int)Segments.Average(s => s.Intensity.Intensity));}
            set
            {
                foreach (var segment in Segments)
                    segment.Intensity = value;
                IntensityChanged?.Invoke(this, value);
            }
        }

        public RoomTemperature Temperature => Segments.First().Temperature;

        public void SetTargetTemperature(double temperature)
        {
            foreach (var segment in Segments)
            {
                segment.SetTargetTemperature(temperature);
            }
        }

        public event EventHandler<LightIntensity> IntensityChanged;
    }
}