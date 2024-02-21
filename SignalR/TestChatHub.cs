using Microsoft.AspNetCore.SignalR;

namespace SignalR
{
    public class TestChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}