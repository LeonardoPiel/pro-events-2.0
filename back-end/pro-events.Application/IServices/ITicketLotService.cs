using pro_events.Application.DTO.Events;
using pro_events.Application.DTO.TicketLots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_events.Application.IServices
{
    public interface ITicketLotService
    {
        Task<bool> SaveTicketLot(TicketLotDto[] model);
        Task<bool> DeleteTicketLot(int id, int eventId);
        Task<TicketLotDto[]> GetTicketLotByEventId(int eventId);
        Task<TicketLotDto> GetTicketLotByIds(int ticketLotId, int eventId);
    }
}
