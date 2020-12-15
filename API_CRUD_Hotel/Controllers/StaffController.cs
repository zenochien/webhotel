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
    public class StaffController : ControllerBase
    {
        private readonly IStaff _staff;
        public StaffController(IStaff staff)
        {
            _staff = staff;
        }
        [HttpGet]
        [Route("api/[controller]/{staffid}")]
        public IActionResult GetStaff(Guid staffid)
        {
            var staff = _staff.GetStaff(staffid);
            if (staff != null)
            {
                return Ok(staff);
            }
            return NotFound($"Staff with id: {staffid} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetStaff(Staff staff)
        {
            _staff.AddStaff(staff);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + staff.StaffID, staff);
        }

        [HttpDelete]
        [Route("api/[controller]/{staffid}")]
        public IActionResult DeleteStaff(Guid staffid)
        {
            var staff = _staff.GetStaff(staffid);
            if (staffid != null)
            {
                _staff.DeleteStaff(staff);
                return Ok();
            }
            return NotFound($"Staff with id: {staffid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{guestid}")]
        public IActionResult EditGuests(Guid staffid, Staff staff)
        {
            var existingStaff = _staff.GetStaff(staffid);
            if (existingStaff != null)
            {
                staff.StaffID = existingStaff.StaffID;
                _staff.EditStaff(staff);
            }
            return Ok(staff);
        }
    }
}
