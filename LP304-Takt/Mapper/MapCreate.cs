using LP304_Takt.DTO.CreateDTO;
using LP304_Takt.Models;

namespace LP304_Takt.Mapper
{
    public static class MapCreate
    {
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
        public static Article AsEntity(this ArticleCreateDto article)
        {
            return new Article
            {
                Name = article.Name,
                ArticleNumber = article.ArticleNumber
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

        public static OrderDetails AsEntity(this OrderDetailsCreateDto orderDetails)
        {
            return new OrderDetails
            {

                Quantity = orderDetails.Quantity
            };
        }
        public static Order AsEntity(this OrderCreateDto order)
        {
            return new Order
            {

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
                Takt = order.Takt
            };
        }

        public static Station AsEntity(this StationCreateDto station)
        {
            return new Station
            {
                Name = station.Name,
                Andon = station.Andon,
                Finished = station.Finished,
                Active = station.Active
            };
        }

    }
}
