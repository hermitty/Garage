using AutoMapper;
using Garage.Domain.Entity;
using Garage.Domain.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Garage.Application.CustomerManagement.Command
{
    public class CustomerCommandHandler : ICommandHandler<AddCustomer, int>, ICommandHandler<EditCustomer>, ICommandHandler<DeleteCustomer>,
                                          ICommandHandler<AddVehicleForCustomer>, ICommandHandler<EditVehicle>, ICommandHandler<DeleteVehicle>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        IGenericRepository<Customer> repo;

        public CustomerCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            repo = uow.Repository<Customer>();
            this.mapper = mapper;
        }

        public Task<int> Handle(AddCustomer command, CancellationToken cancellationToken)
        {
            var customer = mapper.Map<Customer>(command);
            repo.Insert(customer);
            uow.Save();
            return Task.FromResult(customer.Id);
        }

        public Task<Unit> Handle(EditCustomer command, CancellationToken cancellationToken)
        {
            var customer = mapper.Map<Customer>(command);
            repo.Update(customer);
            uow.Save();
            return Task.FromResult(Unit.Value);
        }

        public Task<Unit> Handle(DeleteCustomer command, CancellationToken cancellationToken)
        {
            repo.Delete(command.Id);
            uow.Save();
            return Task.FromResult(Unit.Value);
        }

        public Task<Unit> Handle(AddVehicleForCustomer command, CancellationToken cancellationToken)
        {
            var vehicle = mapper.Map<Vehicle>(command);
            uow.Repository<Vehicle>().Insert(vehicle);
            uow.Save();
            return Task.FromResult(Unit.Value);
        }

        public Task<Unit> Handle(EditVehicle command, CancellationToken cancellationToken)
        {
            var vehicle = mapper.Map<Vehicle>(command);
            uow.Repository<Vehicle>().Update(vehicle);
            uow.Save();
            return Task.FromResult(Unit.Value);
        }

        public Task<Unit> Handle(DeleteVehicle command, CancellationToken cancellationToken)
        {
            uow.Repository<Vehicle>().Delete(command.Id);
            uow.Save();
            return Task.FromResult(Unit.Value);
        }
    }
}
