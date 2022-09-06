﻿using LP304_Takt.Models;

namespace LP304_Takt.Interfaces.Services
{
    public interface IEventService : IBaseService<Event>
    {
        Task Add(Event eEvent, int orderId);
    }
}