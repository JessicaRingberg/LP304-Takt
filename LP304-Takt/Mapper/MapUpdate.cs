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
        public static AlarmType AsUpdated(this AlarmTypeUpdateDto alarmType)
        {
            return new AlarmType
            {
                Name = alarmType.Name
            };
        }

        public static Event AsUpdated(this EventUpdateDto eEvent)
        {
            return new Event
            {
                Reason = eEvent.Reason
            };
        }
        public static EventStatus AsUpdated(this EventStatusUpdateDto eventStatus)
        {
            return new EventStatus
            {
                Name = eventStatus.Name
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

        public static User AsUpdated(this UserUpdateDto user)
        {
            return new User
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password
            };
        }

    }
}
