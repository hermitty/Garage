﻿using AutoMapper;
using Garage.DB.Entities;
using Garage.Services.CustomerManagement.Command;
using System;

namespace Garage.DB.Mappers
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<AddCustomer, Customer>();
        }
    }
}
