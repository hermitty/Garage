using AutoMapper;
using Garage.Application.CustomerManagement.Command;
using Garage.Domain.Entity;
using Garage.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Garage.Application.JobManagement.Command
{
    public class JobCommandHandler : ICommandHandler<AddJob>, ICommandHandler<EditJob>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        IGenericRepository<Job> repo;

        public JobCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            repo = uow.Repository<Job>();
            this.mapper = mapper;
        }

        public Task<Unit> Handle(AddJob command, CancellationToken cancellationToken)
        {
            var job = mapper.Map<Job>(command);
            repo.Insert(job);
            uow.Save();
            return Task.FromResult(Unit.Value);
        }

        public Task<Unit> Handle(EditJob command, CancellationToken cancellationToken)
        {
            var job = mapper.Map<Job>(command);
            repo.Update(job);
            uow.Save();
            return Task.FromResult(Unit.Value);
        }
    }
}
