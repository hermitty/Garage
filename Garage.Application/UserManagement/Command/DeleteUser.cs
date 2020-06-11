using Garage.Domain.Interface;

namespace Garage.Application.UserManagement.Command
{
    public class DeleteUser : ICommand
    {
        public int Id { get; set; }
    }
}
