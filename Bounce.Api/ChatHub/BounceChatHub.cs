using Bounce.DataTransferObject.DTO.Notification;
using Microsoft.AspNetCore.SignalR;
namespace Bounce.Api.ChatHub
{

   public interface IBouncechatClient
    {
        void SendChatMessage(string message);
    }
    public class BounceChatHub : Hub
    {

        //[HubMethodName("ReceievedMessage")]
        public async Task SendPrivateMessage(ChatHubDto model)
        {
          
            var chat = new RecievedMessageDto
            {
                RevceieverName = 2
            };

            Console.WriteLine("receieved message from signal R");
            await Clients.All.SendAsync("ReceievedMessage", model);
        }
    }
}
