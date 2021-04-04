using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLandLms.Model.Models;

namespace TechLandLms.Common.Hubs
{
    [HubName("chatter")]
    public class MessageHub: Hub
    {
        public Task SendMessage(ChatMessages message)
        {
            var result = Clients.All.SendAsync("ReceiveMessage", message.UserName, message);
            return result;
        }
        public Task SendMessageToCaller(string user, ChatMessages message)
        {
            return Clients.Caller.SendAsync("ReceiveMessage", user, message);
        }

        public Task SendMessageToGroup(string user, string message)
        {
            return Clients.Group("SignalR Users").SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }
    }
}
