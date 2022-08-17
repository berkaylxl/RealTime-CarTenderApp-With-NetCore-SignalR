
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace TenderApp.Core.Utilities
{
    public class JwtHelper
    {
        public static JwtToken GenerateToken(Claim[] claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("S3CR3TKEY!?&9785425"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.UtcNow.AddDays(10);
            var token = new JwtSecurityToken(claims: claims,
                                            expires: expiry,
                                            signingCredentials: creds,
                                            notBefore: DateTime.Now);

            var tokenkey = new JwtSecurityTokenHandler().WriteToken(token);
            return new JwtToken
            {
                Token = tokenkey,
                Time = expiry
        };

        }
    }
}
