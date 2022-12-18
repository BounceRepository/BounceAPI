using Bounce.DataTransferObject.DTO.Patient;
using Bounce.DataTransferObject.DTO.Payment;
using Bounce_Application.Persistence.Interfaces.Patient;
using Bounce_Application.Persistence.Interfaces.Payment;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Bounce.Api.Controllers
{
   
    [ApiController]
    [Route("api/transaction")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TransactionController : BaseController
    {
        private readonly IPaymentServices _paymentServices;


        public TransactionController(IHttpContextAccessor httpContext, IPaymentServices paymentServices) : base(httpContext)
        {

            _paymentServices = paymentServices;
        }


        [HttpPost("PaymentWithWallet")]
        public async Task<IActionResult> PaymentWithWallet([FromQuery] string TxRef) => Response(await _paymentServices.PayWithWallet(TxRef));

        [HttpPost("PaymentRequest")]
        public async Task<IActionResult> PaymentRequest([FromBody] PaymentRequestDto model) => Response(await _paymentServices.InitailizePaymentAsync(model));


        [HttpPost("PaymentRequery")]
        public async Task<IActionResult> PaymentRequery([FromQuery] string TxRef) => Response( await _paymentServices.Requery(TxRef));

        [HttpPost("WalletTop")]
        public async Task<IActionResult> WalletTop([FromBody] WalletToUpDto model) => Response(await _paymentServices.WalletTop(model));
        [HttpPost("ComfirmTopUp")]
        public async Task<IActionResult> ComfirmTopUp([FromQuery] string TxRef) => Response(await _paymentServices.ComfirmWalletTop(TxRef));

        [HttpGet("WalletTransactionHistory")]
        public async Task<IActionResult> WalletUpHistory() => Response(await _paymentServices.TransactionByFilter("all"));

        [HttpGet("GetTransactionHistory")]
        public async Task<IActionResult> TopUpHistory([FromQuery] string filter) => Response(await _paymentServices.TransactionByFilter(filter));

        [HttpGet("GetWalletBalance")]
        public async Task<IActionResult> WalletBallance() => Response(await _paymentServices.GetWalletBallance());
        //[AllowAnonymous]


        //[HttpGet("ConfirmTransaction")]
        //public async Task<IActionResult> TransactionComfirmation([FromQuery] string q )
        //{

        //    return Ok(q);
        //    //=> Response(await _paymentServices.GetWalletBallance());
        //}
    }
}

