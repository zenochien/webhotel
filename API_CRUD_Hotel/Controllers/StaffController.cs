using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
            var staff = _staff.GetStaffs(staffid);
            if (staff != null)
            {
                return Ok(staff);
            }
            return NotFound($"Staff with id: {staffid} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> GetStaff(Rates staff)
        {
            var result = await _staff.AddStaffAsync(staff);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + result.StaffID, result);
        }

        [HttpDelete]
        [Route("api/[controller]/{staffid}")]
        public async Task<IActionResult> DeleteStaff(Guid staffid)
        {
            var staff = _staff.GetStaffs(staffid);
            if (staffid != null)
            {
                return Ok(await _staff.DeleteStaffAsync(staff));
            }
            return NotFound($"Staff with id: {staffid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{guestid}")]
        public async Task<IActionResult> EditGuests(Guid staffid, Rates staff)
        {
            staff.StaffID = staffid;
            return Ok(await _staff.UpdateStaffAsync(staff));
        }
    }
}
