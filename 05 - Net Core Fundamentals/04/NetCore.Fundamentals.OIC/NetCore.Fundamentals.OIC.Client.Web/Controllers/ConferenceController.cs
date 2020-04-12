using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCore.Fundamentals.OIC.Client.Web.Infrastructure.Agents.Conference;
using NetCore.Fundamentals.OIC.Data.Model;

namespace NetCore.Fundamentals.OIC.Client.Web.Controllers
{
    public class ConferenceController : Controller
    {
        private readonly IConferenceAgent _conferenceAgent;
        public ConferenceController(IConferenceAgent conferenceAgent)
        {
            _conferenceAgent = conferenceAgent;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Organizer - Conference Overview";
            return View(await _conferenceAgent.GetAllConferences());
        }
        public IActionResult Add()
        {
            ViewBag.Title = "Organizer - Add Conference";
            return View(new ConferenceModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(ConferenceModel model)
        {
            if (ModelState.IsValid)
                await _conferenceAgent.AddConference(model);

            return RedirectToAction("Index");
        }
    }
}