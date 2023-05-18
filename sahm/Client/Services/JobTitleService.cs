using sahm.Shared.Model;
using sahm.Shared.Models;
using System.Net.Http.Json;

namespace sahm.Client.Services
{
    public class JobTitleService
    {
        private readonly HttpClient httpClient;

        public JobTitleService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<JobTitleDTO>?> GetAll()
        {
            return await httpClient.GetFromJsonAsync<List<JobTitleDTO>>("api/JobTitle/GetAll");
        }

        public async Task<JobTitleDTO?> GetById(int Id)
        {
            var response = await httpClient.GetAsync($"api/JobTitle/GetById/{Id}");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return null;
                }

                return await response.Content.ReadFromJsonAsync<JobTitleDTO>();
            }
            else
            {
                return null;
            }
        }


        public async Task<bool> Insert(JobTitleDTO jobTitleDTO)
        {
            var response = await httpClient.PostAsJsonAsync("api/JobTitle/PostJobTitle/", jobTitleDTO);
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

        public async Task<bool> Update(JobTitleDTO jobTitleDTO, int Id)
        {
            var response = await httpClient.PutAsJsonAsync($"api/JobTitle/PutJobTitle/{Id}", jobTitleDTO);

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
            var response = await httpClient.DeleteAsync($"api/JobTitle/DeleteJobTitle/{Id}");

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
