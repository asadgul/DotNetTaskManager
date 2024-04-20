using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection.Emit;
using TaskManager.IdentityModels;

namespace TaskManager.DbModels
{
    public class Databaseconfig:IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
        public Databaseconfig(DbContextOptions<Databaseconfig> dbContextOptions):base(dbContextOptions) { 
        
        }        
        public DbSet<Project> projects { get; set; }
        public DbSet<IdentityRole> Roles {  get; set; }
        public DbSet<ProjectLists> ProjectLists { get; set; }   
        public DbSet<ClientLocation> ClientLocations { get; set; }  
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var keysProperties = builder.Model.GetEntityTypes().Select(x => x.FindPrimaryKey()).SelectMany(x => x.Properties);
            foreach (var property in keysProperties)
            {
                property.ValueGenerated = ValueGenerated.OnAdd;
            }
            builder.Entity<ClientLocation>().HasData(
         new ClientLocation() { ClientLocationID = 1, ClientLocationName = "Boston" },
         new ClientLocation() { ClientLocationID = 2, ClientLocationName = "New Delhi" },
         new ClientLocation() { ClientLocationID = 3, ClientLocationName = "New Jersy" },
         new ClientLocation() { ClientLocationID = 4, ClientLocationName = "New York" },
         new ClientLocation() { ClientLocationID = 5, ClientLocationName = "London" },
         new ClientLocation() { ClientLocationID = 6, ClientLocationName = "Tokyo" }
            );

            builder.Entity<ProjectLists>().HasData(
                new ProjectLists() { ProjectID = 1, ProjectName = "Hospital Management System", DateOfStart = Convert.ToDateTime("2017-8-1"), Active = true, ClientLocationID = 2, Status = "In Force", TeamSize = 14 },
                new ProjectLists() { ProjectID = 2, ProjectName = "Reporting Tool", DateOfStart = Convert.ToDateTime("2018-3-16"), Active = true, ClientLocationID = 1, Status = "Support", TeamSize = 81 }
            );
        }
    }
}
