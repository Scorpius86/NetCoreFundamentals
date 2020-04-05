using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Fundametals.Security.Data.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string FavoriteColor { get; set; }
        public string Role { get; set; }
        public string GoogleId { get; set; }
    }
}
