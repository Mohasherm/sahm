using sahm.Client.Services;
using sahm.Shared.Model;
using System.Net.Http.Json;

namespace sahm.Client.Authentication
{
    public class AuthenticationHttpClient
    {
        private readonly ILogger<AuthenticationHttpClient> logger;
        private readonly HttpClient http;
        private readonly ITokenService tokenService;
        private readonly CustomAuthenticationStateProvider myAuthenticationStateProvider;

        public AuthenticationHttpClient(ILogger<AuthenticationHttpClient> logger,
            HttpClient http,
            ITokenService tokenService,
            CustomAuthenticationStateProvider myAuthenticationStateProvider)
        {
            this.logger = logger;
            this.http = http;
            this.tokenService = tokenService;
            this.myAuthenticationStateProvider = myAuthenticationStateProvider;
        }

        public async Task<UserRegisterResultDTO> RegisterUser(UserRegisterDTO userRegisterDTO)
        {
            try
            {
                var response = await http.PostAsJsonAsync("api/User/register", userRegisterDTO);
                var result = await response.Content.ReadFromJsonAsync<UserRegisterResultDTO>();
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return new UserRegisterResultDTO
                {
                    Succeeded = false,
                    Errors = new List<string>()
                    {
                        "Sorry, we were unable to register you at this time. Please try again shortly."
                    }
                };
            }
        }

        public async Task<UserLoginResultDTO> LoginUser(UserLoginDTO userLoginDTO)
        {
            try
            {
                var response = await http.PostAsJsonAsync("api/User/login", userLoginDTO);
                var result = await response.Content.ReadFromJsonAsync<UserLoginResultDTO>();
                await tokenService.SetToken(result.Token);
                myAuthenticationStateProvider.StateChanged();
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return new UserLoginResultDTO
                {
                    Succeeded = false,
                    Message = "Sorry, we were unable to log you in at this time. Please try again shortly."
                };
            }
        }

        public async Task LogoutUser()
        {
            await tokenService.RemoveToken();
            myAuthenticationStateProvider.StateChanged();
        }


        public async Task<bool> ChangePassword(ChangePasswordDTO changePasswordDTO)
        {

            var response = await http.PostAsJsonAsync("api/User/ChangePassword", changePasswordDTO);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ChangePasswordDTO>();
                return true;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return false;
            }
            else
                return false;
        }
    }
}
