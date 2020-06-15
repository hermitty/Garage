using Garage.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Application.JobManagement.Query
{
    public class GetJobsWithDate : IQuery<IEnumerable<RequestedJob>>
    {
        public DateTime? Date { get; set; }
    }
}
