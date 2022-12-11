using Bounce.DataTransferObject.DTO.Journal;
using Bounce.DataTransferObject.Helpers.BaseResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.Persistence.Interfaces.Journal
{
    public interface IJournalServices
    {
        Task<Response> Create(CreateJournalDto model);
        Task<Response> Delete(long id);
        Task<Response> Edit(UpdateJournalDto model);
        Response GetAll();
        Response GetById(long id);
    }
}
