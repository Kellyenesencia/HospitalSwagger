using AutoMapper;
using Infrastructure.DTO.DoctorDTOs;
using Infrastructure.DTO.PatientDTOs;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper.Profiles
{
    public class MapperProfilePatient : Profile
    {
        public MapperProfilePatient() 
        {
            CreateMap<Patient, PatientDTO>()
                .ReverseMap();
            CreateMap<Patient, PatientMiniDTO>()
                .ReverseMap();
            CreateMap<Patient, PatientPostDTO>()
                .ReverseMap();
            CreateMap<PatientDTO, PatientMiniDTO>()
                .ReverseMap();
        }
    }
}
