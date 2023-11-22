using AutoMapper;
using pro_events.Application.DTO.TicketLots;
using pro_events.Application.IServices;
using pro_events.Domain;
using pro_events.Persistence.IPersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace pro_events.Application.ServicesRepository
{
    public class TicketLotService : ITicketLotService
    {
        private readonly ITicketLotPersistence _ticketLotPersistence;
        private readonly IProEventsPersistence _persistence;
        private readonly IMapper _mapper;
        public TicketLotService(ITicketLotPersistence ticketLotPersistence, IProEventsPersistence persistence, IMapper mapper)
        {
            _ticketLotPersistence = ticketLotPersistence;
            _persistence = persistence;
            _mapper = mapper;
        }

        public async Task AddTicketLot(TicketLotDto model)
        {
            try
            {
                if (model == null) throw new ArgumentNullException("ticketLot json was not sent.");
                if (model.EventId == 0) throw new ArgumentException("invalid eventId");
                var rs = _mapper.Map<TicketLot>(model);
                _persistence.Add(rs);
                await _persistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> SaveTicketLot(TicketLotDto[] models)
        {
            try
            {
                foreach(var model in models)
                {
                    if (model.EventId == 0)
                    {
                        return false;
                        throw new ArgumentNullException("invalid EventId");
                    }
                    var ticketLots = await _ticketLotPersistence.GetTicketLotByEventIdAsync(model.EventId);
                    if (ticketLots == null)
                    {
                        return false;
                        throw new ArgumentException($"Ticket lot by this eventId: {model.EventId} was not found");
                    }
                    if (model.Id == 0)
                    {
                        await AddTicketLot(model);
                    }
                    else
                    {
                        var tl = ticketLots.FirstOrDefault(t => t.Id == model.Id);
                        _mapper.Map(model, tl);
                        _persistence.Update<TicketLot>(tl);
                    }
                }
                return await _persistence.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteTicketLot(int id, int eventId)
        {
            try
            {
                var tl = await _ticketLotPersistence.GetTicketLotByIdsAsync(id, eventId);
                if (tl == null)
                {
                    return false;
                }
                _persistence.Delete<TicketLot>(tl);
                
                return await _persistence.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }
        }

        public async Task<TicketLotDto> GetTicketLotByIds(int ticketLotId, int eventId)
        {
            try
            {
                var tl = await _ticketLotPersistence.GetTicketLotByIdsAsync(ticketLotId, eventId);
                if (tl == null) throw new ArgumentException("Given event or ticketlot was not found");

                var rs = _mapper.Map<TicketLotDto>(tl);
                return rs;
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TicketLotDto[]> GetTicketLotByEventId(int eventId)
        {
            try
            {
                var tl = await _ticketLotPersistence.GetTicketLotByEventIdAsync(eventId);
                if (tl == null) throw new ArgumentException("Given event was not found");
                var rs = _mapper.Map<TicketLotDto[]>(tl);
                return rs;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
