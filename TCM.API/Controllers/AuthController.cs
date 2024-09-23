using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TCM.API.Models.DTO;
using TCM.API.Repositories;

namespace TCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        //POST: /api/Auth/Register
        [HttpPost]
        [Route("Register")]

        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDTO.Username,
                Email = registerRequestDTO.Username
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDTO.Password);

            if (identityResult.Succeeded)
            {
                if (registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDTO.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("User was successfully regitered. Please login.");
                    }
                }
            }

            return BadRequest("Something went wrong.");
        }

        //POST: /api/Auth/Login
        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDTO.Username);

            if (user != null)
            {
                var checkpasswordresult = await userManager.CheckPasswordAsync(user, loginRequestDTO.Password);

                if (checkpasswordresult)
                {
                    //Get Roles
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                        //Create Token
                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDTO { 
                            Username = user.UserName,
                            Email = user.Email,
                            Token = jwtToken
                        };

                        return Ok(response);
                    }
                }
            }

            return BadRequest("Wrong username or password.");
        }
    }
}
