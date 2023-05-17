using Blazored.SessionStorage;
using sahm.Shared.Model;

namespace sahm.Client.Services
{
    public class TokenService : ITokenService
    {
        private readonly ISessionStorageService sessionStorageService;

        public TokenService(ISessionStorageService sessionStorageService)
        {
            this.sessionStorageService = sessionStorageService;
        }

        public async Task SetToken(TokenDTO tokenDTO)
        {
            await sessionStorageService.SetItemAsync("token", tokenDTO);
        }

        public async Task<TokenDTO> GetToken()
        {
            return await sessionStorageService.GetItemAsync<TokenDTO>("token");
        }

        public async Task RemoveToken()
        {
            await sessionStorageService.RemoveItemAsync("token");
        }
    }
}
