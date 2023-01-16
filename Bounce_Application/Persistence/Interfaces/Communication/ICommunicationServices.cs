using Bounce.DataTransferObject.Helpers.BaseResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.Persistence.Interfaces.Communication
{
    public interface ICommunicationServices
    {
        Response GetChannelDetail(long appointRequestId);
        Task<Response> StartConsulation(long appointRequestId);
        Task<Response> StopConsulation(long appointRequestId);
    }
}
