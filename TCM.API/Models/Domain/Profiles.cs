namespace TCM.API.Models.Domain
{
    public class Profiles
    {
        public Guid Id { get; set; }
        public String Address { get; set; }
        public String Mobile { get; set; }
        public String Gender { get; set; }
        public String Age { get; set; }
        public Guid UserId { get; set; }

        //Navigation Property
        public Users User { get; set; }

    }
}
