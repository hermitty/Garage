using Garage.Domain.Interface;

namespace Garage.Application.CustomerManagement.Command
{
    public class EditCustomer : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TelephoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
