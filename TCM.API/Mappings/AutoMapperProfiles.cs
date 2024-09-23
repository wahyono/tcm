using AutoMapper;
using TCM.API.Models.Domain;
using TCM.API.Models.DTO;

namespace TCM.API.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Users, UsersDTO>().ReverseMap();
            CreateMap<AddUsersDTO, Users>().ReverseMap();
            CreateMap<UpdateUsersDTO, Users>().ReverseMap();
        }
    }
}
