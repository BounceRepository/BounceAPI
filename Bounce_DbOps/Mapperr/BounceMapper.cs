using AutoMapper;
using Bounce.DataTransferObject.DTO.Auth.Articles;
using Bounce.DataTransferObject.DTO.Notification;
using Bounce.DataTransferObject.DTO.Patient;
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
            CreateMap<PushNotificationDto, Notifications>(); 


        }
    }
}
