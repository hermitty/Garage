using Garage.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Application.UserManagement.Command
{
    public class Authorize : ICommand<string>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
