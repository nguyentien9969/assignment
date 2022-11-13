using Common.Constant;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestWebAPI.DTOS.Person;

namespace TestWebAPI.Helpers
{
    public class JWTHelper
    {
        public static string CreateJwtToken(PersonModel person)
        {

            var claims = new Claim[]
                 {
                    new Claim(ClaimTypes.Role,person.Role.ToString()),
                    new Claim("Id", person.Id.ToString())
                 };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConstant.Key));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expired = DateTime.UtcNow.AddDays(JwtConstant.ExpiredTime);

            var token = new JwtSecurityToken(JwtConstant.Issuer, JwtConstant.Audience,
                claims, expires: expired, signingCredentials: signIn);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;

        }
    }
}
