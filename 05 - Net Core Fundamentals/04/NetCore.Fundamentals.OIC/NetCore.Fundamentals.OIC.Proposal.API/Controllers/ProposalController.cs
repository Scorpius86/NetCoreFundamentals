using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore.Fundamentals.OIC.Data.Model;
using NetCore.Fundamentals.OIC.Data.Repositories;

namespace NetCore.Fundamentals.OIC.Proposal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalController : ControllerBase
    {
        private readonly IProposalRepository _proposalRepository;

        public ProposalController(IProposalRepository proposalRepository)
        {
            this._proposalRepository = proposalRepository;
        }

        [HttpGet("GetAll/{conferenceId}")]
        public async Task<IEnumerable<ProposalModel>> GetAll(int conferenceId)
        {
            return await _proposalRepository.GetAllForConference(conferenceId);
        }

        [HttpPost("Add")]
        public void Add([FromBody]ProposalModel model)
        {
            _proposalRepository.Add(model);
        }

        [HttpGet("Approve/{proposalId}")]
        public async Task<ProposalModel> Approve(int proposalId)
        {
            return await _proposalRepository.Approve(proposalId);
        }
    }
}