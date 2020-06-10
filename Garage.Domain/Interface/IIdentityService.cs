using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Domain.Interface
{
    public interface IIdentityService
    {
        public string GenerateTokenForUser(int userId, string userRole);
    }
}
