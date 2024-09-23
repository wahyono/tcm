using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCM.API.Data;
using TCM.API.Models.Domain;
using TCM.API.Models.DTO;
using TCM.API.Repositories;

namespace TCM.API.Controllers
{
    // https://host:port/api/users
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Writer, Reader")]
    public class UserController : ControllerBase
    {
        private readonly TCMDbContext dbContext;
        private readonly IUsersRepository usersRepository;
        private readonly IMapper mapper;

        public UserController(TCMDbContext dbContext, IUsersRepository usersRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.usersRepository = usersRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get all data from database - Domain Model
            //var users = await dbContext.users.ToListAsync();
            var users = await usersRepository.GetAllAsync();

            // Map Domain Model to DTOs
            //var usersdto = new List<UsersDTO>();
            //foreach (var user in users)
            //{
            //    usersdto.Add(new UsersDTO()
            //    {
            //        Id = user.Id,
            //        Username = user.Username,
            //        Email = user.Email,
            //        Fullname = user.Fullname,
            //        UserImage = user.UserImage,
            //        Role = user.Role,
            //        LastLogin = user.LastLogin
            //    });
            //}

            var usersdto = mapper.Map<List<UsersDTO>>(users);

            //return data to client
            return Ok(usersdto);
        }

        //GET: user by Id
        //GET: https://localhost:port/api/users/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var user = await dbContext.users.SingleOrDefaultAsync(x => x.Id == id);
            //var user = await dbContext.users.FindAsync(id);
            var user = await usersRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            //Map to DTO
            //var userdto = mapper.Map<UsersDTO>(user);
            //var userdto = new UsersDTO
            //{
            //    Id = user.Id,
            //    Username = user.Username,
            //    Fullname = user.Fullname,
            //    Email = user.Email,
            //    LastLogin = user.LastLogin,
            //    UserImage = user.UserImage
            //};

            //return Ok(userdto);
            return Ok(mapper.Map<UsersDTO>(user));
        }

        //POST: Create a new user
        //POST: https://localhost:port/api/users

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddUsersDTO addUserDTO)
        {
            //var userDomainModel = new Users
            //{
            //    Username = addUserDTO.Username,
            //    Email = addUserDTO.Email,
            //    Fullname = addUserDTO.Fullname,
            //    Role = addUserDTO.Role,
            //    LastLogin = addUserDTO.LastLogin,
            //    UserImage = addUserDTO.UserImage
            //};
            var userDomainModel = mapper.Map<Users>(addUserDTO);

            userDomainModel = await usersRepository.CreateAsync(userDomainModel);
            //await dbContext.users.AddAsync(userDomainModel); 
            //await dbContext.SaveChangesAsync();


            //var createdDTO = new UsersDTO
            //{
            //    Id = userDomainModel.Id,
            //    Username = userDomainModel.Username,
            //    Email = userDomainModel.Email,
            //    Fullname = userDomainModel.Fullname,
            //    Role = userDomainModel.Role,
            //    LastLogin = userDomainModel.LastLogin,
            //    UserImage = userDomainModel.UserImage
            //};

            var createdDTO = mapper.Map<UsersDTO>(userDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = createdDTO.Id }, createdDTO);
        }

        //PUT: update user detail
        //PUT: https://localhost:port/api/users/{id} 
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUsersDTO updateUserDTO)
        {
            //Untuk update ke database, harus dalam bentuk domain model, jadi updateUserDTO kita rubah jadi domain model
            //var userDomainModel = new Users
            //{
            //    Username = updateUserDTO.Username,
            //    Email = updateUserDTO.Email,
            //    Fullname = updateUserDTO.Fullname,
            //    Role = updateUserDTO.Role,
            //    LastLogin = updateUserDTO.LastLogin,
            //    UserImage = updateUserDTO.UserImage
            //};
            var userDomainModel = mapper.Map<Users>(updateUserDTO);

            //Check if user is exist based on id
            //var userDomainModel = await dbContext.users.FirstOrDefaultAsync(x => x.Id == id);
            userDomainModel = await usersRepository.UpdateAsync(id, userDomainModel);

            if (userDomainModel == null) {
                return NotFound();
            }

            ////map DTO to DOmain Model
            //userDomainModel.Username = updateUserDTO.Username;
            //userDomainModel.Email = updateUserDTO.Email;
            //userDomainModel.Fullname = updateUserDTO.Fullname;
            //userDomainModel.Role = updateUserDTO.Role;
            //userDomainModel.UserImage = updateUserDTO.UserImage;
            //userDomainModel.LastLogin = updateUserDTO.LastLogin;

            //await dbContext.SaveChangesAsync();

            //Convert Model to DTO
            //var userDTO = new UsersDTO
            //{
            //    Id = userDomainModel.Id,
            //    Username = userDomainModel.Username,
            //    Email = userDomainModel.Email,
            //    Fullname = userDomainModel.Fullname,
            //    Role = userDomainModel.Role,
            //    LastLogin = userDomainModel.LastLogin,
            //    UserImage = userDomainModel.UserImage
            //};

            //Return to client
            return Ok(mapper.Map<UsersDTO>(userDomainModel));
        }

        //DELETE: Delete user
        //DELETE: https://localhost:port/api/users/{id} 
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            //Check if user is exist
            //var userDomainModel = await dbContext.users.FirstOrDefaultAsync(x => x.Id == id);
            var userDomainModel = await usersRepository.DeleteAsync(id);

            if (userDomainModel == null)
            {
                return NotFound();
            }

            //dbContext.users.Remove(userDomainModel);
            //await dbContext.SaveChangesAsync();

            //Map deleted user to DTO
            //var userDTO = new UsersDTO
            //{
            //    Id = userDomainModel.Id,
            //    Username = userDomainModel.Username,
            //    Email = userDomainModel.Email,
            //    Fullname = userDomainModel.Fullname,
            //    Role = userDomainModel.Role,
            //    LastLogin = userDomainModel.LastLogin,
            //    UserImage = userDomainModel.UserImage
            //};

            return Ok(mapper.Map<UsersDTO>(userDomainModel));
        }
    }
}
