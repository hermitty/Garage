using Garage.Application.CustomerManagement.Command;
using Garage.Application.CustomerManagement.Query;
using Garage.Infrastructure.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Garage.Infrastructure.Controllers
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

        [Authorize(Roles = Roles.Worker)]
        [HttpPost("[action]")]
        public ActionResult Add(AddCustomer command)
        {
            mediator.Send(command);
            return Ok();
        }

        [Authorize(Roles = Roles.Worker)]
        [HttpGet("[action]")]
        public ActionResult GetAll(GetAllCustomers command)
        {
            mediator.Send(command);
            return Ok();
        }

        [Authorize(Roles = Roles.Worker)]
        [HttpGet("[action]")]
        public ActionResult GetById(GetCustomer command)
        {
            mediator.Send(command);
            return Ok();
        }

        [Authorize(Roles = Roles.Worker)]
        [HttpGet("[action]")]
        public ActionResult GetVehicle(GetVehicle command)
        {
            mediator.Send(command);
            return Ok();
        }

        [Authorize(Roles = Roles.Worker)]
        [HttpGet("[action]")]
        public ActionResult GetVehiclesForCustomer(GetVehiclesForCustomer command)
        {
            mediator.Send(command);
            return Ok();
        }

        [Authorize(Roles = Roles.Worker)]
        [HttpPost("[action]")]
        public ActionResult AddVehicle(AddVehicleForCustomer command)
        {
            mediator.Send(command);
            return Ok();
        }

        [Authorize(Roles = Roles.Worker)]
        [HttpPost("[action]")]
        public ActionResult DeleteCustomer(DeleteCustomer command)
        {
            mediator.Send(command);
            return Ok();
        }

        [Authorize(Roles = Roles.Worker)]
        [HttpPost("[action]")]
        public ActionResult EditVehicle(EditVehicle command)
        {
            mediator.Send(command);
            return Ok();
        }
    }
}
