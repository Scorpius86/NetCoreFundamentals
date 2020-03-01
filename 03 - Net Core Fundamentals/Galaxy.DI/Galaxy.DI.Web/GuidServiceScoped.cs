using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.DI.Web
{
    public class GuidServiceScoped
    {
        private Guid _serviceGuid { get; }
        public GuidServiceScoped()
        {
            _serviceGuid = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return _serviceGuid.ToString();
        }
    }
}
