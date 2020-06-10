using System;
namespace Garage.Domain.Entity
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public User Assignee { get; set; }
        public int AssigneeId { get; set; }
        public int ReporterId { get; set; }
        public Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }
        public string FinalDescription { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime Created { get; set; }
    }

    public enum TaskStatus
    {
        Created,
        InProgress,
        Canceled,
        Finished
    }
}
