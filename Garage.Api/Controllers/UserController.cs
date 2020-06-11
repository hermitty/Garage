using Garage.Application.UserManagement.Command;
using Garage.Infrastructure.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Garage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public ActionResult Authorize(Authorize command)
        {
            var token = mediator.Send(command);
            return Ok(token);
        }

        [Authorize]
        [HttpPost("[action]")]
        public ActionResult ChangePassword(ChangePassword command)
        {
            var token = mediator.Send(command);
            return Ok(token);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost("[action]")]
        public ActionResult Create(CreateUser command)
        {
            var token = mediator.Send(command);
            return Ok(token);
        }
        
        [Authorize(Roles = Roles.Admin)]
        [HttpPost("[action]")]
        public ActionResult Delete(DeleteUser command)
        {
            var token = mediator.Send(command);
            return Ok(token);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost("[action]")]
        public ActionResult Edit(EditUser command)
        {
            var token = mediator.Send(command);
            return Ok(token);
        }
    }
}
