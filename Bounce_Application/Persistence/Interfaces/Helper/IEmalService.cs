using Bounce_Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.Persistence.Interfaces.Helper
{
    public interface IEmalService
    {
        Task<bool> SendMail(EmailRequest emailRequest);
    }
}
