namespace HoMory.Structs
{
    /// <summary>
    /// Current and desired temperature
    /// </summary>
    public struct RoomTemperature
    {
        /// <summary>
        /// Current temperature of the room
        /// </summary>
        public double CurrentTemperature { get; }

        /// <summary>
        /// Desired temperature of the room
        /// </summary>
        public double TargetTemperature { get; }

        /// <summary>
        /// Create <see cref="RoomTemperature"/> from current and desired temperature
        /// </summary>
        public RoomTemperature(double currentTemperature, double targetTemperature)
        {
            CurrentTemperature = currentTemperature;
            TargetTemperature = targetTemperature;
        }

        /// <summary>
        /// Flag if the room is currently heating
        /// </summary>
        public bool IsHeating => TargetTemperature > CurrentTemperature;

        /// <summary>
        /// Set a new target temperature
        /// </summary>
        public RoomTemperature SetTarget(double targetTemperature)
        {
            return new RoomTemperature(CurrentTemperature, targetTemperature);
        }

        /// <summary>
        /// Update the current temperature of the room with the latest values
        /// from the thermostat
        /// </summary>
        public RoomTemperature UpdateCurrent(double currentTemperature)
        {
            return new RoomTemperature(currentTemperature, TargetTemperature);
        }
    }
}