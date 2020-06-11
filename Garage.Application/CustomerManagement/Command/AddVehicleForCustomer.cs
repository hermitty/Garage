using Garage.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Application.CustomerManagement.Command
{
    public class AddVehicleForCustomer : ICommand
    {
        public string LicenseNumber { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public int OwnerId { get; set; }
    }
}
