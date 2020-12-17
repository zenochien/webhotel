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
    public class PaymentTypesController : ControllerBase
    {
        private readonly IPaymentTypes _paymentTypes;
        public PaymentTypesController(IPaymentTypes paymentTypes)
        {
            _paymentTypes = paymentTypes;
        }

        [HttpGet]
        [Route("api/[controller]/{paymenttypeid}")]
        public IActionResult GetPaymentTypes(Guid paymenttypeid)
        {
            var paymentTypes = _paymentTypes.GetPaymentTypes(paymenttypeid);
            if (paymentTypes != null)
            {
                return Ok(paymentTypes);
            }
            return NotFound($"Payment Types with id: {paymenttypeid} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetPaymentTypes(PaymentTypes paymentTypes)
        {
            _paymentTypes.AddPaymentTypes(paymentTypes);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + paymentTypes.PaymentTypeID, paymentTypes);
        }

        [HttpDelete]
        [Route("api/[controller]/{paymenttypeid}")]
        public IActionResult DeletePaymentTypes(Guid paymenttypeid)
        {
            var paymentTypes = _paymentTypes.GetPaymentTypes(paymenttypeid);
            if (paymenttypeid != null)
            {
                _paymentTypes.DeletePaymentTypes(paymentTypes);
                return Ok();
            }
            return NotFound($"Payment Types with id: {paymenttypeid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{guestid}")]
        public IActionResult EditPaymentTypes(Guid paymenttypeid, PaymentTypes paymentTypes)
        {
            var existingPT = _paymentTypes.GetPaymentTypes(paymenttypeid);
            if (existingPT != null)
            {
                paymentTypes.PaymentTypeID = existingPT.PaymentTypeID;
                _paymentTypes.EditPaymentTypes(paymentTypes);
            }
            return Ok(paymentTypes);
        }
    }
}
