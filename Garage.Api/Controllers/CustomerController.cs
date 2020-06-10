using System.Collections.Generic;
using Garage.Services.CustomerManagement.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Garage.HostApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
       
        private readonly IMediator mediator;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
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
            mediator.Send(command);
            return Ok();
        }

        // DELETE api/<Customer>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
