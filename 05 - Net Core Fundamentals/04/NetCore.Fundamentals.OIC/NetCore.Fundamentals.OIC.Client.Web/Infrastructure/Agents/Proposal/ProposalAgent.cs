using NetCore.Fundamentals.OIC.Client.Web.Infrastructure.http;
using NetCore.Fundamentals.OIC.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetCore.Fundamentals.OIC.Client.Web.Infrastructure.Agents.Proposal
{
    public class ProposalAgent:IProposalAgent
    {
        private readonly HttpClient _client;

        public ProposalAgent(HttpClient client)
        {
            _client = client;
        }

        public async Task AddProposal(ProposalModel model)
        {
            await _client.PostAsJsonAsync("/api/Proposal/Add/", model);
        }

        public async Task<ProposalModel> ApproveProposal(int proposalId)
        {
            var response = await _client.GetAsync($"/api/Proposal/Approve/{proposalId}");
            return await response.ReadContentAs<ProposalModel>();
        }

        public async Task<IEnumerable<ProposalModel>> GetAllProposalsForConference(int conferenceId)
        {
            var response = await _client.GetAsync($"/api/Proposal/GetAll/{conferenceId}");
            return await response.ReadContentAs<List<ProposalModel>>();
        }
    }
}
