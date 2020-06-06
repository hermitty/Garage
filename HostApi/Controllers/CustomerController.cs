using System.Collections.Generic;
using CustomerManagement.Command;
using HostApi.DataAccess;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HostApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Customer : ControllerBase
    {
        CustomerCommandHandler commandHandler;
        public Customer(Context context)
        {
            commandHandler = new CustomerCommandHandler(context);
        }
        // GET: api/<Customer>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Customer>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Customer>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Customer>/5
        [HttpPost("[action]")]
        public ActionResult Add(AddCustomer command)
        {
            commandHandler.Handle(command);
            return Ok();
        }

        // DELETE api/<Customer>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
