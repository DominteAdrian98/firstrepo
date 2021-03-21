using AutoMapper;
using Conference.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conf.Api.Models
{
    public class DtoProfile : Profile
    {
        public DtoProfile()
        {
            CreateMap<Speaker, SpeakerDto>();
            CreateMap<SpeakerDto, Speaker>();
            //CreateMap<TalkDto, Talk>();
            //CreateMap<Talk, TalkDto>();
            //CreateMap<Workshop, WorkshopDto>();
            //CreateMap<WorkshopDto, Workshop>();
        }
    }
}
