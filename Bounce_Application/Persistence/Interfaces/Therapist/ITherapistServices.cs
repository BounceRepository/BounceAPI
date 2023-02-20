using Bounce.DataTransferObject.DTO.Patient;
using Bounce.DataTransferObject.DTO.Therapist;
using Bounce.DataTransferObject.Helpers.BaseResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.Persistence.Interfaces.Therapist
{
    public interface ITherapistServices
    {
        Task<Response> BankDetailsUpsert(BankAccountDetailDto model);
        Task<Response> CreateTherapistProfile(TherapistProfileDto model);
        Task<Response> CreateUpdateUpdateTherapistAccountDetails(TherapistAccountDetailsDto model);
        Response GetAllTherapist();
        Response GetCommissions();
        Response GetPatientProfileHistory(long patientId);
        Task<Response> GetQuestions();
        Response GetTherapisById(long id);
        Response GetTherapistBankDetail();
        Response GetTherapistCommision();
        Response GetTherapistConsultaion(string filter);
        Response GetTherapistConsultaionById(long id);
        Response GetTherapistDashBoard();
        Response GetTherapistSchedules();
        Task<Response> ValidateAssement(AssesmentDto model);
    }
}
