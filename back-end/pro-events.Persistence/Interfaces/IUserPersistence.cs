using pro_events.Domain.Identity;
using pro_events.Persistence.IPersistence;

namespace pro_events.Persistence.Interfaces
{
    public interface IUserPersistence : IDefaultPersistence
    {
        Task<User[]> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUserNameAsync(string userName);
    }
}
