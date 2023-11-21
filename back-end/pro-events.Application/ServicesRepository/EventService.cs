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

        public EventService(IEventsPersistence eventsPersistence, IProEventsPersistence proEventsPersistence)
        {
            _eventPersistence = eventsPersistence;
            _persistence = proEventsPersistence;
        }
        public async Task<bool> AddEvent(Event model)
        {
            try
            {
                _persistence.Add(model);
                return await _persistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> UpdateEvent(int id, Event model)
        {
            try
            {
                var result = await _eventPersistence.GetById(id);
                if(result == null) return false;
                model.Id = result.Id;
                _persistence.Update(model);
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
        public async Task<Event> GetEventById(int id, bool includeSpeakerDetail = false)
        {
            try
            {
                return await _eventPersistence.GetById(id, includeSpeakerDetail);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Event[]> GetEvents(bool includeSpeakerDetail = false)
        {
            try
            {
                return await _eventPersistence.GetAllEventsAsync(includeSpeakerDetail);
            }
            catch(Exception ex) 
            { 
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event[]> GetEventsBySubject(string s, bool includeSpeakerDetail = false)
        {
            try
            {
                return await _eventPersistence.GetAllEventsBySubjectAsync(s, includeSpeakerDetail);
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
