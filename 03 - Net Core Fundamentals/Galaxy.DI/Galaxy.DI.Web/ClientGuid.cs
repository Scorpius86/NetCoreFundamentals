using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.DI.Web
{
    public class ClientGuid
    {
        private GuidServiceTransient _guidServiceTransient { get; }
        private GuidServiceSingleton _guidServiceSingleton { get; }
        private GuidServiceScoped _guidServiceScoped { get; }

        public ClientGuid(GuidServiceTransient guidServiceTransient,
            GuidServiceSingleton guidServiceSingleton,
            GuidServiceScoped guidServiceScoped)
        {
            _guidServiceTransient = guidServiceTransient;
            _guidServiceSingleton = guidServiceSingleton;
            _guidServiceScoped = guidServiceScoped;
        }

        public string GetGuidTransient()
        {
            return _guidServiceTransient.GetGuid();
        }
        public string GetGuidSingleton()
        {
            return _guidServiceSingleton.GetGuid();
        }
        public string GetGuidScoped()
        {
            return _guidServiceScoped.GetGuid();
        }
    }
}
