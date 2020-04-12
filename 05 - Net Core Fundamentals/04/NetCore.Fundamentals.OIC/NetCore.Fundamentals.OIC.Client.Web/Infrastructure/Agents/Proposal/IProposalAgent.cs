using NetCore.Fundamentals.OIC.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Fundamentals.OIC.Client.Web.Infrastructure.Agents.Proposal
{
    public interface IProposalAgent
    {
        Task AddProposal(ProposalModel model);
        Task<ProposalModel> ApproveProposal(int proposalId);
        Task<IEnumerable<ProposalModel>> GetAllProposalsForConference(int conferenceId);
    }
}
