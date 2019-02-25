using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestUserApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var customer = _service.GetAllCustomers();

            var status = customer != null ? StatusCodes.Status200OK : StatusCodes.Status204NoContent;

            return StatusCode(status, customer);
        }

        // GET api/values/5
        [HttpGet("{customerId}")]
        public IActionResult Get(int customerId)
        {
            var customer = _service.GetCustomer(customerId.ToString());

            var status = customer != null ? StatusCodes.Status200OK : StatusCodes.Status204NoContent;

            return StatusCode(status, customer);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Customer value)
        {
            var customer = _service.CreateCustomer(value);

            var status = customer == true ? StatusCodes.Status201Created : StatusCodes.Status304NotModified;

            return StatusCode(status, customer);
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]Customer value)
        {
            var customer = _service.UpdateCustomer(value);

            var status = customer == true ? StatusCodes.Status200OK : StatusCodes.Status304NotModified;

            return StatusCode(status, customer);
        }

        // DELETE api/values/5
        [HttpDelete("{customerId}&{name}")]
        public IActionResult Delete(int customerId, string name)
        {
            var customer = _service.DeleteCustomer(customerId.ToString(), name);

            var status = customer ==true ? StatusCodes.Status200OK : StatusCodes.Status204NoContent;

            return StatusCode(status, customer);
        }
    }
}
