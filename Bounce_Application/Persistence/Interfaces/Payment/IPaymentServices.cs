using Bounce.DataTransferObject.DTO.Patient;
using Bounce.DataTransferObject.DTO.Payment;
using Bounce.DataTransferObject.Helpers.BaseResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.Persistence.Interfaces.Payment
{
    public interface IPaymentServices
    {
        Task<Response> BookAppointment(AppointmentDto model);
        Task<Response> ConfirmAppointment(string trxRef);
        Task<Response> InitailizePaymentAsync(PaymentRequestDto model);
        Task<Response> Requery(string TxRef);
        Task<Response> WalletTop(WalletToUpDto model);
    }
}
