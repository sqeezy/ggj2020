using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace MessageRelayServer
{
    public class SignalHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}