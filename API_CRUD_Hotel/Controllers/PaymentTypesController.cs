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
        private readonly IPaymentType _paymentTypes;
        public PaymentTypesController(IPaymentType paymentTypes)
        {
            _paymentTypes = paymentTypes;
        }

        [HttpGet]
        [Route("/")]
        public async Task<IActionResult> Get()
        {
            return Ok();
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
        public async Task<IActionResult> GetPaymentTypes(PaymentTypes paymentTypes)
        {
           var result = await _paymentTypes.AddPaymentTypesAsync(paymentTypes);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + result.PaymentTypeID, result);
        }

        [HttpDelete]
        [Route("api/[controller]/{paymenttypeid}")]
        public async Task<IActionResult> DeletePaymentTypes(Guid paymenttypeid)
        {
            var paymentTypes =  _paymentTypes.GetPaymentTypes(paymenttypeid);
            if (paymenttypeid != null)
            {
                
                return Ok(await _paymentTypes.DeletePaymentTypesAsync(paymentTypes));
            }
            return NotFound($"Payment Types with id: {paymenttypeid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{guestid}")]
        public async Task<IActionResult> EditPaymentTypes(Guid paymenttypeid, PaymentTypes paymentTypes)
        {
                paymentTypes.PaymentTypeID = paymenttypeid;
               return Ok(await _paymentTypes.UpdatePaymentTypesAsync(paymentTypes));
         }
    }
}
