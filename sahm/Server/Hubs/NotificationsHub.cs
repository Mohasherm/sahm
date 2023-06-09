using Microsoft.AspNetCore.SignalR;

namespace sahm.Server.Hubs
{
    public class NotificationsHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
        public async Task SendMessage()
        {
            await Clients.All.SendAsync("ReceiveMessage");
        }
        
    }
}
