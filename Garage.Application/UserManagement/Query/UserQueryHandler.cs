using AutoMapper;
using Garage.Domain.Entity;
using Garage.Domain.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Garage.Application.UserManagement.Query
{
    public class UserQueryHandler : IQueryHandler<GetAllUsers, IEnumerable<RequestedUser>>, IQueryHandler<GetUser,RequestedUser>,
                                    IQueryHandler<GetWorker, RequestedWorker>, IQueryHandler<GetWorkers, IEnumerable<RequestedWorker>>

    {
        private readonly IMapper mapper;
        private readonly IGenericRepository<User> repo;
        public UserQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.repo = uow.Repository<User>();
        }

        public Task<IEnumerable<RequestedUser>> Handle(GetAllUsers query, CancellationToken cancellationToken)
        {
            var users = repo.GetAll();
            var response = users.Select(u => mapper.Map<RequestedUser>(u));
            return Task.FromResult(response);
        }

        public Task<RequestedUser> Handle(GetUser query, CancellationToken cancellationToken)
        {
            var user = repo.GetById(query.Id);
            var response = mapper.Map<RequestedUser>(user);
            return Task.FromResult(response);
        }


        public Task<RequestedWorker> Handle(GetWorker command, CancellationToken cancellationToken)
        {
            var worker = repo.GetById(command.Id);
            var response = mapper.Map<RequestedWorker>(worker);
            return Task.FromResult(response);

        }

        public Task<IEnumerable<RequestedWorker>> Handle(GetWorkers command, CancellationToken cancellationToken)
        {
            var workers = repo.GetAll().Where(w => w.Role == Role.Worker);
            var response = workers.Select(u => mapper.Map<RequestedWorker>(u));
            return Task.FromResult(response);
        }
    }
}
