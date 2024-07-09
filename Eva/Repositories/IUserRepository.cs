using Eva.Models;

namespace Eva.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
    }
}
