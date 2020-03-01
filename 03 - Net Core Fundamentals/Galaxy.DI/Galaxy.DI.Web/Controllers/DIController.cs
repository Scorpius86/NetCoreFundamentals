using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Galaxy.DI.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DIController : ControllerBase
    {
        private GuidServiceTransient _guidServiceTransient { get; }
        private GuidServiceSingleton _guidServiceSingleton { get; }
        private GuidServiceScoped _guidServiceScoped { get; }
        private ClientGuid _clientGuid { get; }

        public DIController(
            GuidServiceTransient guidServiceTransient, 
            GuidServiceSingleton guidServiceSingleton,
            GuidServiceScoped guidServiceScoped,
            ClientGuid clientGuid)
        {
            _guidServiceTransient = guidServiceTransient;
            _guidServiceSingleton = guidServiceSingleton;
            _guidServiceScoped = guidServiceScoped;
            _clientGuid = clientGuid;
        }
        [HttpGet]
        public ActionResult<string> GetGuidTransient()
        {
            string guidController = _guidServiceTransient.GetGuid();
            string guidClient = _clientGuid.GetGuidTransient();

            return guidController + "\n" + guidClient;
        }
        [HttpGet]
        public ActionResult<string> GetGuidScoped()
        {
            string guidController = _guidServiceScoped.GetGuid();
            string guidClient = _clientGuid.GetGuidScoped();

            return guidController + "\n" + guidClient;
        }
        [HttpGet]
        public ActionResult<string> GetGuidSingleton()
        {
            string guidController = _guidServiceSingleton.GetGuid();
            string guidClient = _clientGuid.GetGuidSingleton();

            return guidController + "\n" + guidClient;
        }
    }
}