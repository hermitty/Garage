using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Application.UserManagement.Query
{
    public class RequestedUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
        public string Login { get; set; }
        public string AddressEmail { get; set; }
        public bool Active { get; set; }
    }
}
