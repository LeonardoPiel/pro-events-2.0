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
    public class SpeakerService : ISpeakerService
    {
        private readonly IDefaultPersistence _persistence;
        private readonly ISpeakerPersistence _speakerPersistence;
        public SpeakerService(IDefaultPersistence persistence, ISpeakerPersistence speakerPersistence)
        {
            _speakerPersistence = speakerPersistence;
            _persistence = persistence;
        }
        public async Task<bool> AddSpeaker(Speaker model)
        {
            try 
            {
                _persistence.Add(model);
                return await _persistence.SaveChangesAsync();
            }
            catch (Exception ex){ throw new Exception(ex.Message); }
        }

        public async Task<bool> DeleteSpeaker(int id)
        {
            try
            {
                _persistence.Delete(_speakerPersistence.GetById(id));
                return await _persistence.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> UpdateSpeaker(int id, Speaker model)
        {
            try 
            {
                var result = await _speakerPersistence.GetById(id);
                if (result == null) { return false; }
                model.Id = result.Id;
                _persistence.Update(model);
                return await _persistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Speaker> GetSpeakerById(int id, bool includeDetail)
        {
            try
            {
                return _speakerPersistence.GetById(id, true);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Speaker[]> GetSpeakersByName(string name, bool includeDetail)
        {
            try
            {
                return await _speakerPersistence.GetAllSpeakersByNameAsync(name, includeDetail);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Speaker[]> GetSpeakers(bool includeDetail)
        {
            try
            {
                return await _speakerPersistence.GetAllSpeakersAsync(includeDetail);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
