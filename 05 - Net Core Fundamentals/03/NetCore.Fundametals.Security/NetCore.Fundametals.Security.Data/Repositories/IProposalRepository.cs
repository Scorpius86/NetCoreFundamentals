using NetCore.Fundametals.Security.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.Fundametals.Security.Data.Repositories
{
    public interface IProposalRepository
    {
        Task<int> Add(ProposalDto proposalDto);
        Task<ProposalDto> Approve(int proposalId);
        Task<List<ProposalDto>> GetAllForConference(int conferenceId);
    }
}