using TCM.API.Models.Domain;
using TCM.API.Models.DTO;

namespace TCM.API.Repositories
{
    public interface ILoginReporitory
    {
        Task<Users> LoginAsync(LoginDTO loginDTO);
    }
}
