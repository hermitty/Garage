using AutoMapper;
using Garage.DB.Entities;
using Infrastructure.Command;
using Infrastructure.Repository;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Garage.Services.CustomerManagement.Command
{
    public class CustomerCommandHandler : ICommandHandler<AddCustomer>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        IGenericRepository<Customer> repo;

        public CustomerCommandHandler(DbContext context, IMapper mapper)
        {
            uow = new UnitOfWork(context);
            repo = uow.Repository<Customer>();
            this.mapper = mapper;
        }
        public void Handle(AddCustomer command)
        {
            var customer = mapper.Map<Customer>(command);
            repo.Insert(customer);
            uow.Save();
        }
    }
}
