using AutoMapper;
using Garage.Application.CustomerManagement.Command;
using Garage.Application.CustomerManagement.Query;
using Garage.Domain.Entity;

namespace Garage.Application.Mapper
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<AddCustomer, Customer>();
            CreateMap<EditCustomer, Customer>();
            CreateMap<Customer, RequestedCustomer>();
            CreateMap<AddVehicleForCustomer, Vehicle>();
            CreateMap<Vehicle, RequestedVehicle>();
        }
    }
}
