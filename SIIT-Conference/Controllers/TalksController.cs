using AutoMapper;
using Conference.Domain;
using Conference.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIIT_Conference.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIIT_Conference.Controllers
{
  
    public class TalksController : Controller
    {
        private readonly ITalkService service;
        private readonly ISpeakerService speakerService;
        private readonly IMapper mapper;

        public TalksController(ISpeakerService speakerService, IMapper mapper, ITalkService service)
        {
            this.service = service;
            this.speakerService = speakerService;
            this.mapper = mapper;
        }
        // GET: TalksController/Create
        [HttpGet]
        public ActionResult Create()
        {
            TalkDto model = new TalkDto();
            return View(model);
        }

        // POST: TalksController/Create
        [HttpPost]
        public ActionResult Create(TalkDto model)
        {
            if (ModelState.IsValid)
            {
                //create a new Speaker
                Talk newTalk = new Talk();
                newTalk = mapper.Map<Talk>(model);
                service.Add(newTalk);
                ////save speaker
                service.Save();
                //redirect to List
                return RedirectToAction("List", "Talks");
            }

            return View(model);
        }

        // GET: TalksController/Edit/5
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            TalkDto model = new TalkDto();

            if (id.HasValue)
            {
                var existingTalk = service.getTalkById(id.Value);
                if (existingTalk != null)
                {
                    model = mapper.Map<TalkDto>(existingTalk);
                }
            }

            return View(model);
        }

        // POST: TalksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TalkDto incomingModel)
        {
            if (incomingModel.ID > 0)
            {
                if (ModelState.IsValid)
                {
                    var talkInDb = new Talk();
                    talkInDb = mapper.Map<Talk>(incomingModel);
                    service.Update(talkInDb);
                    service.Save();
                    return RedirectToAction("List", "Talks");
                }
            }
            return View(incomingModel);
        }

        [HttpGet]
        public IActionResult List()
        {
            IEnumerable<Talk> allTalks = service.GetAllTalks();
            var talkDtos = mapper.Map<IEnumerable<TalkDto>>(allTalks);
            return View(talkDtos);

        }
 
        [HttpGet]
        public IActionResult Delete(int id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var talk = service.getTalkById(id);
            return View(talk);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
       
            var existingTalk = service.getTalkById(id);
            if (existingTalk == null)
            {
                return NotFound();
            }
            service.Delete(existingTalk);
            service.Save();
            return RedirectToAction("List");

        }
    }
}