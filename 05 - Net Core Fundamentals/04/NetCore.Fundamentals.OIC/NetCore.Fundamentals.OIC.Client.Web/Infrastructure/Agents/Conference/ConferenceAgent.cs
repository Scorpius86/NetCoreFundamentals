using NetCore.Fundamentals.OIC.Client.Web.Infrastructure.http;
using NetCore.Fundamentals.OIC.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetCore.Fundamentals.OIC.Client.Web.Infrastructure.Agents.Conference
{
    public class ConferenceAgent:IConferenceAgent
    {
        private readonly HttpClient _client;

        public ConferenceAgent(HttpClient client)
        {
            _client = client;
        }

        public async Task AddConference(ConferenceModel model)
        {
            await _client.PostAsJsonAsync("/api/Conference", model);
        }

        public async Task<IEnumerable<ConferenceModel>> GetAllConferences()
        {
            var response = await _client.GetAsync("/api/Conference");
            return await response.ReadContentAs<List<ConferenceModel>>();
        }
    }
}
