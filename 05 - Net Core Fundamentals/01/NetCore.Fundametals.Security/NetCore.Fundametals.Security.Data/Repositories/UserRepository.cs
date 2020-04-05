using NetCore.Fundametals.Security.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCore.Fundametals.Security.Data.Repositories
{
    public class UserRepository:IUserRepository
    {
        private List<User> users = new List<User>
        {
            new User
            {
                Id=3522,
                Name="erick",
                Password="AIxwOS46v70PpHu8LtlqqZvUnhWXJ/y6Dy5qvrOp1gE=",
                FavoriteColor="Negro",
                Role="Admin",
                GoogleId="102958934873274895259"
            }
        };

        public User GetByGoogleId(string googleId)
        {
            User user = users.Where(u => u.GoogleId == googleId).FirstOrDefault();
            return user;
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            User user = users.Where(u => u.Name == username && u.Password == password.Sha256()).FirstOrDefault();
            return user;
        }
    }
}
