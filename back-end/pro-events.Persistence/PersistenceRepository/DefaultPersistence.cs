using Microsoft.EntityFrameworkCore;
using pro_events.API.Persistence;
using pro_events.Persistence.IPersistence;

namespace pro_events.Persistence.Repository
{
    public class DefaultPersistence : IDefaultPersistence
    {
        protected readonly ProEventsContext _context;
        public DefaultPersistence(ProEventsContext context)
        {
            _context = context;
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
            _context.RemoveRange(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
