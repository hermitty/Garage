using Garage.Domain.Interface;

namespace Garage.Application.CustomerManagement.Command
{
    public class AddCustomer : ICommand<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TelephoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
