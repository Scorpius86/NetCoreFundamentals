using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCore.Fundamentals.OIC.Data.Adapters;
using NetCore.Fundamentals.OIC.Data.Context;
using NetCore.Fundamentals.OIC.Data.Model;

namespace NetCore.Fundamentals.OIC.Data.Repositories
{
    public class ProposalRepository : IProposalRepository
    {
        private readonly NetcoreFundamentalsOICContext _dbContext;

        public ProposalRepository(NetcoreFundamentalsOICContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<ProposalModel>> GetAllForConference(int conferenceId)
        {
            return await _dbContext.Proposals.Where(p => p.ConferenceId == conferenceId).Select(p => EntityModelAdapter.FromProposalToProposalModel(p)).ToListAsync();
        }


        public async Task<int> Add(ProposalModel model)
        {
            var entity = EntityModelAdapter.FromProposalModelToProposal(model);
            _dbContext.Proposals.Add(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<ProposalModel> Approve(int proposalId)
        {
            var proposal = await _dbContext.Proposals.FirstAsync(p => p.ProposalId == proposalId);
            proposal.Approved = true;
            await _dbContext.SaveChangesAsync();
            return EntityModelAdapter.FromProposalToProposalModel(proposal);
        }
    }
}
