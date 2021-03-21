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
    public class WorkshopsController : Controller
    {
        private readonly IWorkshopService service;
        private readonly ISpeakerService speakerService;
        private readonly IMapper mapper;

        public WorkshopsController(IWorkshopService service, IMapper mapper,ISpeakerService speakerService)
        {
            this.service = service;
            this.speakerService = speakerService;
            this.mapper = mapper;
        }

        // GET: TalksController/Details/5
        public ActionResult Details(int? id)
        {
            return View();
        }

        // GET: TalksController/Create
        public ActionResult Create()
        {
            WorkshopDto model = new WorkshopDto();
            return View(model);
        }

        // POST: TalksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkshopDto model)
        {
            if (ModelState.IsValid)
            {
                Workshop newWorkshop = new Workshop();
                newWorkshop = mapper.Map<Workshop>(model);
                service.Add(newWorkshop);
                service.Save();
                return RedirectToAction("List", "Workshops");
            }
            return View(model);

        }

     

        // GET: TalksController/Edit/5
        [HttpGet]
        public IActionResult Edit(int? id)
        {
        
            WorkshopDto model = new WorkshopDto();

            if (id.HasValue)
            {
                var existingWorkshop = service.GetWorkshopById(id.Value);
                if (existingWorkshop != null)
                {
                    model = mapper.Map<WorkshopDto>(existingWorkshop);
                }
            } 

            return View(model);
        }

        // POST: TalksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(WorkshopDto incomingModel)
        {
            if (incomingModel.ID > 0)
            {
                if (ModelState.IsValid)
                {
                    var workshopInDb = new Workshop();
                    workshopInDb = mapper.Map<Workshop>(incomingModel);
                    service.Update(workshopInDb);
                    service.Save();
                    return RedirectToAction("List", "Workshops");
                }
            }
            return View(incomingModel);
        }
        [HttpGet]
        public IActionResult List()
        {
            IEnumerable<Workshop> allWorkshops = service.GetAllWorkshops();
            var workshopDtos = mapper.Map<IEnumerable<WorkshopDto>>(allWorkshops);
            return View(workshopDtos);

        }
        [HttpGet]
        public IActionResult Delete(int id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var workshop = service.GetWorkshopById(id);
            return View(workshop);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {

            var existingWorkshop = service.GetWorkshopById(id);
            if (existingWorkshop == null)
            {
                return NotFound();
            }
            service.Delete(existingWorkshop);
            service.Save();
            return RedirectToAction("List");

        }
    }
}
