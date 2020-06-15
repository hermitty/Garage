using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.Website.Models.ViewModel
{
    public class VehicleListViewModel
    {
        public int OwnerId { get; set; }
        public IEnumerable<Vehicle> Vehicle { get; set; }
        public Vehicle Veh { get; set; }
    }
}
