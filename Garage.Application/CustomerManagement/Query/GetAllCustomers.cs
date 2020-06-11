using Garage.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Application.CustomerManagement.Query
{
    public class GetAllCustomers : IQuery<IEnumerable<RequestedCustomer>>
    {
    }
}
