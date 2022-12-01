using Bounce.DataTransferObject.DTO.Admin;
using Bounce.DataTransferObject.Helpers.BaseResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.Persistence.Interfaces.Admin
{
    public interface IAdminServices
    {
        Task<Response> CreateQuestion(TherapistQuestionDTO model);
        Task<Response> GetUsersAsync(string role);
        Task<Response> GetUsersByIdAsync(long Id);
    }
}
