using NetCore.Fundamentals.OIC.Client.Web.Infrastructure.http;
using NetCore.Fundamentals.OIC.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetCore.Fundamentals.OIC.Client.Web.Infrastructure.Agents.Attendee
{
    public class AttendeeAgent:IAttendeeAgent
    {
        private readonly HttpClient _client;

        public AttendeeAgent(HttpClient client)
        {
            _client = client;
        }
        public async Task<AttendeeModel> AddAttendee(AttendeeModel attendee)
        {
            var response = await
                _client.PostAsJsonAsync("/api/Attendee/Add", attendee);
            return await response.ReadContentAs<AttendeeModel>(); ;
        }
    }
}
