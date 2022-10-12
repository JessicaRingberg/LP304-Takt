using LP304_Takt.DTO.CreateDTO;
using LP304_Takt.DTO.ReadDto;
using LP304_Takt.DTO.ReadDTO;
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
            return new AlarmTypeDto
            {
                Id = alarmType.Id,
                Name = alarmType.Name
                //Alarms = alarmType.Alarms.Select(a => a.AsDto()).ToList()
            };
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
        public static ArticleDto AsDto(this Article article)
        {
            return new ArticleDto
            {
                Id = article.Id,
                Name = article.Name,
                ArticleNumber = article.ArticleNumber
            };
        }
        public static CompanyDto AsDto(this Company company)
        {
            return new CompanyDto
            {
                Id = company.Id,
                Name = company.Name,
                Users = company.Users.Select(u => u.AsDto()).ToList(),
                Areas = company.Areas.Select(a => a.AsDto()).ToList()
            };
        }
        public static CompanyByUserDto AsUserCompanyDto(this User user)
        {
            return new CompanyByUserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Company = user.Company.Name
            };
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
            return new EventStatusDto
            {
                Id = eventStatus.Id,
                Name = eventStatus.Name
                //Events = eventStatus.Events.Select(e => e.AsDto()).ToList()
            };

        }
        public static OrderDetailsDto AsDto(this OrderDetails orderDetails)
        {
            return new OrderDetailsDto
            {
                Id = orderDetails.Id,
                Quantity = orderDetails.Quantity,
                Article = orderDetails.Article?.Name,
                OrderId = orderDetails.OrderId
               
            };
        }
      
        public static OrderDto AsDto(this Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                StartTime = order.StartTime,
                EndTime = order.EndTime,
                RunSetDec = order.RunSetDec,
                ChangeSetDec = order.ChangeSetDec,
                PartsProd = order.PartsProd,
                Backlog = order.Backlog,
                RunSecSet = order.RunSecSet,
                ChangeSecSet = order.ChangeSecSet,
                TaktSet = order.TaktSet,
                LastPartProd = order.LastPartProd,
                Takt = order.Takt,
                OrderDetails = order.OrderDetails.Select(o => o.AsDto()).ToList(),
                Alarms = order.Alarms.Select(a => a.AsDto()).ToList(),
                Events = order.Events.Select(e => e.AsDto()).ToList()
            };
        }
        public static OrderInQueueDto AsQueueDto(this Order order)
        {
            return new OrderInQueueDto
            {
                Id = order.Id,
            };
        }
        public static QueueDto AsDto(this Queue queue)
        {
            return new QueueDto
            {
                Id = queue.Id,
                Orders = queue.Orders.Select(o => o.AsQueueDto()).ToList()
            };
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

        
    }
}
