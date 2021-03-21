using AutoMapper;
using Conf.Api.Models;
using Conference.Domain;
using Conference.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Conf.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakersController : ControllerBase
    {
        private readonly ISpeakerService service;
        private readonly IMapper mapper;
        public SpeakersController(ISpeakerService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        // api/Speakers
        [HttpGet]
        public ActionResult<IEnumerable<SpeakerDto>> GetAllSpeakers()
        {
            var speakers = service.GetAllSpeakers();
            return Ok(mapper.Map<IEnumerable<SpeakerDto>>(speakers));
        }
        // api/Speakers/id
        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<SpeakerDto> GetById(int id)
        {
            var speakers = service.GetSpeakerById(id);
            if (speakers != null)
            {
                return Ok(mapper.Map<SpeakerDto>(speakers));
            }
            return NotFound($"Speaker with ID: {id} was not found");

        }
        [HttpPost]
        public ActionResult<SpeakerDto> CreateSpeaker(SpeakerDto speakerDto)
        {
            var model = mapper.Map<Speaker>(speakerDto);
            service.Add(model);
            service.Save();
            var speakerRead = mapper.Map<SpeakerDto>(model);
            return CreatedAtRoute(nameof(GetById), new { Id = speakerDto.ID }, speakerRead);

        }
        [HttpPut("{id}")]
        public ActionResult UpdateSpeaker(int id, SpeakerDto speakerUpdateDto)
        {
            var model = service.GetSpeakerById(id);
            if(model==null)
            {
                return NotFound();
            }
            mapper.Map(speakerUpdateDto, model);
            service.Update(model);
            service.Save();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteSpeaker(int id)
        {
            var speaker = service.GetSpeakerById(id);
            if(speaker==null)
            {
                return NotFound($"The speaker with Id: {id} does not exist");

            }
            service.Delete(speaker);
            service.Save();
            return NoContent();
        }


    }
}

