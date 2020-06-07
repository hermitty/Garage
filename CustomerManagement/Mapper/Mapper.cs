using Garage.DB.Entities;
using Garage.Services.CustomerManagement.Command;

namespace Garage.Services.CustomerManagement.Mapper
{
    public static class Mapper
    {
        public static Customer MapToCustomer(this AddCustomer command) => new Customer
        {
            Name = command.Name,
            Surname = command.Surname,
            TelephoneNumber = command.TelephoneNumber,
            EmailAddress = command.EmailAddress
        };
    }
}
