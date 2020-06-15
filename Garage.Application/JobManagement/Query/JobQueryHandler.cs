using AutoMapper;
using Garage.Domain.Entity;
using Garage.Domain.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Garage.Application.JobManagement.Query
{
    public class JobQueryHandler : IQueryHandler<GetJobsWithDate, IEnumerable<RequestedJob>>,
                                   IQueryHandler<GetJob, RequestedJob>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IGenericRepository<Job> repo;

        public JobQueryHandler(IUnitOfWork uow, IMapper mapper) 
        {
            this.uow = uow;
            this.mapper = mapper;
            this.repo = uow.Repository<Job>();
        }

        public Task<IEnumerable<RequestedJob>> Handle(GetJobsWithDate query, CancellationToken cancellationToken)
        {
            var jobs = repo.GetAll(includeProperties: "Assignee").Where(j => j.Scheduled.Date == query.Date?.Date);
            var result = jobs.Select(j => mapper.Map<RequestedJob>(j));
            return Task.FromResult(result);
        }

        public Task<RequestedJob> Handle(GetJob query, CancellationToken cancellationToken)
        {
            var job = repo.GetById(query.Id, includeProperties: "Assignee");
            var result = mapper.Map<RequestedJob>(job);
            return Task.FromResult(result);
        }
    }
}
