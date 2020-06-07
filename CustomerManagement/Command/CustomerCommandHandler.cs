using Garage.Services.CustomerManagement.Mapper;
using Garage.Services.CustomerManagement.Model;
using Infrastructure.Command;
using Infrastructure.Repository;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Garage.Services.CustomerManagement.Command
{
    public class CustomerCommandHandler : ICommandHandler<AddCustomer>
    {
        private readonly IUnitOfWork uow;
        IGenericRepository<Customer> repo;

        public CustomerCommandHandler(DbContext context)
        {
            uow = new UnitOfWork(context);
            repo = uow.Repository<Customer>();

        }
        public void Handle(AddCustomer command)
        {
            repo.Insert(command.MapToCustomer());
            uow.Save();
        }
    }
}
