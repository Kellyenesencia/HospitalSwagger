﻿using AutoMapper;
using Infrastructure.DTO.DoctorDTOs;
using Infrastructure.DTO.HospitalDTOs;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper.Profiles
{
    public class MapperProfileHospital : Profile
    {
        public MapperProfileHospital()
        {
            CreateMap<Hospital, HospitalDTO>()
                .ReverseMap();
            CreateMap<Hospital, HospitalMiniDTO>()
                .ReverseMap();
            CreateMap<Hospital, HospitalPostDTO>()
                .ReverseMap();
            CreateMap<HospitalDTO, HospitalMiniDTO>()
                .ReverseMap();
        }
    }
}
