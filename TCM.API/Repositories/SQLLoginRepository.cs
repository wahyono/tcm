using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TCM.API.Data;
using TCM.API.Models.Domain;
using TCM.API.Models.DTO;

namespace TCM.API.Repositories
{
    public class SQLLoginRepository : ILoginReporitory
    {
        private readonly TCMDbContext dbContext;

        public SQLLoginRepository(TCMDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Users> LoginAsync(LoginDTO loginDTO)
        {
            throw new NotImplementedException();
        }
    }
}
