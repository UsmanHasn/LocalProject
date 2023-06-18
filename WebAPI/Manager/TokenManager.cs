using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPI.Manager
{
    public class TokenManager
    {
        public static string GenerateToken(string auth_key, string jwt_signing_key)
        {
            

            byte[] key = Encoding.UTF8.GetBytes(jwt_signing_key);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, auth_key) }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }

        public static ClaimsPrincipal GetPrincipal(string token, string jwt_signing_key)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                if (jwtToken == null)
                {
                    return null;
                }

                byte[] key = Convert.FromBase64String(jwt_signing_key);
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    TryAllIssuerSigningKeys = true
                };
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, parameters, out SecurityToken securityToken);
                return principal;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool ValidateToken(string jwtToken,string jwt_signing_key)
        {
            ClaimsPrincipal principal = GetPrincipal(jwtToken, jwt_signing_key);
            if (principal == null)
            {
                return false;
            }

            ClaimsIdentity identity;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException)
            {
                return false;
            }
            Claim auth_key_claim = identity.FindFirst(ClaimTypes.Name);
            string auth_key = auth_key_claim.Value;
            return true;// (auth_key == sdjc_secret_auth_key);
        }

    }
}
