using sahm.Shared.Model;
using System.Net.Http.Json;

namespace sahm.Client.Services
{
    public class CenterAssetService
    {
        private readonly HttpClient httpClient;

        public CenterAssetService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<CenterAssetDTO>?> GetAll()
        {
            return await httpClient.GetFromJsonAsync<List<CenterAssetDTO>>("api/CenterAsset/GetAll");
        }

        public async Task<CenterAssetDTO?> GetById(int Id)
        {
            var response = await httpClient.GetAsync($"api/CenterAsset/GetById/{Id}");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return null;
                }

                return await response.Content.ReadFromJsonAsync<CenterAssetDTO>();
            }
            else
            {
                return null;
            }
        }


        public async Task<bool> Insert(CenterAssetDTO centerAssetDTO)
        {
            var response = await httpClient.PostAsJsonAsync("api/CenterAsset/PostCenterAsset/", centerAssetDTO);
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

        public async Task<bool> Update(CenterAssetDTO centerAssetDTO, int Id)
        {
            var response = await httpClient.PutAsJsonAsync($"api/CenterAsset/PutCenterAsset/{Id}", centerAssetDTO);

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
            var response = await httpClient.DeleteAsync($"api/CenterAsset/DeleteCenterAsset/{Id}");

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
