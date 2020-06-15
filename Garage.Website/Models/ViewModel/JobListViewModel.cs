using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.Website.Models.ViewModel
{
    public class JobListViewModel
    {
        public DateTime Date { get; set; }
        public List<Job> Jobs { get; set; }
    }
}
