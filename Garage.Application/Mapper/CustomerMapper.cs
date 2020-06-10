using AutoMapper;
using Garage.Application.CustomerManagement.Command;
using Garage.Domain.Entity;

namespace Garage.Application.Mapper
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<AddCustomer, Customer>();
        }
    }
}
