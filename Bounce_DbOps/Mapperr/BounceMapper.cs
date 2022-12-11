using AutoMapper;
using Bounce.DataTransferObject.DTO.Auth.Articles;
using Bounce.DataTransferObject.DTO.Notification;
using Bounce.DataTransferObject.DTO.Patient;
using Bounce.DataTransferObject.DTO.Therapist;
using Bounce_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_DbOps.Mapperr
{
    public class BounceMapper : Profile
    {
        public BounceMapper()
        {

            CreateMap<BankAccountDetailDto, BankAccountDetails>();

            CreateMap<ArticleCreateDto, Article>();
            CreateMap<TherapistAccountDetailsDto, BankAccountDetails>()
                .ForMember(x => x.BankName, o => o.MapFrom(f => f.BankName.EncryptString()))
                 .ForMember(x => x.AccountName, o => o.MapFrom(f => f.AccountName.EncryptString()))
                  .ForMember(x => x.AccountNumber, o => o.MapFrom(f => f.AccountNumber.EncryptString()));
            CreateMap<AppointmentDto,AppointmentRequest>(); 
            CreateMap<PushNotificationDto, NotificationModel>(); 
            CreateMap<TherapistProfileDto, TherapistProfile>()
                .ForMember(x => x.YearsOfExperience, o => o.MapFrom(f => f.YearsOfExperience.ToString()))
                 .ForMember(x => x.Email, o => o.MapFrom(f => f.AboutMe))
                .ForMember(x => x.ProfilePicture, o => o.Ignore())
                .ForMember(x => x.ConsultationDays, o => o.MapFrom(f => string.Join("|", f.ConsultationDays)));



        }
    }
}
