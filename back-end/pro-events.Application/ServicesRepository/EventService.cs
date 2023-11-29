using AutoMapper;
using pro_events.Application.DTO.Events;
using pro_events.Application.IServices;
using pro_events.Domain;
using pro_events.Persistence.Extensions;
using pro_events.Persistence.Helpers;
using pro_events.Persistence.IPersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_events.Application.ServicesRepository
{
    public class EventService : IEventService
    {
        private readonly IEventsPersistence _eventPersistence;
        private readonly IDefaultPersistence _persistence;
        private readonly IMapper _mapper;

        public EventService(IEventsPersistence eventsPersistence, IDefaultPersistence defaultPersistence, IMapper mapper)
        {
            _eventPersistence = eventsPersistence;
            _persistence = defaultPersistence;
            _mapper = mapper;
        }
        public async Task<bool> AddEvent(EventDto model)
        {
            try
            {
                var rs = _mapper.Map<Event>(model);
                rs.UserId = model.UserId;
                _persistence.Add(rs);
                return await _persistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> UpdateEvent(int id, EventDto model)
        {
            try
            {
                var userId = model.UserId;
                if (userId == 0) { return false; }
                var result = await _eventPersistence.GetEventById(userId, id);
                if(result == null) return false;
                var rs = _mapper.Map<Event>(model);
                rs.Id = result.Id;
                rs.UserId = userId;
                _persistence.Update(rs);
                return await _persistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteEvent(int userId, int id)
        {
            try 
            {
                _persistence.Delete<Event>(await _eventPersistence.GetEventById(userId, id));
                return await _persistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<EventDto> GetEventByIdAsync(int userId, int id, bool includeSpeakerDetail = false)
        {
            try
            {
                var rs = _mapper.Map<EventDto>(await _eventPersistence.GetEventById(userId, id, includeSpeakerDetail));
                return rs;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PageList<EventDto>> GetAllEventsAsync(PageParameters pageParams, int userId, bool includeSpeakerDetail = false)
        {
            try
            {
                var events = await _eventPersistence.GetAllEventsAsync(pageParams, userId, includeSpeakerDetail);
                var rs = _mapper.Map<PageList<EventDto>>(events);
                events.GetToSet(rs);
                return rs;
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
