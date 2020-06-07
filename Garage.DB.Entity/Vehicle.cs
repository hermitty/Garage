namespace Garage.DB.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string LicenseNumber { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string OwnerId { get; set; }
        public Customer Owner { get; set; }
    }
}
