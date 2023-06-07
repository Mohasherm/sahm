using sahm.Shared.Model;
using System.Net.Http.Json;

namespace sahm.Client.Services
{
    public class ComplaintService
    {
        private readonly HttpClient httpClient;

        public ComplaintService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<ComplaintDTO>?> GetAll()
        {
            return await httpClient.GetFromJsonAsync<List<ComplaintDTO>>("api/Complaint/GetAll");
        }

        public async Task<ComplaintDTO?> GetById(int Id)
        {
            var response = await httpClient.GetAsync($"api/Complaint/GetById/{Id}");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return null;
                }

                return await response.Content.ReadFromJsonAsync<ComplaintDTO>();
            }
            else
            {
                return null;
            }
        }


        public async Task<bool> Insert(ComplaintDTO complaintDTO)
        {
            var response = await httpClient.PostAsJsonAsync("api/Complaint/PostComplaint/", complaintDTO);
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
