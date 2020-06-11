using Garage.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Application.CustomerManagement.Query
{
    public class GetVehiclesForCustomer : IQuery<IEnumerable<RequestedVehicle>>
    {
        public int CustomerId { get; set; }
    }
}
