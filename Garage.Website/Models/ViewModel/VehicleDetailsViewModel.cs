using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.Website.Models.ViewModel
{
    public class VehicleDetailsViewModel
    {
        public Vehicle Vehicle { get; set; }
        public Customer Customer { get; set; }
        public List<Job> History { get; set; }
    }
}
