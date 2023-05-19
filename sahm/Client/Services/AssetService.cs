using sahm.Shared.Model;
using System.Net.Http.Json;

namespace sahm.Client.Services
{
    public class AssetService
    {
        private readonly HttpClient httpClient;

        public AssetService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<AssetDTO>?> GetAll()
        {
            return await httpClient.GetFromJsonAsync<List<AssetDTO>>("api/Asset/GetAll");
        }

        public async Task<AssetDTO?> GetById(int Id)
        {
            var response = await httpClient.GetAsync($"api/Asset/GetById/{Id}");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return null;
                }

                return await response.Content.ReadFromJsonAsync<AssetDTO>();
            }
            else
            {
                return null;
            }
        }


        public async Task<bool> Insert(AssetDTO assetDTO)
        {
            var response = await httpClient.PostAsJsonAsync("api/Asset/PostAsset/", assetDTO);
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

        public async Task<bool> Update(AssetDTO assetDTO, int Id)
        {
            var response = await httpClient.PutAsJsonAsync($"api/Asset/PutAsset/{Id}", assetDTO);

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
            var response = await httpClient.DeleteAsync($"api/Asset/DeleteAsset/{Id}");

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
