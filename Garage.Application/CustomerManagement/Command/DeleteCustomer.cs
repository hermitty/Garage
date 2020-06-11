using Garage.Domain.Interface;

namespace Garage.Application.CustomerManagement.Command
{
    public class DeleteCustomer : ICommand
    {
        public int Id { get; set; }
    }
}
