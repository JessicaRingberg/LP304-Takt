using LP304_Takt.DTO;
using LP304_Takt.DTO.UpdateDTO;
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
        public static Area AsUpdated(this AreaUpdateDto area)
        {
            return new Area
            {
                Name = area.Name
            };
        }
        public static Article AsUpdated(this ArticleUpdateDto article)
        {
            return new Article
            {
                Name = article.Name,
                ArticleNumber = article.ArticleNumber
            };
        }
        public static Company AsUpdated(this CompanyUpdateDto company)
        {
            return new Company
            {
                Name = company.Name
            };
        }

        public static Config AsUpdated(this ConfigUpdateDto config)
        {
            return new Config
            {
                MacBidisp = config.MacBidisp
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
        public static OrderDetails AsUpdated(this OrderDetailsUpdateDto orderDetails)
        {
            return new OrderDetails
            {
                Quantity = orderDetails.Quantity
   
            };
        }
        public static Order AsUpdated(this OrderUpdateDto order)
        {
            return new Order
            {
                StartTime = order.StartTime,
                EndTime = order.EndTime,
                RunSetDec = order.RunSetDec,
                RunSecSet = order.RunSecSet,
                ChangeSecSet = order.ChangeSecSet,
                ChangeSetDec = order.ChangeSetDec,
                PartsProd = order.PartsProd,
                LastPartProd = order.LastPartProd,
                Backlog = order.Backlog,
                TaktSet = order.TaktSet,
                Takt = order.Takt
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
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }

    }
}
