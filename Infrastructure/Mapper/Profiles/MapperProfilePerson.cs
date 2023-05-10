using AutoMapper;
using Infrastructure.DTO.PersonDTOs;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper.Profiles
{
    public class MapperProfilePerson : Profile
    {
        public MapperProfilePerson() 
        {
            CreateMap<Person, PersonDTO>()
                .ReverseMap();
            CreateMap<Person, PersonMiniDTO>()
                .ReverseMap();
            CreateMap<Person, PersonPostDTO>()
                .ReverseMap();
            CreateMap<PersonDTO, PersonMiniDTO>()
                .ReverseMap();
        }
    }
}
