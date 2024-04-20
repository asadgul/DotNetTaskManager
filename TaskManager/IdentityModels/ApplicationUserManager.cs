using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace TaskManager.IdentityModels
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
       
        public ApplicationUserManager(ApplicationUserstore applicationUserStore, IOptions<IdentityOptions> options, IPasswordHasher<ApplicationUser> passwordHasher, IEnumerable<IUserValidator<ApplicationUser>> userValidators, IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, ILookupNormalizer lookupNormalizer, IdentityErrorDescriber identityErrorDescriber, IServiceProvider services, ILogger<ApplicationUserManager> logger) : base(applicationUserStore, options, passwordHasher, userValidators, passwordValidators, lookupNormalizer, identityErrorDescriber, services, logger)
        {

        }
    }
}
