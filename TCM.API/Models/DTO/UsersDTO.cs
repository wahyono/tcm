namespace TCM.API.Models.DTO
{
    public class UsersDTO
    {
        public Guid Id { get; set; }
        public String Username { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Fullname { get; set; }
        public String? UserImage { get; set; }
        public String Role { get; set; }
        public DateTime LastLogin { get; set; }
        public Boolean isActive { get; set; }
        public DateTime createdAt { get; set; }
    }
}
