using Bounce.DataTransferObject.DTO.Patient;
using Bounce.DataTransferObject.DTO.Payment;
using Bounce_Application.Persistence.Interfaces.Patient;
using Bounce_Application.Persistence.Interfaces.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Bounce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : BaseController
    {
        private readonly IPaymentServices _paymentServices;


        public PaymentController(IHttpContextAccessor httpContext, IPaymentServices paymentServices) : base(httpContext)
        {

            _paymentServices = paymentServices;
        }

       
        [HttpPost("PaymentRequest")]
        public async Task<IActionResult> PaymentRequest([FromBody] PaymentRequestDto model) => Response(await _paymentServices.InitailizePaymentAsync(model));


        [HttpPost("PaymentRequery")]
        public async Task<IActionResult> PaymentRequery([FromQuery] string TxRef) => Response( await _paymentServices.Requery(TxRef));

        [HttpPost("WalletTop")]
        public async Task<IActionResult> WalletTop([FromBody] WalletToUpDto model) => Response(await _paymentServices.WalletTop(model));
        //[HttpPost("ComfirmAppointment")]
        //public async Task<IActionResult> ComfirmAppointment([FromQuery] string TxRef) => Response(await _paymentServices.ConfirmAppointment(TxRef));
    }
}

