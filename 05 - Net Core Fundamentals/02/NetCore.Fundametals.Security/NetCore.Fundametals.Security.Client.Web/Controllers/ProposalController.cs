using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCore.Fundametals.Security.Data.Repositories;
using NetCore.Fundametals.Security.Dtos;

namespace NetCore.Fundametals.Security.Client.Web.Controllers
{
    //[Authorize]
    public class ProposalController : Controller
    {
        private readonly IConferenceRepository _conferenceRepository;
        private readonly IProposalRepository _proposalRepository;

        public ProposalController(IConferenceRepository conferenceRepo, IProposalRepository proposalRepo)
        {
            this._conferenceRepository = conferenceRepo;
            this._proposalRepository = proposalRepo;
        }

        //[Authorize]
        public async Task<IActionResult> Index(int conferenceId)
        {
            var conference = await _conferenceRepository.GetById(conferenceId);
            ViewBag.Title = $"Speaker - Proposals For Conference {conference.Name} {conference.Location}";
            ViewBag.ConferenceId = conferenceId;

            return View(await _proposalRepository.GetAllForConference(conferenceId));
        }

        public IActionResult AddProposal(int conferenceId)
        {
            ViewBag.Title = "Speaker - Add Proposal";
            return View(new ProposalDto { ConferenceId = conferenceId });
        }

        [HttpPost]
        public async Task<IActionResult> AddProposal(ProposalDto proposalDto)
        {
            if (ModelState.IsValid)
                await _proposalRepository.Add(proposalDto);
            return RedirectToAction("Index", new { conferenceId = proposalDto.ConferenceId });
        }

        public async Task<IActionResult> Approve(int proposalId)
        {
            var proposal = await _proposalRepository.Approve(proposalId);
            return RedirectToAction("Index", new { conferenceId = proposal.ConferenceId });
        }
    }
}