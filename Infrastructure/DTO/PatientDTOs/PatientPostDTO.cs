using Infrastructure.Entities;
using Infrastructure.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.PatientDTOs
{
    public class PatientPostDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public ReasonPatientEnum Reason { get; set; }
        public Guid PersonId { get; set; }
        public Guid HospitalId { get; set; }
    }
}
