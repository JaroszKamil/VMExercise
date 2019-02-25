using BusinessLayer;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestUserApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Address")]
    public class AddressController : Controller
    {
        private IAddressService _service;

        public AddressController(IAddressService service)
        {
            _service = service;
        }

        // GET: api/Address
        [HttpGet]
        public IActionResult Get()
        {
            var address = _service.GetAllAddresss();

            var status = address != null ? StatusCodes.Status200OK : StatusCodes.Status204NoContent;

            return StatusCode(status, address);
        }

        // GET: api/Address/5
        [HttpGet("{customerId}&{addressType}", Name = "Get")]
        public IActionResult Get(int customerId, string addressType)
        {
            var address = _service.GetAddress(customerId.ToString(), addressType);

            var status = address != null ? StatusCodes.Status200OK : StatusCodes.Status204NoContent;

            return StatusCode(status, address);
        }
        
        // POST: api/Address
        [HttpPost]
        public IActionResult Post([FromBody]Address value)
        {
            var address = _service.CreateAddress(value);

            var status = address == true ? StatusCodes.Status200OK : StatusCodes.Status304NotModified;

            return StatusCode(status, address);
        }
        
        // PUT: api/Address/5
        [HttpPut]
        public IActionResult Put([FromBody]Address value)
        {
            var address = _service.UpdateAddress(value);

            var status = address == true ? StatusCodes.Status200OK : StatusCodes.Status304NotModified;

            return StatusCode(status, address);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{customerId}&{addressType}")]
        public IActionResult Delete(string addressType, string customerId)
        {
            var address = _service.DeleteAddress(addressType, customerId);

            var status = address == true ? StatusCodes.Status200OK : StatusCodes.Status304NotModified;

            return StatusCode(status, address);
        }
    }
}
