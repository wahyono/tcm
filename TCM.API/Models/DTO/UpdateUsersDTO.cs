namespace TCM.API.Models.DTO
{
    public class UpdateUsersDTO
    {
        public String Username { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Fullname { get; set; }
        public String? UserImage { get; set; }
        public String Role { get; set; }
    }
}
