using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore.Fundamentals.OIC.Data.Model;
using NetCore.Fundamentals.OIC.Data.Repositories;

namespace NetCore.Fundamentals.OIC.Attendee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeeController : ControllerBase
    {
        private readonly IAttendeeRepository _attendeeRepository;

        public AttendeeController(IAttendeeRepository attendeeRepository)
        {
            this._attendeeRepository = attendeeRepository;
        }

        [HttpPost("{conferenceId}/{name}")]
        public IActionResult Post(int conferenceId, string name)
        {
            var attendee = _attendeeRepository.Add(
                new AttendeeModel { ConferenceId = conferenceId, Name = name });
            return StatusCode(201);
        }
    }
}