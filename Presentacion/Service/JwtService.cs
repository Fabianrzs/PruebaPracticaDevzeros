using Entity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Presentacion.Config;
using Presentacion.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Service
{
    public class JwtService
    {
        private readonly AppSetting _appSettings;

        public JwtService(IOptions<AppSetting> appSettings) => _appSettings = appSettings.Value;

        public LoginViewModel GenerateToken(User user)
        {
            if (user == null)return null;

            var userResponse = new LoginViewModel() { UserName = user.UserName, Email = user.Email, Rol = user.Rol};

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    new Claim(ClaimTypes.Role, user.Rol),
                }),
                Expires = DateTime.UtcNow.AddMonths(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            userResponse.Token = tokenHandler.WriteToken(token);

            return userResponse;
        }
    }
}
