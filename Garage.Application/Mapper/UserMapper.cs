using AutoMapper;
using Garage.Application.UserManagement.Command;
using Garage.Application.UserManagement.Query;
using Garage.Domain.Entity;
using System;

namespace Garage.Application.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            this.CreateMap<User, RequestedUser>()
                .ForMember(d => d.Role, op => op.MapFrom((u, ru) => ru.Role = u.Role.ToString()));
            this.CreateMap<CreateUser, User>()
                .ForMember(d => d.Role, op => op.MapFrom((cu, u) => u.Role = (Role)Enum.Parse(typeof(Role), cu.Role)));
            this.CreateMap<EditUser, User>()
                .ForMember(d => d.Role, op => op.MapFrom((eu, u) => u.Role = (Role)Enum.Parse(typeof(Role), eu.Role)));

        }
    }
}
