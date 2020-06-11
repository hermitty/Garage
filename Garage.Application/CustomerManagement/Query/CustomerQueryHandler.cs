using AutoMapper;
using Garage.Domain.Entity;
using Garage.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Garage.Application.CustomerManagement.Query
{
    public class CustomerQueryHandler : IQueryHandler<GetAllCustomers,IEnumerable<RequestedCustomer>>, IQueryHandler<GetCustomer,RequestedCustomer>,
                                        IQueryHandler<GetVehicle,RequestedVehicle>, IQueryHandler<GetVehiclesForCustomer,IEnumerable<RequestedVehicle>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IGenericRepository<Customer> repo;

        public CustomerQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.repo = uow.Repository<Customer>();
        }

        public Task<IEnumerable<RequestedCustomer>> Handle(GetAllCustomers query, CancellationToken cancellationToken)
        {
            var customers = repo.GetAll();
            var response = customers.Select(u => mapper.Map<RequestedCustomer>(u));
            return Task.FromResult(response);
        }

        public Task<RequestedCustomer> Handle(GetCustomer query, CancellationToken cancellationToken)
        {
            var customer = repo.GetById(query.Id);
            var response = mapper.Map<RequestedCustomer>(customer);
            return Task.FromResult(response);
        }

        public Task<RequestedVehicle> Handle(GetVehicle query, CancellationToken cancellationToken)
        {
            var vehicle = uow.Repository<Vehicle>().GetById(query.Id);
            var response = mapper.Map<RequestedVehicle>(vehicle);
            return Task.FromResult(response);
        }

        public Task<IEnumerable<RequestedVehicle>> Handle(GetVehiclesForCustomer query, CancellationToken cancellationToken)
        {
            var vehicles = uow.Repository<Vehicle>().GetAll().Where(v => v.OwnerId == query.CustomerId);
            var response = vehicles.Select(u => mapper.Map<RequestedVehicle>(u));
            return Task.FromResult(response);
        }
    }
}
