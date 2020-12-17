using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Controllers
{
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPayments _payments;
        public PaymentsController(IPayments payments)
        {
            _payments = payments;
        }


        [HttpGet]
        [Route("api/[controller]/{paymentid}")]
        public IActionResult GetPayments(Guid paymentid)
        {
            var payments = _payments.GetPayments(paymentid);
            if (payments != null)
            {
                return Ok(payments);
            }
            return NotFound($"Payments with id: {paymentid} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> GetPayments(Payments payments)
        {
            var result = await _payments.AddPayments(payments);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + result.PaymentID, result);
        }

        [HttpDelete]
        [Route("api/[controller]/{paymentid}")]
        public async Task<IActionResult> DeletePayments(Guid paymentid)
        {
            var payments = _payments.GetPayments(paymentid);
            if (paymentid != null)
            {

                return Ok(await _payments.DeletePayments(payments));
            }
            return NotFound($"Payments with id: {paymentid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{paymentid}")]
        public async Task<IActionResult> EditPayments(Guid paymentid, Payments payments)
        {
            payments.PaymentID = paymentid;
            return Ok(await _payments.UpdatePaymentsAsync(payments));

        }
    }
}
