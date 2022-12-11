using AutoMapper;
using AutoMapper.Internal;
using Bounce.DataTransferObject.DTO.Notification;
using Bounce.DataTransferObject.Helpers.BaseResponse;
using Bounce_Application.Persistence.Interfaces.Helper;
using Bounce_Application.Persistence.Interfaces.Notification;
using Bounce_Application.Utilies;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bounce.Services.Implementation.Services.Notification
{
    public class NotificationService: BaseServices, INotificationService
    {
        private readonly IMapper _mapper;
        private readonly SessionManager _sessionManager;
        private readonly UserManager<ApplicationUser>  _userManager;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IEmalService _EmailService;
        private readonly FileManager _fileManager;

        public string rootPath { get; set; }

        public NotificationService(BounceDbContext context, IMapper mapper, SessionManager sessionManager, UserManager<ApplicationUser> userManager, IHostingEnvironment hostingEnvironment, IEmalService emailService, FileManager fileManager) : base(context)
        {
            _mapper = mapper;
            _sessionManager = sessionManager;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
            rootPath = _hostingEnvironment.ContentRootPath;
            _EmailService = emailService;
            rootPath = _hostingEnvironment.ContentRootPath;
            _fileManager = fileManager;
        }
        public async Task<Response>  PushNotification(PushNotificationDto model)
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                var defaultApp = FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "key.json")),
                });

                var message = new Message()
                {
                    
                    Data = new Dictionary<string, string>()
                    {
                        ["User"] = user.Email,
                        ["UserName"] = user.UserName,

                    },
                    Notification = new FirebaseAdmin.Messaging.Notification
                    {
                        Title = model.Title,
                        Body = model.Message,
                        
                    },
                    Token = user.NotificationToken,
                };
                var messaging = FirebaseMessaging.DefaultInstance;
                var result = await messaging.SendAsync(message);
                defaultApp.Delete();
                return SuccessResponse();

            }
            catch(Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
     
        public async Task<Response> ReadNotification()
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                var notifications = _context.Notification.Where(x => x.UserId == user.Id && x.IsNewNotication).ToList();
               if(notifications != null || notifications.Any())
                {
                    notifications.ForEach(x => { x.IsNewNotication = true; });
                    _context.UpdateRange(notifications);
                    if (!await SaveAsync())
                        return FailedSaveResponse(notifications);
                }
                return SuccessResponse();

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
        public async Task<Response> UpdateNotificationToken(string notificationToken)
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                user.NotificationToken = notificationToken;
                await _userManager.UpdateAsync(user);
                return SuccessResponse("token has been updated");

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
        public async Task<Response> PopNotification(long notificationId)
        {
            try
            {
                var notification = _context.Notification.FirstOrDefault(x => x.Id == notificationId);
                notification.IsDeleted = true;
                _context.Update(notification);
                if (!await SaveAsync())
                    return FailedSaveResponse(notification);
                return SuccessResponse();

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
        public Response GetAllNotification()
        {
            try
            {
                var notifications = _context.Notification.Where(x => !x.IsDeleted && x.Id == _sessionManager.CurrentLogin.Id)
                    .OrderByDescending(x=> x.DateCreated).ToList();
                var totalnotication = notifications.Count();
                var totalOpenNotifcation = notifications.Where(x => x.IsNewNotication).Count();


                var records = notifications.Select(x => new ListNotificationsDto
                {
                    NotificationId = x.Id,
                    Message = x.Message,
                    Title = x.Title,
                    IsNewNotification = x.IsNewNotication
                    //Time = x.DateCreated
                });
                var data = new
                {
                    Total = totalnotication,
                    TotalOpenNotifcation = totalOpenNotifcation,
                    Records = records
                };
  
                return SuccessResponse(data: data);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
        public async Task<Response> SendMessage(SendMessageDto model)
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                var reciever = _userManager.Users.FirstOrDefault(x => x.Id == model.ReceieverId);
                var fileNames = new List<string>();
                var filename = "";
                bool hasFile = false;
                //if (model.Files != null &&  model.Files.Any())
                //{
                //    hasFile = true;
                //    foreach (var item in model.Files)
                //    {
                //        fileNames.Add(_fileManager.FileUpload(item, "Chat"));
                //    }
                //    filename =  string.Join("|", fileNames);
                //}
                //else
                //{
                //    filename = model.FilePath;
                //}

                var chat = new Chat
                {
                    SenderId = user.Id,
                    ReceieverId = model.ReceieverId,
                    Message = model.Message,
                    MessageRefx = DateTime.Now.Ticks.ToString(),
                    CreatedTimeOffset = model.Time, 
                    Files = model.FilePath,
                    HasFile = hasFile,
                };
                _context.Add(chat);
                if (!await SaveAsync())
                    return FailedSaveResponse(chat);

                //var defaultApp = FirebaseApp.Create(new AppOptions()
                //{
                //    Credential = GoogleCredential.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "key.json")),
                //});

                //var message = new Message()
                //{

                //    Data = new Dictionary<string, string>()
                //    {
                //        ["User"] = user.Email,
                //        ["UserName"] = user.UserName,

                //    },
                //    Notification = new FirebaseAdmin.Messaging.Notification
                //    {
                //        Title = "Message",
                //        Body = model.Message,

                //    },
                //    Token = reciever.NotificationToken,
                //};

                //var messaging = FirebaseMessaging.DefaultInstance;
                //var result = await messaging.SendAsync(message);
                //defaultApp.Delete();
                return SuccessResponse();

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public Response GetMessagesByUserId(long rceieverId)
        {
           try
            {
                var user = _sessionManager.CurrentLogin;
                var data = _context.Chats.Where(x => !x.IsDeleted).Where(x=> x.SenderId == user.Id && x.ReceieverId == rceieverId)
                .Select(x => new 
                {
                    ChatId = x.Id,
                    Message = x.Message,
                    Time = x.CreatedTimeOffset,
                    ReceieverId = x.ReceieverId,
                    SenderId = x.SenderId,

                }).ToList();
               
                return SuccessResponse(data: data);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public Response GetMessages()
        {

            try
            {
                var user = _sessionManager.CurrentLogin;
                var sentMessages = _context.Chats.Where(x => !x.IsDeleted && x.SenderId == user.Id)
                .Select(x => new AllMessagesDto
                {
                    ChatId = x.Id,
                    Message = x.Message,
                    Time = x.CreatedTimeOffset,
                    MessageType = "Send",
                    ReceieverId = x.ReceieverId,
                    ReceieverUserName = x.Receiever.UserName,
                    Files = x.Files.ToSplit('|'),
                    HasFile = x.HasFile

                }).ToList();
                var receivedMessages = _context.Chats.Where(x => x.ReceieverId == user.Id)
                    .Select(x => new AllMessagesDto
                    {
                    ChatId = x.Id,
                    Message = x.Message,
                    Time = x.CreatedTimeOffset,
                    MessageType = "Recieved",
                    SenderId = x.SenderId,
                    SenderUserName = x.Sender.UserName,
                    Files = x.Files.ToSplit('|'),
                    HasFile = x.HasFile

                }).ToList();
                var messages = sentMessages.Concat(receivedMessages).OrderByDescending(x => x.Time).ToList();


                var data = new
                {
                    Messages = messages,
                    totalCount = messages.Count(),
                    Receieved = receivedMessages.Count(),
                    Sent = sentMessages.Count(),
                };
                return SuccessResponse(data: data);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
        public Response GetFeedGroups()
        {
            try
            {
                var feedGroups = _context.FeedGroups.Where(x => !x.IsDeleted)
                    .Select(x => new
                    {
                        Id = x.Id,
                        Name = x.Name,
                        FeedCount = x.Feeds.Count(),
                        Feeds = x.Feeds.ToList().
                        Select(f=> new 
                        {
                            Id = f.Id,
                            Post = f.Post,
                            Creator = f.CreatedByUser.NormalizedUserName,
                            Time = f.CreatedTimeOffset,
                            Likes = f.LikeCount,
                            CommentCount = f.Comments.Count()

                        }),
                    });
                return SuccessResponse(data: feedGroups);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
        public async Task<Response> CreateFeed(CreateFeedDto model)
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                var feed = new Feed
                {
                    Post = model.Feed,
                    FeedGroupId = model.FeedGroupId,
                    CreatedByUserId = user.Id,
                    CreatedTimeOffset = model.Time
                };
                _context.Feeds.Add(feed);
                if (!await SaveAsync())
                    return FailedSaveResponse(model);
                return SuccessResponse();

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
        public Response GetAllFeeds()
        {
            try
            {

                var user = _sessionManager.CurrentLogin;
                var feeds = (from x in _context.Feeds.Include("Likes").Where(x => !x.IsDeleted)
                             join p in _context.UserProfile on x.CreatedByUserId equals p.UserId
                             select new
                             {
                                 FeedId = x.Id,
                                 Feed = x.Post,
                                 LikeedByMe = x.Likes.Any(x => x.LikedByUserId == user.Id && x.Liked) ? true : false,
                                 Creator = p.FirstName + " " + p.LastName,
                                 FeedGroup = x.Group.Name,
                                 FeedGroupId = x.Group.Id,
                                 LikesCount = x.Likes.Where(x=> x.Liked).Count(),
                                 Time = x.CreatedTimeOffset,
                                 CommentCount = x.Comments.Count(),
                                 PicturePath = p.FilePath
                             }); 
                                         
                return SuccessResponse(data: feeds);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public Response GetAllFeedsByGroupId(long groupId)
        {
            try
            {

      
                var user = _sessionManager.CurrentLogin;
                var feeds = (from x in _context.Feeds.Include("Likes").Where(x => !x.IsDeleted && x.FeedGroupId == groupId)
                             join p in _context.UserProfile on x.CreatedByUserId equals p.UserId
                             select new
                             {
                                 FeedId = x.Id,
                                 Feed = x.Post,
                                 LikeedByMe = x.Likes.Any(x => x.LikedByUserId == user.Id && x.Liked) ? true : false,
                                 Creator = p.FirstName + " " + p.LastName,
                                 FeedGroup = x.Group.Name,
                                 FeedGroupId = x.Group.Id,
                                 LikesCount = x.Likes.Where(x => x.Liked).Count(),
                                 Time = x.CreatedTimeOffset,
                                 CommentCount = x.Comments.Count(),
                                 PicturePath = p.FilePath
                             }); ;




                return SuccessResponse(data: feeds);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public Response GetUserFeeds()
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                var feedGroups = _context.Feeds.Where(x => !x.IsDeleted && x.CreatedByUserId == user.Id)
                    .Select(x => new
                    {
                        FeedId = x.Id,
                        Feed = x.Post,
                        FeedGroup = x.Group.Name,
                        FeedGroupId = x.Group.Id,
                        LikesCount = x.Likes.Where(x=> x.Liked).Count(),
                        Time = x.CreatedTimeOffset,
                        CommentCount = x.Comments.Count(),
                        //Comments = x.Comments.ToList().
                        //Select(f => new
                        //{
                        //    CommentId = f.Id,
                        //    Comment = f.Comment,
                        //    Commentor = f.CreatedByUser.UserName,
                        //    Time = f.CreatedTimeOffset,
                        //    LikeCount = f.LikeCount,
                        //    ReplyCount = f.Replies.Count(),
                        //    Likes = f.LikeCount,

                        //}),
                    });
                return SuccessResponse(data: feedGroups);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
        public async Task<Response> CreateComent(CommentDto model)
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                var feed = new CommentOnFeed
                {
                    FeedId = model.FeedId,
                    Comment = model.Comment,
                    CreatedByUserId = user.Id,
                    CreatedTimeOffset = model.Time
                };
                _context.Comments.Add(feed);
                if (!await SaveAsync())
                    return FailedSaveResponse(model);
                return SuccessResponse();

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public async Task<Response> ReplyComent(PushReplyDto model)
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                var feed = new ReplyOnComment
                {
                    CommentId = model.CommentId,
                    Reply = model.Text,
                    CreatedByUserId = user.Id,
                    CreatedTimeOffset = model.Time
                };
                _context.Replies.Add(feed);
                if (!await SaveAsync())
                    return FailedSaveResponse(model);
                return SuccessResponse();

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public Response GetCommentByFeedId(long feedId)
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                var comments = _context.Comments.Include("Replies").Include("Likes").Where(x => !x.IsDeleted && x.FeedId == feedId)
                    .OrderByDescending(m => m.DateCreated).ToList();
                var data = (from comment in comments
                            join profile in _context.UserProfile on comment.CreatedByUserId equals profile.UserId
                            select new
                            {
                                CommentId = comment.Id,
                                Comment = comment.Comment,
                                LikeedByMe = comment.Likes.Any(x => x.LikedByUserId == user.Id && x.Liked) ? true : false,
                                Commentor = profile.FirstName + " " + profile.LastName,
                                CommentorPicture = profile.FilePath,
                                LikesCount = comment.Likes.Where(x=> x.Liked).Count(),
                                RepliesCount = comment.Replies.Where(x=> !x.IsDeleted).Count(),
                                Time = comment.CreatedTimeOffset,

                            }).ToList();
                                
                    
                return SuccessResponse(data: data);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public Response GetRepliesByCommentId(long commentId)
        {
            try
            {
                    var data = (from reply in _context.Replies where reply.IsDeleted == false && reply.CommentId == commentId
                                join profile in _context.UserProfile on reply.CreatedByUserId equals profile.UserId
                                select new
                                {
                                    ReplyId = reply.Id,
                                    ReplyText = reply.Reply,
                                    ReplyBy = profile.FirstName + " " + profile.LastName,
                                    Time = reply.CreatedTimeOffset,
                                    PicturePath = profile.FilePath
                                });
                                                   
                return SuccessResponse(data: data);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public async Task<Response> LikeComment(CommentLikeDto model)
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
              
                var feed = _context.Comments.Include("Likes").FirstOrDefault(x => x.Id == model.CommentId);

                if (feed == null)
                    return AuxillaryResponse("feed not found", StatusCodes.Status404NotFound);

                var like = feed.Likes.FirstOrDefault(x => x.CommentId == model.CommentId && x.LikedByUserId == user.Id);
                if (like != null)
                {
                    if (like.Liked)
                    {
                        like.Liked = false;
                    }
                    else
                    {
                        like.Liked = true;
                    }
                    _context.Update(like);
                    if (!await SaveAsync())
                        return FailedSaveResponse(model);

                    return SuccessResponse();

                }

                var userLike = new Likes
                {
                    LikedByUserId = user.Id,
                    Liked = true,
                    CommentId = model.CommentId
                };
                await _context.AddAsync(userLike);
                if (!await SaveAsync())
                    return FailedSaveResponse(model);

                return SuccessResponse();


            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public async Task<Response> LikeFeed(FeedLikeDto model)
        {
           using(var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var user = _sessionManager.CurrentLogin;
                    var feed = _context.Feeds.Include("Likes").FirstOrDefault( x=> x.Id == model.FeedId);

                    if(feed == null)
                        return AuxillaryResponse("feed not found", StatusCodes.Status404NotFound);

                    var like = feed.Likes.FirstOrDefault(x => x.FeedId == model.FeedId && x.LikedByUserId == user.Id);
                    if (like != null)
                    {
                        if (like.Liked)
                        {
                            like.Liked = false;
                        }
                        else
                        {
                            like.Liked = true;
                        }
                        _context.Update(like);
                        if (!await SaveAsync())
                            return FailedSaveResponse(model);

                        await transaction.CommitAsync();
                        return SuccessResponse();

                    }


                    var userLike = new Likes
                    {
                        LikedByUserId = user.Id,
                        Liked = true,
                        FeedId = model.FeedId
                    };                  
                    await _context.AddAsync(userLike);
                    if (!await SaveAsync())
                        return FailedSaveResponse(model);

                    await transaction.CommitAsync();
                    return SuccessResponse();



                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return InternalErrorResponse(ex);
                }
            }
        }

        public async Task<Response> LikReply(ReplyLikeDto model)
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                var reply = _context.Replies.Find(model.ReplyId);
                if (reply != null)
                {
                    reply.LikeCount = reply.LikeCount + 1;
                    _context.Replies.Update(reply);
                    if (!await SaveAsync())
                        return FailedSaveResponse(model);
                    return SuccessResponse();
                }

                return AuxillaryResponse("reply not found", StatusCodes.Status404NotFound);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

    }
}
