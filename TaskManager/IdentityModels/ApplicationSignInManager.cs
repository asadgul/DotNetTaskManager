using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace TaskManager.IdentityModels
{
    public class ApplicationSignInManager : SignInManager<ApplicationUser>
    {
        //public ApplicationSignInManager(ApplicationUserManager applicationUserManager, IHttpContextAccessor httpContextAccessor, IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory, IOptions<IdentityOptions> options, ILogger<ApplicationSignInManager> logger, IAuthenticationSchemeProvider schemes) : base(applicationUserManager, httpContextAccessor, userClaimsPrincipalFactory, options, logger, schemes)
        //{

        //}
        public ApplicationSignInManager(ApplicationUserManager userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<ApplicationUser>> logger, IAuthenticationSchemeProvider schemes, IUserConfirmation<ApplicationUser> confirmation) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
        {
        }
    }
}
