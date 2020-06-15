using Garage.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Application.UserManagement.Query
{
    public class GetWorkers : IQuery<IEnumerable<RequestedWorker>>
    {
    }
}
