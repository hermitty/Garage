using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.Website.Models.ViewModel
{
    public class JobAddEditViewModel
    {
        public Job Job { get; set; }
        public List<Worker> Workers { get; set; }
        public List<string> Status { get; set; }
    }
}
