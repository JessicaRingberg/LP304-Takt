﻿using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<ServiceResponse<int>> Add(Event eEvent, int orderId, int eventStatusId)
        {
            return await _eventRepository.Add(eEvent, orderId, eventStatusId);
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

        public async Task UpdateEntity(Event eEvent, int eventId)
        {
            await _eventRepository.UpdateEntity(eEvent, eventId);
        }
    }
}
