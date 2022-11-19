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
        Response GetAllFeelings();
        Response GetAllPlans();
        Response GetMessages();
        Task<Response> GetTherapist();
        Response GetUserFeelings();
        Response LogUserFeeling(List<string> feelings);
        Task<Response> UpcomingAppointment();
        Task<Response> UpdateProfileAsync(UpdateProfileDto model);
    }
}
