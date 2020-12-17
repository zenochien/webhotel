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
        public IActionResult GetPaymentStatus(PaymentStatus paymentStatus)
        {
            _paymentStatus.AddPaymentStatus(paymentStatus);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + paymentStatus.PaymentStatusID, paymentStatus);
        }

        [HttpDelete]
        [Route("api/[controller]/{paymentstatusid}")]
        public IActionResult DeletePaymentStatus(Guid paymentstatusid)
        {
            var paymentStatus = _paymentStatus.GetPaymentStatus(paymentstatusid);
            if (paymentstatusid != null)
            {
                _paymentStatus.DeletePaymentStatus(paymentStatus);
                return Ok();
            }
            return NotFound($"Payment Status with id: {paymentstatusid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{paymentstatusid}")]
        public IActionResult EditGuests(Guid paymentstatusid, PaymentStatus paymentStatus)
        {
            var existingPS = _paymentStatus.GetPaymentStatus(paymentstatusid);
            if (existingPS != null)
            {
                paymentStatus.PaymentStatusID = existingPS.PaymentStatusID;
                _paymentStatus.EditPaymentStatus(paymentStatus);
            }
            return Ok(paymentStatus);
        }
    }
}
