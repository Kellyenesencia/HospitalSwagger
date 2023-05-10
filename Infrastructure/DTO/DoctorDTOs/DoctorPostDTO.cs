using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.DoctorDTOs
{
    public class DoctorPostDTO
    {
        public Guid Id { get; set; }
        public string Area { get; set; }
        public string Function { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        public Guid PersonId { get; set; }
        public Guid HospitalId { get; set; }
    }
}
