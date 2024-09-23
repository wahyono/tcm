using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TCM.API.Models.Domain;

namespace TCM.API.Data
{
    public class TCMDbContext: DbContext
    {
        public TCMDbContext(DbContextOptions<TCMDbContext> dbContextoptions): base(dbContextoptions)
        {
                
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Profiles> Profile { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Admin user "admin" password "temp321"
            var user = new List<Users>()
            { 
                new Users() {
                    Id = Guid.Parse("33e492b2-c141-4fe4-a512-a8bc30e4cbc9"),
                    Username = "admin",
                    Email = "wsumardji@yahoo.com",
                    Password = "sangkanayu",
                    Fullname = "Super User",
                    Role = "admin",
                    LastLogin = DateTime.Now,
                    isActive = true,
                    createdAt = DateTime.Now
                }
            };

            modelBuilder.Entity<Users>().HasData(user);

            //Seed Profile for the user seed above
            var profileuser = new List<Profiles>()
            {
                new Profiles()
                {
                    Id = Guid.NewGuid(),
                    Address = "Jl. Mampang prapatan XIV No. 30",
                    Mobile = "08176349999",
                    Gender = "Male",
                    Age  =  "47",
                    UserId = Guid.Parse("33e492b2-c141-4fe4-a512-a8bc30e4cbc9")
                }
            };

            modelBuilder.Entity<Profiles>().HasData(profileuser);
        }
    }
}
