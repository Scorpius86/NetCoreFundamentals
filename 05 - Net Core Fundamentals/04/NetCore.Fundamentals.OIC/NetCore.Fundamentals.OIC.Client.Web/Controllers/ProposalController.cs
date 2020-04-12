using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCore.Fundamentals.OIC.Client.Web.Infrastructure.Agents.Proposal;
using NetCore.Fundamentals.OIC.Data.Model;

namespace NetCore.Fundamentals.OIC.Client.Web.Controllers
{
    public class ProposalController : Controller
    {
        private readonly IProposalAgent _proposalAgent;
        public ProposalController(IProposalAgent proposalAgent)
        {
            _proposalAgent = proposalAgent;
        }
        public async Task<IActionResult> Index(int conferenceId)
        {
            ViewBag.Title = $"Speaker - Proposals For Conference {conferenceId}";
            ViewBag.ConferenceId = conferenceId;

            return View(await _proposalAgent.GetAllProposalsForConference(conferenceId));
        }

        public IActionResult AddProposal(int conferenceId)
        {
            ViewBag.Title = "Speaker - Add Proposal";
            return View(new ProposalModel { ConferenceId = conferenceId });
        }

        [HttpPost]
        public async Task<IActionResult> AddProposal(ProposalModel proposal)
        {
            if (ModelState.IsValid)
                await _proposalAgent.AddProposal(proposal);
            return RedirectToAction("Index", new { conferenceId = proposal.ConferenceId });
        }

        public async Task<IActionResult> Approve(int proposalId)
        {
            var proposal = await _proposalAgent.ApproveProposal(proposalId);
            return RedirectToAction("Index", new { conferenceId = proposal.ConferenceId });
        }
    }
}