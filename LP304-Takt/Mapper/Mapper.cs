using LP304_Takt.DTO;
using LP304_Takt.Models;

namespace LP304_Takt.Mapper
{
    public static class Mapper
    {
        public static AlarmDto AsDto(this Alarm alarm)
        {
            return new AlarmDto
            {
                Id = alarm.Id,
                StartTime = alarm.StartTime,
                EndTime = alarm.EndTime,
                Duration = alarm.Duration,
                Reason = alarm.Reason,
                AlarmType = alarm.AlarmType?.Name
            };
        }

        public static AlarmTypeDto AsDto(this AlarmType alarmType)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            return new AlarmTypeDto
            {
                Id = alarmType.Id,
                Name = alarmType.Name,
                Alarms = alarmType.Alarms.Select(a => a.AsDto()).ToList()
            };
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public static AreaDto AsDto(this Area area)
        {
            return new AreaDto
            {
                Id = area.Id,
                Name = area.Name,
                Stations = area.Stations.Select(s => s.AsDto()).ToList()
            };
        }

        public static CompanyDto AsDto(this Company company)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            return new CompanyDto
            {
                Id = company.Id,
                Name = company.Name,
                Users = company.Users.Select(u => u.AsDto()).ToList(),
                Areas = company.Areas.Select(a => a.AsDto()).ToList()
            };
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public static ConfigDto AsDto(this Config config)
        {
            return new ConfigDto
            {
                Id = config.Id,
                LightsOn = config.LightsOn,
                SoundOn = config.SoundOn,
                FilterTime = config.FilterTime,
                MacBidisp = config.MacBidisp
             
            };
        }

        public static EventDto AsDto(this Event eEvent)
        {
            return new EventDto
            {
                Id = eEvent.Id,
                StartTime = eEvent.StartTime,
                EndTime = eEvent.EndTime,
                Duration = eEvent.Duration,
                Reason = eEvent.Reason,
                EventStatus = eEvent.EventStatus?.Name
            };
        }

        public static EventStatusDto AsDto(this EventStatus eventStatus)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            return new EventStatusDto
            {
                Id = eventStatus.Id,
                Name = eventStatus.Name,
                Events = eventStatus.Events.Select(e => e.AsDto()).ToList()
            };
#pragma warning restore CS8604 // Possible null reference argument.

        }

        public static OrderDto AsDto(this Order order)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            return new OrderDto
            {
                Id = order.Id,
                StartTime = order.StartTime,
                EndTime = order.EndTime,
                Quantity = order.Quantity,
                RunSetDec = order.RunSetDec,
                ChangeSetDec = order.ChangeSetDec,
                PartsProd = order.PartsProd,
                Backlog = order.Backlog,
                RunSecSet = order.RunSecSet,
                ChangeSecSet = order.ChangeSecSet,
                TaktSet = order.TaktSet,
                LastPartProd = order.LastPartProd,
                Takt = order.Takt,
                StationId = order.StationId,
                Alarms = order.Alarms.Select(a => a.AsDto()).ToList(),
                Events = order.Events.Select(e => e.AsDto()).ToList()
            };
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public static StationDto AsDto(this Station station)
        {
            return new StationDto
            {
                Id = station.Id,
                Name = station.Name,
                Andon = station.Andon,
                Finished = station.Finished
            };
        }

        public static UserDto AsDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
     


            };
        }



        public static Alarm AsEntity(this AlarmCreateDto alarm)
        {
            return new Alarm
            {
                StartTime = alarm.StartTime,
                EndTime = alarm.EndTime,
                Duration = alarm.Duration,
                Reason = alarm.Reason
            };
        }

        public static AlarmType AsEntity(this AlarmTypeCreateDto alarmType)
        {
            return new AlarmType
            {
                Name = alarmType.Name
            };
        }

        public static Area AsEntity(this AreaCreateDto area)
        {
            return new Area
            {
                Name = area.Name
            };
        }

        public static Company AsEntity(this CompanyCreateDto company)
        {
            return new Company
            {
                Name = company.Name
            };
        }

        public static Config AsEntity(this ConfigCreateDto config)
        {
            return new Config
            {
                LightsOn = config.LightsOn,
                SoundOn = config.SoundOn,
                FilterTime = config.FilterTime,
                MacBidisp = config.MacBidisp
            };
        }

        public static Event AsEntity(this EventCreateDto eEvent)
        {
            return new Event
            {
                StartTime = eEvent.StartTime,
                EndTime = eEvent.EndTime,
                Duration = eEvent.Duration,
                Reason = eEvent.Reason
            };
        }

        public static EventStatus AsEntity(this EventStatusCreateDto eventStatus)
        {
            return new EventStatus
            {
                Name = eventStatus.Name
            };
        }

        public static Order AsEntity(this OrderCreateDto order)
        {
            return new Order
            {

                StartTime = order.StartTime,
                EndTime = order.EndTime,
                Quantity = order.Quantity,
                RunSetDec = order.RunSetDec,
                ChangeSetDec = order.ChangeSetDec,
                PartsProd = order.PartsProd,
                Backlog = order.Backlog,
                RunSecSet = order.RunSecSet,
                ChangeSecSet = order.ChangeSecSet,
                TaktSet = order.TaktSet,
                LastPartProd = order.LastPartProd,
                Takt = order.Takt
            };
        }


        public static Station AsEntity(this StationCreateDto station)
        {
            return new Station
            {
                Name = station.Name,
                Andon = station.Andon,
                Finished = station.Finished
            };
        }

        public static User AsEntity(this UserCreateDto user)
        {
            return new User
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        
    }
}
