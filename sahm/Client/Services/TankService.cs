using sahm.Shared.Model;
using System.Net.Http.Json;

namespace sahm.Client.Services
{
    public class TankService
    {
        private readonly HttpClient httpClient;

        public TankService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<TankDTO>?> GetById(int Center_Id)
        {
           return await httpClient.GetFromJsonAsync<List<TankDTO>?>($"api/Tank/GetTankForCenter/{Center_Id}");
        }

        public async Task<bool> InsertOperation(TankOperationDTO tankOperationDTO)
        {
            var response = await httpClient.PostAsJsonAsync("api/Tank/PostTankOperation/", tankOperationDTO);
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

        public async Task<bool> UpdateTankQTY(TankQTYUpdateDTO tankQTYUpdateDTO, int Id)
        {
            var response = await httpClient.PutAsJsonAsync($"api/Tank/PutTankQTY/{Id}", tankQTYUpdateDTO);

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
