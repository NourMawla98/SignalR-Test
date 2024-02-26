using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalRController : ControllerBase
    {
        private readonly IHubContext<TestChatHub> _hubContext;

        public SignalRController(IHubContext<TestChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessageToClient(string connectionId, string message = "123")
        {
            await _hubContext.Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
            return Ok();
        }
    }
}