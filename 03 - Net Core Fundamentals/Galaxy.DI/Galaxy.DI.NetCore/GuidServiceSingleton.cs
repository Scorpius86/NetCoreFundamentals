using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy.DI.NetCore
{
    public class GuidServiceSingleton
    {
        private Guid _serviceGuid { get; }
        public GuidServiceSingleton()
        {
            _serviceGuid = Guid.NewGuid();
        }

        public string GetGuid()
        {
            return _serviceGuid.ToString();
        }
    }
}
