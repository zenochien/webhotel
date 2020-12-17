using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Controllers
{
    [ApiController]
    public class PaymentStatusController : ControllerBase
    {
        private readonly IPaymentStatus _paymentStatus;
        public PaymentStatusController(IPaymentStatus paymentStatus)
        {
            _paymentStatus = paymentStatus;
        }

        [HttpGet]
        [Route("/")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/[controller]/{paymentstatusid}")]
        public IActionResult GetPaymentStatus(Guid paymentstatusid)
        {
            var paymentStatus = _paymentStatus.GetPaymentStatus(paymentstatusid);
            if (paymentStatus != null)
            {
                return Ok(paymentStatus);
            }
            return NotFound($"Payment Status with id: {paymentstatusid} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> GetPaymentStatus(PaymentStatus paymentStatus)
        {
           var resurt = await _paymentStatus.AddPaymentStatusAsync(paymentStatus);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + resurt.PaymentStatusID, resurt);
        }

        [HttpDelete]
        [Route("api/[controller]/{paymentstatusid}")]
        public async Task<IActionResult> DeletePaymentStatus(Guid paymentstatusid)
        {
            var paymentStatus = _paymentStatus.GetPaymentStatus(paymentstatusid);
            if (paymentstatusid != null)
            {
                
                return Ok(await _paymentStatus.DeletePaymentStatusAsync(paymentStatus));
            }
            return NotFound($"Payment Status with id: {paymentstatusid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{paymentstatusid}")]
        public async Task<IActionResult> EditGuests(Guid paymentstatusid, PaymentStatus paymentStatus)
        {
            paymentStatus.PaymentStatusID = paymentstatusid;
           return Ok(await _paymentStatus.UpdatePaymentStatusAsync(paymentStatus));
        }
    }
}
