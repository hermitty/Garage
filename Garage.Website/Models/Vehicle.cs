namespace Garage.Website.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string LicenseNumber { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public int OwnerId { get; set; }
    }
}
