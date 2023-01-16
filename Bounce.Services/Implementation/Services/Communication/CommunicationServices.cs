using AgoraIO.Services;
using AutoMapper;
using Bounce.DataTransferObject.DTO.Notification;
using Bounce.DataTransferObject.Helpers.BaseResponse;
using Bounce_Application.DTO;
using Bounce_Application.Persistence.Interfaces.Communication;
using Bounce_Application.Persistence.Interfaces.Helper;
using Bounce_Application.Persistence.Interfaces.Notification;
using Bounce_Application.SeriLog;
using Bounce_Application.Settings;
using Bounce_Application.Utilies;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.Implementation.Services.Communication
{
    public class CommunicationServices : BaseServices, ICommunicationServices
    {
        private readonly IMapper _mapper;
        private readonly SessionManager _sessionManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IEmalService _EmailService;
        private readonly FileManager _fileManager;
        private readonly AdminLogger _adminLogger;
        private readonly AgoraSetting _agoraSetting;
        private readonly INotificationService  _notificationService;

        
        public string rootPath { get; set; }
        public CommunicationServices(BounceDbContext context, IMapper mapper, SessionManager sessionManager,
            UserManager<ApplicationUser> userManager, IHostingEnvironment hostingEnvironment, IEmalService emailService,
            FileManager fileManager, AdminLogger adminLogger, IOptions<AgoraSetting> agoraSetting, INotificationService notificationService) : base(context)
        {
            _mapper = mapper;
            _sessionManager = sessionManager;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
            _EmailService = emailService;
            _fileManager = fileManager;
            _adminLogger = adminLogger;
            _agoraSetting = agoraSetting.Value;
            rootPath = _hostingEnvironment.ContentRootPath;
            _notificationService = notificationService;
        }
        public async Task<Response> StartConsulation(long appointRequestId)
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                ApplicationUser receiver = default;
                var appointment = _context.AppointmentRequest.Where(x=> x.StartTime != null).FirstOrDefault(x=> x.Id == appointRequestId);
                if (appointment == null)
                    return AuxillaryResponse("record not found", StatusCodes.Status404NotFound);

                //if (appointment.StartTime.Value.DateTime < DateTime.Now)
                //    return AuxillaryResponse("session is not due", StatusCodes.Status400BadRequest);

                if (appointment.StartTime.Value.DateTime > DateTime.Now)
                    return AuxillaryResponse("session is  over due", StatusCodes.Status400BadRequest);

                long receiverId = default;
                var dr = _context.TherapistProfiles.FirstOrDefault(x => x.UserId == appointment.TherapistId);
                var name = "";

                if (user.Discriminator == Bounce_Domain.Enum.UserType.Patient)
                {
                    var therapist = _context.TherapistProfiles.FirstOrDefault(x => x.UserId == appointment.TherapistId);
                    name = therapist.Title + " " + therapist.FirstName;
                    receiver = _userManager.Users.FirstOrDefault(x => x.Id == appointment.TherapistId);
                }
                else
                {
                    var patient = _context.UserProfile.FirstOrDefault(x => x.UserId == appointment.PatientId);
                    name = patient.FirstName;
                    receiver = _userManager.Users.FirstOrDefault(x => x.Id == appointment.PatientId);
                }

                var channelName = $"Session with {dr.Title} {dr.FirstName}";

                var channelToken = GenerateAlgoraChannelToken(channelName, appointRequestId);

                var channel = new AlgoraChannel
                {
                    ChannelToken = channelToken,
                    ChannelName = channelName,
                    AppointmentRequestId = appointRequestId,
                };
                _context.Add(channel);

                var pushNotifications = new List<PushNotificationDto>();
                var mailBuilder = new StringBuilder();
                appointment.Status = Bounce_Domain.Enum.AppointmentStatus.OnGoing;
                _context.Update(appointment);

                if (!await SaveAsync())
                    return FailedSaveResponse();
                mailBuilder.AppendLine("Dear" + " " + name + "," + "<br />");
                mailBuilder.AppendLine("<br />");
                mailBuilder.AppendLine($"You have an active consultation session, kindly login to your app to join the session .<br />");
                mailBuilder.AppendLine("<br />");
                mailBuilder.AppendLine("Regards:<br />");
                var patientPushNotification = new PushNotificationDto
                {
                    Title = "Consultation",
                    Topic = "Consultation",
                    Message = $"You have an active consultation session, kindly login to your app to join the session ",
                    TrxRef = appointment.TrxRef,
                    userId = receiver.Id,

                };
               pushNotifications.Add(patientPushNotification);

                var emailRequest = new EmailRequest
                {
                    To = user.Email,
                    Body = EmailFormatter.FormatGenericEmail(mailBuilder.ToString(), rootPath),
                    Subject = $"Consultaion with {dr.Title}  " + dr.FirstName
                };

                await _notificationService.PushMultipleNotificationAsyn(pushNotifications);
                await _EmailService.SendMail(emailRequest).ConfigureAwait(false);

                return SuccessResponse(data: new { channelToken = channelToken , channeName = channelName });

            }
            catch (Exception ex)
            {

                return InternalErrorResponse(ex);
            }

           
        }


        public async Task<Response> StopConsulation(long appointRequestId)
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                ApplicationUser receiver = default;
                var appointment = _context.AppointmentRequest.FirstOrDefault(x => x.Id == appointRequestId &&
                x.Status != Bounce_Domain.Enum.AppointmentStatus.Completed);
                if (appointment == null)
                    return AuxillaryResponse("record not found", StatusCodes.Status404NotFound);
                long receiverId = default;
                var name = "";

                if (user.Discriminator == Bounce_Domain.Enum.UserType.Patient)
                {
                    var therapist = _context.TherapistProfiles.FirstOrDefault(x => x.UserId == appointment.TherapistId);
                    name = therapist.Title + " " + therapist.FirstName;
                    receiver = _userManager.Users.FirstOrDefault(x => x.Id == appointment.TherapistId);
                }
                else
                {
                    var patient = _context.UserProfile.FirstOrDefault(x => x.UserId == appointment.PatientId);
                    name = patient.FirstName;
                    receiver = _userManager.Users.FirstOrDefault(x => x.Id == appointment.PatientId);
                }

                var pushNotifications = new List<PushNotificationDto>();
                var mailBuilder = new StringBuilder();
                var dr = _context.TherapistProfiles.FirstOrDefault(x => x.UserId == appointment.TherapistId);
                appointment.Status = Bounce_Domain.Enum.AppointmentStatus.Completed;
                _context.Update(appointment);

                if (!await SaveAsync())
                    return FailedSaveResponse();

                mailBuilder.AppendLine("Dear" + " " + name + "," + "<br />");
                mailBuilder.AppendLine("<br />");
                mailBuilder.AppendLine($"Your Consultation has ended.<br />");
                mailBuilder.AppendLine("<br />");
                mailBuilder.AppendLine("Regards:<br />");
                var patientPushNotification = new PushNotificationDto
                {
                    Title = "Consultation",
                    Topic = "Consultation",
                    Message = $"Your Consultation with {dr.Title}  " + dr.FirstName + " has ended",
                    TrxRef = appointment.TrxRef,
                    userId = receiver.Id,

                };
                pushNotifications.Add(patientPushNotification);

                var emailRequest = new EmailRequest
                {
                    To = user.Email,
                    Body = EmailFormatter.FormatGenericEmail(mailBuilder.ToString(), rootPath),
                    Subject = $"Consultaion with {dr.Title}  " + dr.FirstName
                };

                await _notificationService.PushMultipleNotificationAsyn(pushNotifications);
                await _EmailService.SendMail(emailRequest).ConfigureAwait(false);

                return SuccessResponse();

            }
            catch (Exception ex)
            {

                return InternalErrorResponse(ex);
            }
        }

        public Response GetChannelDetail(long appointRequestId)
        {
            try
            {
                var channel = _context.Channels.OrderByDescending(x => x.DateCreated).FirstOrDefault(x => x.AppointmentRequestId == appointRequestId);

                if(channel == null)
                {

                    return SuccessResponse(data: null);
                }

                return SuccessResponse(data: new { channelToken = channel.ChannelToken, channeName = channel.ChannelName });

            }
            catch (Exception ex)
            {

                return InternalErrorResponse(ex);
            }


        }
        public string GenerateAlgoraChannelToken(string channelName, long uid)
        {
            var token = new AgoraService(_agoraSetting.appId, _agoraSetting.appCertificate, channelName, uid.ToString(),
                _agoraSetting.userAccount, _agoraSetting.expirationTimeInSeconds).GenerateDynamicKey();
            return token;
        }
    }
}
