using Microsoft.AspNetCore.SignalR;

namespace SignalR
{
    public class TestChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            //used to determin device attempting to connect
            var accessToken = Context.GetHttpContext()?.Request.Query["access_token"];
            var connectionId = Context.ConnectionId;
            Clients.Client(connectionId).SendAsync("ReceiveClientKey", connectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var connectionId = Context.ConnectionId;
            var accessToken = Context.GetHttpContext()?.Request.Query["access_token"];
            //add log here that client is disconnected
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessageToClient(string connectionId, string message)
        {
            await Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
        }
    }
}