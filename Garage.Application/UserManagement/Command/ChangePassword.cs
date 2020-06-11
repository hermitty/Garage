using Garage.Domain.Interface;

namespace Garage.Application.UserManagement.Command
{
    public class ChangePassword : ICommand
    {
        public string NewPassword { get; set; }
    }
}
