using AutoMapper;
using Infrastructure.DTO.DoctorDTOs;
using Infrastructure.DTO.PersonDTOs;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper.Profiles
{
    public class MapperProfileDoctor : Profile
    {
        public MapperProfileDoctor() 
        {
            CreateMap<Doctor, DoctorDTO>()
                .ReverseMap();
            CreateMap<Doctor, DoctorMiniDTO>()
                .ReverseMap();
            CreateMap<Doctor, DoctorPostDTO>();
            CreateMap<DoctorDTO, DoctorMiniDTO>()
                .ReverseMap();
            CreateMap<DoctorPostDTO, Doctor>()
                .ForMember(x => x.HoursDay, options => options.MapFrom(x => new TimeSpan(x.Hour, x.Minute, x.Second)));
        }
    }
}
