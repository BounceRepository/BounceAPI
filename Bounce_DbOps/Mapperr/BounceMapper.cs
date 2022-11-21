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
