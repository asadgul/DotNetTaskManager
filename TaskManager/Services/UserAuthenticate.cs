using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManager.IdentityModels;
using TaskManager.JwtConfig;
using TaskManager.ViewModels;

namespace TaskManager.Services
{
    public class UserAuthenticate : IUserAuthenticate
    {
        private readonly ApplicationSignInManager _applicationsigninmanager;
        private readonly ApplicationUserManager _applicationsusermanager;
        private readonly JwtModel _jwtmodel;

        public UserAuthenticate(ApplicationSignInManager _applicationsigninmanager, ApplicationUserManager _applicationsusermanager, IOptions<JwtModel> options)
        {
            this._applicationsigninmanager = _applicationsigninmanager;
            this._applicationsusermanager = _applicationsusermanager;
            _jwtmodel = options.Value;
        }
        public async Task<ApplicationUser> AuthenticateUser(LoginViewModel loginViewModel)
        {
            var user = await _applicationsigninmanager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, false);
            if (user.Succeeded)
            {
                var applicationUser = await _applicationsusermanager.FindByNameAsync(loginViewModel.UserName);
                applicationUser.PasswordHash = null;
                var token = new JwtSecurityTokenHandler();
                var tokenkey = Encoding.ASCII.GetBytes("This is my test key");
                var tokendecriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, loginViewModel.UserName)
                }),
                    Expires = DateTime.UtcNow.AddMinutes(20),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)
                };
                var createtoken = token.CreateToken(tokendecriptor);
                applicationUser.Token = token.WriteToken(createtoken);
                return applicationUser;
            }
            return null;
        }
    }
}
