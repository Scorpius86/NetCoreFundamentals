using NetCore.Fundametals.Security.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Fundametals.Security.Data.Repositories
{
    public interface IUserRepository
    {
        User GetByUsernameAndPassword(string username, string password);
        User GetByGoogleId(string googleId);
    }
}
