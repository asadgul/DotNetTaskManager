using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TaskManager.DbModels;

namespace TaskManager.IdentityModels
{
    public class ApplicationRoleStore : RoleStore<ApplicationRole, Databaseconfig>
    {
        public ApplicationRoleStore(Databaseconfig context, IdentityErrorDescriber describer) : base(context, describer)
        {
        }
    }
}
