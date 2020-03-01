using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.DI.Web
{
    public class GuidServiceTransient
    {
        private Guid _serviceGuid { get; }
        public GuidServiceTransient()
        {
            _serviceGuid = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return _serviceGuid.ToString();
        }
    }
}
