using sahm.Shared.Model;
using System.Net.Http.Json;

namespace sahm.Client.Services
{
    public class NotificationService
    {
        private readonly HttpClient httpClient;

        public NotificationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<NotificationDTO>?> GetAll()
        {
            return await httpClient.GetFromJsonAsync<List<NotificationDTO>>("api/Notification/GetAll");
        }

        public async Task<List<NotificationDTO>?> GetById(Guid Id)
        {
            var response = await httpClient.GetAsync($"api/Notification/GetById/{Id}");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return null;
                }

                return await response.Content.ReadFromJsonAsync<List<NotificationDTO>>();
            }
            else
            {
                return null;
            }
        }


        public async Task<bool> Insert(NotificationDTO notificationDTO)
        {
            var response = await httpClient.PostAsJsonAsync("api/Notification/PostNotification/", notificationDTO);
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
            var response = await httpClient.DeleteAsync($"api/Notification/DeleteNotification/{Id}");

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
