using AutoMapper;
using pro_events.Application.DTO.Events;
using pro_events.Application.IServices;
using pro_events.Domain;
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
        private readonly IProEventsPersistence _persistence;
        private readonly IMapper _mapper;

        public EventService(IEventsPersistence eventsPersistence, IProEventsPersistence proEventsPersistence, IMapper mapper)
        {
            _eventPersistence = eventsPersistence;
            _persistence = proEventsPersistence;
            _mapper = mapper;
        }
        public async Task<bool> AddEvent(EventDto model)
        {
            try
            {
                var rs = _mapper.Map<Event>(model);
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
                var result = await _eventPersistence.GetById(id);
                if(result == null) return false;
                var rs = _mapper.Map<Event>(model);
                rs.Id = result.Id;
                _persistence.Update(rs);
                return await _persistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteEvent(int id)
        {
            try 
            {
                _persistence.Delete<Event>(await _eventPersistence.GetById(id));
                return await _persistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<EventDto> GetEventById(int id, bool includeSpeakerDetail = false)
        {
            try
            {
                var rs = _mapper.Map<EventDto>(await _eventPersistence.GetById(id, includeSpeakerDetail));
                return rs;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<EventDto[]> GetEvents(bool includeSpeakerDetail = false)
        {
            try
            {
                var rs = _mapper.Map<EventDto[]>(await _eventPersistence.GetAllEventsAsync(includeSpeakerDetail));
                return rs;
            }
            catch(Exception ex) 
            { 
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventDto[]> GetEventsBySubject(string s, bool includeSpeakerDetail = false)
        {
            try
            {
                var rs = _mapper.Map<EventDto[]>(await _eventPersistence.GetAllEventsBySubjectAsync(s, includeSpeakerDetail));
                return rs;
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
