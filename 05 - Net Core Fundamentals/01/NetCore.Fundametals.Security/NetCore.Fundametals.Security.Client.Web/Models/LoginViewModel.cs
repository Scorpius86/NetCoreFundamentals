﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Fundametals.Security.Client.Web.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
    }
}
