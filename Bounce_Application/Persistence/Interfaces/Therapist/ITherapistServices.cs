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
    }
}
