using Microsoft.AspNetCore.Identity;

namespace TCM.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
