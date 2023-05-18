using sahm.Shared.Model;
using System.Net.Http.Json;

namespace sahm.Client.Services
{
    public class CenterService
    {
        private readonly HttpClient httpClient;

        public CenterService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<CenterDTO>?> GetAll()
        {
            return await httpClient.GetFromJsonAsync<List<CenterDTO>>("api/Center/GetAll");
        }

        public async Task<CenterDTO?> GetById(int Id)
        {
            var response = await httpClient.GetAsync($"api/Center/GetById/{Id}");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return null;
                }

                return await response.Content.ReadFromJsonAsync<CenterDTO>();
            }
            else
            {
                return null;
            }
        }


        public async Task<bool> Insert(CenterDTO centerDTO)
        {
            var response = await httpClient.PostAsJsonAsync("api/Center/PostCenter/", centerDTO);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return false;
            }
            else
                return false;
        }

        public async Task<bool> Update(CenterDTO centerDTO, int Id)
        {
            var response = await httpClient.PutAsJsonAsync($"api/Center/PutCenter/{Id}", centerDTO);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return false;
            }
            else
                return false;
        }

        public async Task<bool> Delete(int Id)
        {
            var response = await httpClient.DeleteAsync($"api/Center/DeleteCenter/{Id}");

            if (response.IsSuccessStatusCode)
            {
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
