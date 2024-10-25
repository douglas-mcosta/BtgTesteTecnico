using BTG.Identidade.API.Data;
using BTG.Identidade.API.Models;
using BTG.WebAPI.Core.Identidate;
using BTG.WebAPI.Core.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BTG.Identidade.API.Services
{
    public class AuthenticationService
    {

        public readonly SignInManager<IdentityUser> SignInManager;
        public readonly UserManager<IdentityUser> UserManager;
        private readonly TokenSettings _appTokenSettings;
        private readonly IAspNetUser _aspNetUser;
        private readonly ApplicationDbContext _context;

        public AuthenticationService(SignInManager<IdentityUser> signInManager,
                              UserManager<IdentityUser> userManager,
                              IOptions<TokenSettings> appTokenSettings,
                              IAspNetUser aspNetUser,
                              ApplicationDbContext context)
        {
            SignInManager = signInManager;
            this.UserManager = userManager;
            _appTokenSettings = appTokenSettings.Value;
            _aspNetUser = aspNetUser;
            _context = context;
        }

        public async Task<LoginResponseViewModel> GerarJwt(string email)
        {
            var user = await UserManager.FindByEmailAsync(email);
            var claims = await UserManager.GetClaimsAsync(user);

            var identityClaims = await GetUserClaims(claims, user);
            var encodedToken = EncodeToken(identityClaims);

            return GetResponseToken(encodedToken, user, claims);
        }

        private async Task<ClaimsIdentity> GetUserClaims(ICollection<Claim> claims, IdentityUser user)
        {
            var userRoles = await UserManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
            claims.Add(new Claim(JwtRegisteredClaimNames.Aud, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            return identityClaims;
        }
        private string EncodeToken(ClaimsIdentity claims)
        {
            var currentIssuer = $"{_aspNetUser.GetHttpContext().Request.Scheme}://{_aspNetUser.GetHttpContext().Request.Host}";
            //Para manipular o token
            var tokenHandle = new Microsoft.IdentityModel.JsonWebTokens.JsonWebTokenHandler();
            //Key
            var key = Encoding.ASCII.GetBytes(_appTokenSettings.Secret); ;
            //Gerar o token
            new Microsoft.IdentityModel.JsonWebTokens.JsonWebTokenHandler();
            var token = tokenHandle.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appTokenSettings.Emissor,
                Audience = _appTokenSettings.ValidoEm,
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(_appTokenSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });
            return token;
        }
        private LoginResponseViewModel GetResponseToken(string encodedToken, IdentityUser user, IEnumerable<Claim> claims)
        {

            var filtro = new List<string>(){
                new string("sub"),
                new string("jti"),
                new string("nbf"),
                new string("iat"),
                new string("iss"),
                new string("aud"),
                new string("email"),
            };
            return new LoginResponseViewModel
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(1).TotalSeconds,
                UserToken = new UsuarioTokenViewModel
                {
                    Email = user.Email,
                    Id = user.Id,
                    Claims = claims.Select(x => new UsuarioClaimViewModel { Type = x.Type, Value = x.Value }).Where(x => !filtro.Contains(x.Type))
                }
            };
        }
        private static long ToUnixEpochDate(DateTime date)
       => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }

}
