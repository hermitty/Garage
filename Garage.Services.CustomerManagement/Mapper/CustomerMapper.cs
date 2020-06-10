using AutoMapper;
using Garage.Domain.Entity;
using Garage.Services.CustomerManagement.Command;

namespace Garage.DB.Mappers
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<AddCustomer, Customer>();
        }
    }
}
