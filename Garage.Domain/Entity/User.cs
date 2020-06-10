namespace Garage.Domain.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Role Role { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string AddressEmail { get; set; }
        public bool Active { get; set; }
    }

    public enum Role
    {
        Customer,
        Worker,
        Admin
    }
}
