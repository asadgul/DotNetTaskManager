using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TaskManager.DbModels;

namespace TaskManager.IdentityModels
{
    public class ApplicationUserstore:UserStore<ApplicationUser>
    {
        public ApplicationUserstore(Databaseconfig databaseconfig):base(databaseconfig) { }
        
    }
}
