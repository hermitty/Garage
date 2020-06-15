using Garage.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Application.JobManagement.Command
{
    public class EditJob : ICommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AssigneeId { get; set; }
        public int VehicleId { get; set; }
        public string FinalDescription { get; set; }
        public String Status { get; set; }
        public DateTime Scheduled { get; set; }
    }
}
