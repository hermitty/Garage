using Garage.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Application.JobManagement.Query
{
    public class GetJob : IQuery<RequestedJob>
    {
        public int Id { get; set; }
    }
}
