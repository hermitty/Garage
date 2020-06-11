using Garage.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Application.CustomerManagement.Command
{
    public class DeleteVehicle : ICommand
    {
        public int Id { get; set; }
    }
}
