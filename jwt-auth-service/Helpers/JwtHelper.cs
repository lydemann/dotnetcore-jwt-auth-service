using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.IdentityModel.Tokens;

namespace jwt_auth_service.Helpers
{
    public class JwtHelper
    {
        private readonly ConfigurationHelper _configurationHelper;

        public JwtHelper(ConfigurationHelper configurationHelper)
        {
            _configurationHelper = configurationHelper;
        }

        public object GenerateJwtToken(WindowsIdentity user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Name)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configurationHelper.JwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configurationHelper.JwtExpireDays));

            var token = new JwtSecurityToken(
                _configurationHelper.JwtIssuer,
                _configurationHelper.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool IsJwtValid(object token)
        {
            var isValid = VerifyJwt(token);
            return isValid;
        }

        private bool VerifyJwt(object token)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
