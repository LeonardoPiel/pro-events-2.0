using Microsoft.EntityFrameworkCore;
using pro_events.API.Persistence;
using pro_events.Domain.Identity;
using pro_events.Persistence.Interfaces;
using pro_events.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace pro_events.Persistence.PersistenceRepository
{
    public class UserPersistence : DefaultPersistence, IUserPersistence
    {
        private readonly ProEventsContext _context;

        public UserPersistence(ProEventsContext context) : base(context)
        {
            this._context = context;
        }
        public async Task<User> GetUserByIdAsync(int id) => await _context.Users.SingleOrDefaultAsync(user => user.Id == id);
        public async Task<User> GetUserByUserNameAsync(string userName) => await _context.Users.SingleOrDefaultAsync(user => user.UserName == userName);
        public async Task<User[]> GetUsersAsync() => await _context.Users.ToArrayAsync();
    }
}
