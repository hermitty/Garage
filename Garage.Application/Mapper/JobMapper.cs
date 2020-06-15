using AutoMapper;
using Garage.Application.JobManagement.Command;
using Garage.Application.JobManagement.Query;
using Garage.Domain.Entity;

namespace Garage.Application.Mapper
{
    public class JobMapper : Profile
    {
        public JobMapper()
        {
            CreateMap<Job, RequestedJob>();
            CreateMap<AddJob, Job>();
            CreateMap<EditJob, Job>();
            this.CreateMap<Job, RequestedJob>()
                .ForMember(a => a.AssigneeName, op => op.MapFrom((j, u) => u.AssigneeName = j.Assignee.Name));
        }
    }
}
