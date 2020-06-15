using System;
namespace Garage.Website.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AssigneeId { get; set; }
        public string AssigneeName { get; set; }
        public int VehicleId { get; set; }
        public string FinalDescription { get; set; }
        public string Status { get; set; }
        public DateTime Scheduled { get; set; }
    }
}
