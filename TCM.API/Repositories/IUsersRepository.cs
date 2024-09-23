using Microsoft.EntityFrameworkCore;
using TCM.API.Models.Domain;

namespace TCM.API.Repositories
{
    public interface IUsersRepository
    {
        Task<List<Users>> GetAllAsync();
        Task<Users?> GetByIdAsync(Guid id);
        Task<Users> CreateAsync(Users user);
        Task<Users?> UpdateAsync(Guid id, Users user);
        Task<Users?> DeleteAsync(Guid id);
    }
}
