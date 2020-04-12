using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore.Fundamentals.OIC.Data.Model;
using NetCore.Fundamentals.OIC.Data.Repositories;

namespace NetCore.Fundamentals.OIC.Conference.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConferenceController : ControllerBase
    {
        private readonly IConferenceRepository _conferenceRepository;

        public ConferenceController(IConferenceRepository conferenceRepository)
        {

            this._conferenceRepository = conferenceRepository;
        }

        public async Task<IEnumerable<ConferenceModel>> GetAll()
        {
            return await _conferenceRepository.GetAll();
        }

        [HttpPost]
        public async Task<int> Add(ConferenceModel conference)
        {
            return await _conferenceRepository.Add(conference);
        }
    }
}