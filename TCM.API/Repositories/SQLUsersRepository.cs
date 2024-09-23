using Microsoft.EntityFrameworkCore;
using TCM.API.Data;
using TCM.API.Models.Domain;

namespace TCM.API.Repositories
{
    public class SQLUsersRepository : IUsersRepository
    {
        private readonly TCMDbContext dbContext;

        public SQLUsersRepository(TCMDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Users> CreateAsync(Users user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<Users?> DeleteAsync(Guid id)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (existingUser == null)
            {
                return null;
            }

            dbContext.Users.Remove(existingUser);
            await dbContext.SaveChangesAsync();

            return existingUser;
        }

        public async Task<List<Users>> GetAllAsync()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<Users?> GetByIdAsync(Guid id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Users?> UpdateAsync(Guid id, Users user)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (existingUser == null) {
                return null;
            }

            existingUser.Username = user.Username;
            existingUser.Fullname = user.Fullname;
            existingUser.Email = user.Email;
            existingUser.Role = user.Role;
            existingUser.UserImage = user.UserImage;

            await dbContext.SaveChangesAsync();
            return existingUser;
        }
    }
}
