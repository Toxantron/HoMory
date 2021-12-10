using System;

namespace HoMory.Structs
{
    /// <summary>
    /// Struct that represents the state of a single light. This can be the current state
    /// or the desired state
    /// </summary>
    public struct LightIntensity : IEquatable<LightIntensity>, IComparable<LightIntensity>
    {
        /// <summary>
        /// 0 is considered the minimum intensity
        /// </summary>
        private const int MinIntensity = 0;

        /// <summary>
        /// 100% per-cent is considered the maximum intensity
        /// </summary>
        private const int MaxIntensity = 100;

        /// <summary>
        /// Create light state for a certain identity
        /// </summary>
        private LightIntensity(int intensity)
        {
            Intensity = intensity;
        }

        /// <summary>
        /// Light intensity in percent. For non dimmable lights
        /// <value>LightState.Off</value> is 0 and <value>LightIntensity.On</value>
        /// is 100.
        /// </summary>
        public int Intensity { get; }

        /// <summary>
        /// Flag if the light is currently on
        /// </summary>
        public bool IsOn => Intensity > MinIntensity;

        /// <summary>
        /// Flag if the light is currently dimmed
        /// </summary>
        public bool IsDimmed => Intensity > MinIntensity & Intensity < MaxIntensity;

        /// <summary>
        /// Light is off
        /// </summary>
        public static LightIntensity Off = new LightIntensity(MinIntensity);

        /// <summary>
        /// Light is 
        /// </summary>
        public static LightIntensity On = new LightIntensity(MaxIntensity);

        /// <summary>
        /// Light is currently dimmed to the given intensity in percent
        /// </summary>
        /// <param name="intensity">Current intensity of the light in percent.</param>
        public static LightIntensity Dimmed(int intensity)
        {
            // All values greater or equal 100 are interpreted as "On"
            if (intensity >= MaxIntensity)
                return On;

            // Values less or equal 0 are interpreted as "Off"
            if (intensity <= MinIntensity)
                return Off;

            // Otherwise return a truly dimmed value
            return new LightIntensity(intensity);
        }

        /// <summary>
        /// In case the light is not dimmable it can reinterpret the
        /// intensity as either on or off based on a threshold
        /// </summary>
        public LightIntensity AsDigital(int threshold)
        {
            return AsDigital(threshold, MaxIntensity);
        }

        /// <summary>
        /// In case the light is not dimmable it can reinterpret the
        /// intensity as either on or off based on a thresholds. Light
        /// is on if the value is between <paramref name="minIntensity"/>
        /// and <paramref name="maxIntensity"/>, otherwise off.
        /// </summary>
        public LightIntensity AsDigital(int minIntensity, int maxIntensity)
        {
            return Intensity > minIntensity & Intensity <= maxIntensity ? On : Off;
        }

        #region Operators

        /// <summary>
        /// Increase light intensity
        /// </summary>
        /// <param name="lightIntensity">Current light state</param>
        /// <param name="increase">Increase in percent</param>
        public static LightIntensity operator +(LightIntensity lightIntensity, int increase)
        {
            return Dimmed(lightIntensity.Intensity + increase);
        }

        /// <summary>
        /// Decrease light intensity
        /// </summary>
        /// <param name="lightIntensity">Current light state</param>
        /// <param name="decrease">Decrease in percent</param>
        public static LightIntensity operator -(LightIntensity lightIntensity, int decrease)
        {
            return Dimmed(lightIntensity.Intensity - decrease);
        }

        /// <summary>
        /// Multiply light intensity
        /// </summary>
        /// <param name="lightIntensity">Current light state</param>
        /// <param name="factor">Absolute factor</param>
        public static LightIntensity operator *(LightIntensity lightIntensity, double factor)
        {
            var intensity = Math.Round(lightIntensity.Intensity * factor);
            return Dimmed((int)intensity);
        }

        /// <summary>
        /// Devide light intensity
        /// </summary>
        /// <param name="lightIntensity">Current light state</param>
        /// <param name="denominator">Denominator</param>
        public static LightIntensity operator /(LightIntensity lightIntensity, double denominator)
        {
            var intensity = Math.Round(lightIntensity.Intensity / denominator);
            return Dimmed((int)intensity);
        }

        #endregion

        #region IEquatable

        /// <summary>
        /// Compare this light state to another instance
        /// </summary>
        public bool Equals(LightIntensity other)
        {
            return Intensity == other.Intensity;
        }

        /// <summary>
        /// Override equals of <see cref="object"/> as well
        /// </summary>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is LightIntensity && Equals((LightIntensity) obj);
        }

        /// <summary>
        /// Override hashcode with Light intensity
        /// </summary>
        public override int GetHashCode()
        {
            return Intensity;
        }

        public static bool operator ==(LightIntensity a, LightIntensity b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(LightIntensity a, LightIntensity b)
        {
            return !a.Equals(b);
        }

        #endregion

        #region IComparable

        /// <summary>
        /// Compare this <see cref="LightIntensity"/> to another one regarding
        /// relative intensity
        /// </summary>
        public int CompareTo(LightIntensity other)
        {
            return Intensity.CompareTo(other.Intensity);
        }

        #endregion
    }
}