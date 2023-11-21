using pro_events.API.Persistence;
using pro_events.Persistence.IPersistence;

namespace pro_events.Persistence.Repository
{
    public class ProEventsPersistence : IProEventsPersistence
    {
        protected readonly ProEventsContext _context;
        public ProEventsPersistence(ProEventsContext context)
        {
            _context = context;
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
