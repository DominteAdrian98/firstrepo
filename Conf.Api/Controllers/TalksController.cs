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
    public class TalksController : ControllerBase
    {
        private readonly ITalkService service;
        private readonly IMapper mapper;
        public TalksController(ITalkService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
       
        [HttpGet]
        public ActionResult<IEnumerable<TalkDto>> GetAll()
        {
            var talks = service.GetAllTalks();
            return Ok(mapper.Map<IEnumerable<SpeakerDto>>(talks));
        }
       
        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<TalkDto> GetById(int id)
        {
            var talks = service.getTalkById(id);
            if (talks != null)
            {
                return Ok(mapper.Map<TalkDto>(talks));
            }
            return NotFound($"Talk with ID: {id} was not found");

        }
        [HttpPost]
        public ActionResult<SpeakerDto> Create(TalkDto talkDto)
        {
            var model = mapper.Map<Talk>(talkDto);
            service.Add(model);
            service.Save();
            var talkRead = mapper.Map<TalkDto>(model);
            return CreatedAtRoute(nameof(GetById), new { Id = talkDto.ID }, talkRead);

        }
        [HttpPut("{id}")]
        public ActionResult Update(int id, TalkDto talkUpdateDto)
        {
            var model = service.getTalkById(id);
            if (model == null)
            {
                return NotFound();
            }
            mapper.Map(talkUpdateDto, model);
            service.Update(model);
            service.Save();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var talk = service.getTalkById(id);
            if (talk == null)
            {
                return NotFound($"The talk with Id: {id} does not exist");

            }
            service.Delete(talk);
            service.Save();
            return NoContent();
        }
    }
}
