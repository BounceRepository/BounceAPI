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

        Task<Response> ComfirmWalletTop(string TrxRef);
        Task<Response> ConfirmAppointment(string trxRef);
        Task<Response> GetWalletBallance();
        Task<Response> InitailizePaymentAsync(PaymentRequestDto model);
        Task<Response> PayWithWallet(string TxRef);
        Task<Response> Requery(string TxRef);
        Task<Response> TransactionByFilter(string filter);
        Task<Response> TransactionHistory();
  
        Task<Response> WalletTop(WalletToUpDto model);
  
    }
}
