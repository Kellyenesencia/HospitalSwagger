﻿using Infrastructure.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.HospitalDTOs
{
    public class HospitalPostDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public LocationTypesEnum Location { get; set; }
        public string Specialty { get; set; }
        public int PatientCapacity { get; set; }
        public int CantWorkers { get; set; }
    }
}
