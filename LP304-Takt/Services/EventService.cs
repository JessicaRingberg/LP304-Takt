﻿using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;

namespace LP304_Takt.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task Add(Event eEvent, int orderId, int eventStatusId)
        {
            await _eventRepository.Add(eEvent, orderId, eventStatusId);
        }

        public async Task DeleteEntity(int id)
        {
            await _eventRepository.DeleteEntity(id);
        }

        public async Task<ICollection<Event>> GetEntities()
        {
            return await _eventRepository.GetEntities();
        }

        public async Task<Event?> GetEntity(int id)
        {
            return await _eventRepository.GetEntity(id);
        }

        public async Task UpdateEvent(Event eEvent, int eventId)
        {
            await _eventRepository.UpdateEvent(eEvent, eventId);
        }
    }
}
