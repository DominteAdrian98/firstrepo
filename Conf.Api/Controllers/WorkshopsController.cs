using AutoMapper;
using Conf.Api.Models;
using Conference.Domain;
using Conference.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conf.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopsController : ControllerBase
    {
        private readonly IWorkshopService service;
        private readonly IMapper mapper;
        public WorkshopsController(IWorkshopService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WorkshopDto>> GetAll()
        {
            var workshops = service.GetAllWorkshops();
            return Ok(mapper.Map<IEnumerable<WorkshopDto>>(workshops));
        }

        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<WorkshopDto> GetById(int id)
        {
            var workshops = service.GetWorkshopById(id);
            if (workshops != null)
            {
                return Ok(mapper.Map<WorkshopDto>(workshops));
            }
            return NotFound($"Workshop with ID: {id} was not found");

        }
        [HttpPost]
        public ActionResult<WorkshopDto> Create(WorkshopDto workshopDto)
        {
            var model = mapper.Map<Workshop>(workshopDto);
            service.Add(model);
            service.Save();
            var workshopRead = mapper.Map<WorkshopDto>(model);
            return CreatedAtRoute(nameof(GetById), new { Id = workshopDto.ID }, workshopRead);

        }
        [HttpPut("{id}")]
        public ActionResult Update(int id, WorkshopDto workshopUpdateDto)
        {
            var model = service.GetWorkshopById(id);
            if (model == null)
            {
                return NotFound();
            }
            mapper.Map(workshopUpdateDto, model);
            service.Update(model);
            service.Save();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var workshop = service.GetWorkshopById(id);
            if (workshop == null)
            {
                return NotFound($"The workshop with Id: {id} does not exist");

            }
            service.Delete(workshop);
            service.Save();
            return NoContent();
        }
    }
}
