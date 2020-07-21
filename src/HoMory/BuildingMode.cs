using System;

namespace HoMory
{
    /// <summary>
    /// Different modes of the building that devices might support
    /// </summary>
    [Flags]
    public enum BuildingMode
    {
        /// <summary>
        /// Inhabitants are at home and all devices function normally. This is also 
        /// the default mode for devices that do not support any <see cref="BuildingMode"/>
        /// </summary>
        Standard = 0,

        /// <summary>
        /// Everyone is a asleep and the house enters sort of a standby mode
        /// </summary>
        Asleep = 1 << 3,

        /// <summary>
        /// The building is currently empty. Unused devices are shut down to 
        /// save power and avoid accidents unless they need to complete a task.
        /// </summary>
        Empty = 1 << 6,

        /// <summary>
        /// The house is empty for a vacation
        /// </summary>
        Vacation = 1 << 9,

        /// <summary>
        /// An intrusion or threat was detected. Inform authorities, activate all lights,
        /// protect inhabitants and property
        /// </summary>
        Threat = 1 << 12,

        /// <summary>
        /// A fire was detected. Shutdown additional hazards, lead inhabitants to safety
        /// and inform the fire department.
        /// </summary>
        Fire = 1 << 15,
    }
}