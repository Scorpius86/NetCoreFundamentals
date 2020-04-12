using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCore.Fundametals.Security.Data.Repositories;
using NetCore.Fundametals.Security.Dtos;

namespace NetCore.Fundametals.Security.Client.Web.Controllers
{
    public class ConferenceController : Controller
    {
        private readonly IConferenceRepository _conferenceRepository;

        public ConferenceController(IConferenceRepository conferenceRepository)
        {
            this._conferenceRepository = conferenceRepository;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Organizer - Conference Overview";
            return View(await _conferenceRepository.GetAll());
        }

        public IActionResult Add()
        {
            ViewBag.Title = "Organizer - Add Conference";
            return View(new ConferenceDto());
        }

        [HttpPost]
        public async Task<IActionResult> Add(ConferenceDto conferenceDto)
        {
            if (ModelState.IsValid)
                await _conferenceRepository.Add(conferenceDto);

            return RedirectToAction("Index");
        }
    }
}