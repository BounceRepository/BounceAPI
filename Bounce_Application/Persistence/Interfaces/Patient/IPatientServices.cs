using Bounce.DataTransferObject.DTO;
using Bounce.DataTransferObject.DTO.Patient;
using Bounce.DataTransferObject.Helpers.BaseResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.Persistence.Interfaces.Patient
{
    public interface IPatientServices 
    {
        Task<Response> BookAppointment(AppointmentDto model);
        ReviewCalculationDto CalculateTherapisRating(long id);
        Task<Response> CreateReview(CreateReviewDto model);
        Response GetAllFeelings();
        Response GetAllPlans();
        Response GetMessages();
        Response GetReviewByTherapistId(long id);
        Task<Response> GetTherapist();
        Response GetUserFeelings();
        Response LogUserFeeling(List<string> feelings);
        Task<Response> ReScheduleAppointtment(ReScheduleAppointmentDto model);
        Task<Response> SubscribeToPlan(long planId, long subPlanId);
        Task<Response> UpcomingAppointment();
        Task<Response> UpdateProfileAsync(UpdateProfileDto model);
    }
}
