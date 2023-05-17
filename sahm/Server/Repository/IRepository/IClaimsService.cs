using System.Security.Claims;

namespace sahm.Server.Repository.IRepository
{
    public interface IClaimsService
    {
        Task<List<Claim>> GetUserClaimsAsync(AppUser user);
    }

}
