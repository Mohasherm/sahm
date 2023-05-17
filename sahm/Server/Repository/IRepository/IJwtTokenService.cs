using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace sahm.Server.Repository.IRepository
{
    public interface IJwtTokenService
    {
        JwtSecurityToken GetJwtToken(List<Claim> userClaims);
    }
}
