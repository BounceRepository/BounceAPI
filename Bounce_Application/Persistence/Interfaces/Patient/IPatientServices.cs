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
        Response GetAllPatient();
        Response GetAllPlans();
        Task<Response> GetAvialableTimeByTherapistId(long therapistid, DateTime date);
    
        Response GetPatienceById(long id);
        Response GetPatienceProfileHistory(long id);
        Response GetReviewByTherapistId(long id);
        Task<Response> GetTherapist();
        Response GetUserFeelings();
        Task<Response> ReScheduleAppointtment(ReScheduleAppointmentDto model);
        Response SearchPatient(string query);
        Task<Response> SubscribeToPlan(long planId, long subPlanId);
        Task<Response> UpcomingAppointment(string filter);
        Task<Response> UpdateProfileAsync(UpdateProfileDto model);
        Task<Response> UpdateUserFellings(UpdateUserModeDto model);
    }
}
