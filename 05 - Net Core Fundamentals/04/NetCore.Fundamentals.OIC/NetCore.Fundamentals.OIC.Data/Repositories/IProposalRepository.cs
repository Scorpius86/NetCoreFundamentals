using NetCore.Fundamentals.OIC.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.Fundamentals.OIC.Data.Repositories
{
    public interface IProposalRepository
    {
        Task<int> Add(ProposalModel model);
        Task<ProposalModel> Approve(int proposalId);
        Task<List<ProposalModel>> GetAllForConference(int conferenceId);
    }
}