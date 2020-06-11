using AutoMapper;
using Garage.Domain.Entity;
using Garage.Domain.Interface;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Garage.Application.UserManagement.Command
{
    public class UserCommandHandler : ICommandHandler<Authorize, string>, ICommandHandler<CreateUser, int>,
                                      ICommandHandler<DeleteUser>, ICommandHandler<EditUser>, ICommandHandler<ChangePassword>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IIdentityService identityService;
        private readonly IGenericRepository<User> repo;

        public UserCommandHandler(IUnitOfWork uow, IMapper mapper, IIdentityService identityService)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.identityService = identityService;
            repo = uow.Repository<User>();
        }

        public Task<string> Handle(Authorize command, CancellationToken cancellationToken)
        {
            var user = repo.GetAll().Where(u => u.Login == command.Login && u.Password == command.Password).FirstOrDefault();
            if (user == null) return Task.FromResult(String.Empty);
            var token = identityService.GenerateTokenForUser(user.Id, user.Role.ToString());
            return Task.FromResult(token);
        }

        public Task<int> Handle(CreateUser command, CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(command);
            repo.Insert(user);
            uow.Save();
            return Task.FromResult(user.Id);
        }

        public Task<Unit> Handle(DeleteUser command, CancellationToken cancellationToken)
        {
            repo.Delete(command.Id);
            uow.Save();
            return Task.FromResult(Unit.Value);
        }

        public Task<Unit> Handle(EditUser command, CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(command);
            repo.Update(user);
            uow.Save();
            return Task.FromResult(Unit.Value);
        }

        public Task<Unit> Handle(ChangePassword command, CancellationToken cancellationToken)
        {
            return Task.FromResult(Unit.Value);
        }
    }
}
