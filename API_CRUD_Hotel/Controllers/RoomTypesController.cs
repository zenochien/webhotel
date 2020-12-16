using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Controllers
{
    [ApiController]
    public class RoomTypesController : ControllerBase
    {
        private readonly IRoomTypes _roomTypes;
        public RoomTypesController(IRoomTypes roomTypes)
        {
            _roomTypes = roomTypes;
        }

        [HttpGet]
        [Route("api/[controller]/{roomtypeid}")]
        public IActionResult GetRoomTypes(Guid roomtypeid)
        {
            var rommTypes = _roomTypes.GetRoomTypes(roomtypeid);
            if (rommTypes != null)
            {
                return Ok(rommTypes);
            }
            return NotFound($"Room Types with id: {roomtypeid} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> GetRoomTypes(RoomTypes roomTypes)
        {
            var result = await _roomTypes.AddRoomTypesAsync(roomTypes);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + result.RoomTypeID, result);
        }

        [HttpDelete]
        [Route("api/[controller]/{guestid}")]
        public async Task<IActionResult> DeleteRoomTypes(Guid roomtypeid)
        {
            var roomTypes = _roomTypes.GetRoomTypes(roomtypeid);
            if (roomtypeid != null)
            {
                return Ok(await _roomTypes.DeleteRoomTypesAsync(roomTypes));
            }
            return NotFound($"Room Types with id: {roomTypes} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{roomtypeid}")]
        public async Task<IActionResult> EditRoomTypes(Guid roomTypesid, RoomTypes roomTypes)
        {            
                roomTypes.RoomTypeID = roomTypesid;
                return Ok(await _roomTypes.UpdateRoomTypesAsync(roomTypes));            
        }
    }
}
    

