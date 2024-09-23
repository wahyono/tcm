using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TCM.API.Data
{
    public class TCMDbAuthContext : IdentityDbContext
    {
        public TCMDbAuthContext(DbContextOptions<TCMDbAuthContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var securityId = "c39e114a-7bc5-42ed-a81b-c148deb5b8b6";
            var danruId = "d557fd31-be09-4acd-97ea-74366b4c0429";
            var adminId = "9a1c3e7e-fddb-4a41-af37-b9b939b56e9e";
            var chiefId = "0bd1912d-e4ff-4e09-acda-d16fc1ccda9a";
            var readerId = "62199005-732e-4f05-a908-c10c70ebe15b";
            var writerId = "49e60f3f-0eef-4b55-bab8-e3cf2308bbd8";

            var roles = new List<IdentityRole>
            { 
                new IdentityRole
                {
                    Id = securityId,
                    ConcurrencyStamp = securityId,
                    Name = "Security",
                    NormalizedName = "Security".ToUpper()
                },
                new IdentityRole
                {
                    Id = danruId,
                    ConcurrencyStamp = danruId,
                    Name = "Danru",
                    NormalizedName = "Danru".ToUpper()
                },
                new IdentityRole
                {
                    Id= adminId,
                    ConcurrencyStamp = adminId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                new IdentityRole
                {
                    Id = chiefId,
                    ConcurrencyStamp = chiefId,
                    Name ="Chief",
                    NormalizedName = "Chief".ToUpper()
                },
                new  IdentityRole
                {
                    Id = readerId,
                    ConcurrencyStamp = readerId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole { 
                    Id = writerId,
                    ConcurrencyStamp = writerId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
