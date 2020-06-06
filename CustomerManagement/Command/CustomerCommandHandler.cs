using CustomerManagement.Mapper;
using CustomerManagement.Model;
using Infrastructure.Command;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Structure.Repository;

namespace CustomerManagement.Command
{
    public class CustomerCommandHandler : ICommandHandler<AddCustomer>
    {
        private readonly IUnitOfWork uow;
        IGenericRepository<Customer> repo;

        public CustomerCommandHandler(DbContext context)
        {
            this.uow = new UnitOfWork(context);
            repo = uow.Repository<Customer>();
            
        }
        public void Handle(AddCustomer command)
        {
             repo.Insert(command.MapToCustomer());
            uow.Save();
        }
    }
}
