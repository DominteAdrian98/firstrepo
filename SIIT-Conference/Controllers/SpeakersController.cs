using AutoMapper;
using Conference.Domain;
using Conference.Services;
using Microsoft.AspNetCore.Mvc;
using SIIT_Conference.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIIT_Conference.Controllers
{
    public class SpeakersController : Controller
    {
        private readonly ISpeakerService service;
        private readonly IMapper mapper;

        public SpeakersController(ISpeakerService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult List()
        {
            IEnumerable<Speaker> allSpeakers = service.GetAllSpeakers();

            var speakerDtos = mapper.Map<IEnumerable<SpeakerDto>>(allSpeakers);
            if (speakerDtos != null)
            {
                return View(speakerDtos);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            SpeakerDto model = new SpeakerDto();

            if (id.HasValue)
            {
                var existingSpeaker = service.GetSpeakerById(id.Value);
                if (existingSpeaker != null)
                {
                    model = mapper.Map<SpeakerDto>(existingSpeaker);
                }
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(SpeakerDto incomingModel)
        {
            if (incomingModel.ID > 0)
            {
                if (ModelState.IsValid)
                {
                    //tranform dto to domain object
                    var speakerInDb = new Speaker();
                    speakerInDb = mapper.Map<Speaker>(incomingModel);
                    //call the service to update the speakerInDB
                    service.Update(speakerInDb);
                    //save the entity
                    service.Save();
                    return RedirectToAction("List", "Speakers");
                }
            }


            return View(incomingModel);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var model = new SpeakerDto();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(SpeakerDto model)
        {
            if (ModelState.IsValid)
            {
                //create a new Speaker
                Speaker newSpeaker = new Speaker();
                newSpeaker = mapper.Map<Speaker>(model);
                service.Add(newSpeaker);
                //save speaker
                service.Save();
                //redirect to List
                return RedirectToAction("List", "Speakers");
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var speaker = service.GetSpeakerById(id);
            return View(speaker);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {

            var existingSpeaker = service.GetSpeakerById(id);
            if (existingSpeaker == null)
            {
                return NotFound();
            }
            service.Delete(existingSpeaker);
            service.Save();
            return RedirectToAction("List");

        }

    }
}
