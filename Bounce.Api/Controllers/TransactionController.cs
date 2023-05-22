using Bounce.DataTransferObject.DTO.Patient;
using Bounce.DataTransferObject.DTO.Payment;
using Bounce_Application.Persistence.Interfaces.Patient;
using Bounce_Application.Persistence.Interfaces.Payment;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Bounce.Api.Controllers
{
   
    [ApiController]
    [Route("api/transaction")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TransactionController : BaseController

    {
        private readonly IPaymentServices _paymentServices;
        private readonly IWebHostEnvironment hostEnvironment;


        public TransactionController(IHttpContextAccessor httpContext, IPaymentServices paymentServices, IWebHostEnvironment hostEnvironment) : base(httpContext)
        {

            _paymentServices = paymentServices;
            this.hostEnvironment = hostEnvironment;
        }


        [HttpPost("PaymentWithWallet")]
        public async Task<IActionResult> PaymentWithWallet([FromQuery] string TxRef) => Response(await _paymentServices.PayWithWallet(TxRef));

        [HttpPost("PaymentRequest")]
        public async Task<IActionResult> PaymentRequest([FromBody] PaymentRequestDto model) => Response(await _paymentServices.InitailizePaymentAsync(model));


        [HttpPost("PaymentRequery")]
        public async Task<IActionResult> PaymentRequery([FromQuery] string TxRef) => Response( await _paymentServices.Requery(TxRef));

        [HttpPost("WalletTop")]
        public async Task<IActionResult> WalletTop([FromBody] WalletToUpDto model, CancellationToken cancellationToken)
        {
            await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken);
            if (cancellationToken.IsCancellationRequested)
            {
                return BadRequest( new
                {
                    success = false,
                    Message = "request was cancelled",
                });
            }

            return Response(await _paymentServices.WalletTop(model));
        }
            
          
        [HttpPost("ComfirmTopUp")]
        public async Task<IActionResult> ComfirmTopUp([FromQuery] string TxRef) => Response(await _paymentServices.ComfirmWalletTop(TxRef));

        [HttpGet("WalletTransactionHistory")]
        public async Task<IActionResult> WalletUpHistory() => Response(await _paymentServices.TransactionByFilter("all"));

        [HttpGet("GetTransactionHistory")]
        public async Task<IActionResult> TopUpHistory([FromQuery] string filter) => Response(await _paymentServices.TransactionByFilter(filter));

        [HttpGet("GetWalletBalance")]
        public async Task<IActionResult> WalletBallance() => Response(await _paymentServices.GetWalletBallance());

 
        [HttpGet("GetBankList")]
        public async Task<IActionResult> BankList()
        {

            try
            {
                var jsonPath = Path.Combine(hostEnvironment.ContentRootPath, "bankList.json");
                using (var fs = System.IO.File.OpenText(jsonPath))
                {
                    var data = await fs.ReadToEndAsync();
                    var obj = JsonConvert.DeserializeObject<List<BankCodeName>>(data);
                    var resp = obj.OrderBy(x => x.name);
                 


                    return Ok(resp);
                }
            }
            catch(Exception exp)
            {
                return BadRequest(exp.Message);
            }
           

        
        }
        [HttpPost("TherapistCommissionPayment")]
        public async Task<IActionResult> TherapistCommissionPayment([FromBody] TherapistComimssionDto model) => Response(await _paymentServices.TherapistCommisionPayment(model));

    }
}

