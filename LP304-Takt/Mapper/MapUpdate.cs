using LP304_Takt.DTO;
using LP304_Takt.DTO.UpdateDTOs;
using LP304_Takt.Models;

namespace LP304_Takt.Mapper
{
    public static class MapUpdate
    {
        public static Alarm AsUpdated(this AlarmUpdateDto alarm)
        {
            return new Alarm
            {
                Reason = alarm.Reason
            };
        }
        public static Order AsUpdated(this OrderUpdateDto station)
        {
            return new Order
            {
                Quantity = station.Quantity
            };
        }
        public static Station AsUpdated(this StationUpdateDto station)
        {
            return new Station
            {
                Name = station.Name
            };
        }

    }
}
