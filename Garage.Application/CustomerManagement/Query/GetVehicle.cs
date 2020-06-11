using Garage.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Application.CustomerManagement.Query
{
    public class GetVehicle : IQuery<RequestedVehicle>
    {
        public int Id { get; set; }
    }
}
