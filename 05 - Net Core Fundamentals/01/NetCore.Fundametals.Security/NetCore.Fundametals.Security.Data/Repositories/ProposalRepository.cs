using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCore.Fundametals.Security.Data.Adapters;
using NetCore.Fundametals.Security.Data.Context;
using NetCore.Fundametals.Security.Dtos;

namespace NetCore.Fundametals.Security.Data.Repositories
{
    public class ProposalRepository : IProposalRepository
    {
        private readonly NetcoreFundametalsSecurityDbContext _dbContext;

        public ProposalRepository(NetcoreFundametalsSecurityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<ProposalDto>> GetAllForConference(int conferenceId)
        {
            return _dbContext.Proposals.Where(p => p.ConferenceId == conferenceId).Select(p => ConferenceAdapter.FromProposalToProposalDto(p)).ToListAsync();
        }


        public Task<int> Add(ProposalDto proposalDto)
        {
            var entity = ConferenceAdapter.FromProposalDtoToProposal(proposalDto);
            _dbContext.Proposals.Add(entity);
            return _dbContext.SaveChangesAsync();
        }

        public async Task<ProposalDto> Approve(int proposalId)
        {
            var proposal = await _dbContext.Proposals.FirstAsync(p => p.ProposalId == proposalId);
            proposal.Approved = true;
            await _dbContext.SaveChangesAsync();
            return ConferenceAdapter.FromProposalToProposalDto(proposal);
        }
    }
}
