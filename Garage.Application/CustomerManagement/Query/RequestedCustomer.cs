using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Application.CustomerManagement.Query
{
    public class RequestedCustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TelephoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
