using sahm.Shared.Model;

namespace sahm.Client.Services
{
    public interface ITokenService
    {
        Task<TokenDTO> GetToken();
        Task RemoveToken();
        Task SetToken(TokenDTO tokenDTO);
    }
}
