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
        public IActionResult GetPayments(Payments payments)
        {
            _payments.AddPayments(payments);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + payments.PaymentID, payments);
        }

        [HttpDelete]
        [Route("api/[controller]/{paymentid}")]
        public IActionResult DeletePayments(Guid paymentid)
        {
            var payments = _payments.GetPayments(paymentid);
            if (paymentid != null)
            {
                _payments.DeletePayments(payments);
                return Ok();
            }
            return NotFound($"Payments with id: {paymentid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{paymentid}")]
        public IActionResult EditPayments(Guid paymentid, Payments payments)
        {
            var existingPayment = _payments.GetPayments(paymentid);
            if (existingPayment != null)
            {
                payments.PaymentID = existingPayment.PaymentID;
                _payments.EditPayments(payments);
            }
            return Ok(payments);
        }
    }
}
