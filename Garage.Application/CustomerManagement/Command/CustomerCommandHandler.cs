using AutoMapper;
using Garage.Domain.Entity;
using Garage.Domain.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Garage.Application.CustomerManagement.Command
{
    public class CustomerCommandHandler : ICommandHandler<AddCustomer>
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
        public void Handle(AddCustomer command)
        {
            var customer = mapper.Map<Customer>(command);
            repo.Insert(customer);
            uow.Save();
        }

        public Task<Unit> Handle(AddCustomer command, CancellationToken cancellationToken)
        {
            var customer = mapper.Map<Customer>(command);
            repo.Insert(customer);
            uow.Save();
            return null;
        }
    }
}
