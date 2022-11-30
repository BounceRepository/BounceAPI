using Bounce.DataTransferObject.DTO.Notification;
using Bounce_Application.Persistence.Interfaces.Notification;
using Bounce_DbOps.EF;
using Microsoft.AspNetCore.SignalR;
namespace Bounce.Api.ChatHub
{

   public interface IBouncechatClient
    {
        void SendChatMessage(string message);
    }
    public class BounceChatHub : Hub
    {
        private readonly INotificationService notificationService;
        private readonly BounceDbContext _context;
        public BounceChatHub(INotificationService notificationService, BounceDbContext context)
        {
            this.notificationService = notificationService;
            _context = context;
        }

        //public  Task OnConnected()
        //{
        //    var version = Context.GetHttpContext. QueryString['version'];
        //    if (version != '1.0')
        //    {
        //        Clients.Caller.notifyWrongVersion();
        //    }
        //    return base.OnConnected();
        //}
        [HubMethodName("Send")]
        public async Task Send(ChatHubDto model)
        {
            var receiver = _context.UserProfile.FirstOrDefault(x=> x.UserId == model.RevceieverId);
            var connectionId =  Context.ConnectionId;
            var userId = Context.User;
            //var sender = _context.UserProfile.FirstOrDefault(x => x.UserId == model.RevceieverId);
            if (receiver != null)
            {

                    var chat = new RecievedMessageDto
                    {
                        RevceieverName = receiver.FirstName + " " + receiver.LastName,
                        RevceieverId =model.RevceieverId,
                        Time = DateTimeOffset.Now,
                        Message = model.Message,

                    };
                var message = new SendMessageDto
                {
                    ReceieverId = model.RevceieverId,
                    Message = model.Message,
                    Time = model.Time,
                    FilePath = String.Join('|', model.FilePaths)

                };
                var resposne = await notificationService.SendMessage(message);
                if (resposne.StatusCode == 200)
                    await Clients.User(connectionId).SendAsync("OnMessage", model);

                Console.WriteLine("receieved message from signal R");
                await Clients.User(connectionId).SendAsync("OnMessage", "Error");
            }     
                
            await Clients.User(connectionId).SendAsync("OnMessage", "this user can not recieve message at this point");
            

        }
    }
}
