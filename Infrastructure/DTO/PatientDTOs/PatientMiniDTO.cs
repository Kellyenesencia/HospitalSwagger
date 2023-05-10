using Infrastructure.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.PatientDTOs
{
    public class PatientMiniDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public ReasonPatientEnum Reason { get; set; }
        public Guid PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname1 { get; set; }
        public string PersonSurname2 { get; set; }
        public int PersonAge { get; set; }
        public StatusTypesEnum PersonStatus { get; set; }
        public Guid HospitalId { get; set; }
        public string HospitalName { get; set; }
        public LocationTypesEnum HospitalLocation { get; set; }
        public string HospitalSpecialty { get; set; }
        public int HospitalPatientCapacity { get; set; }
        public int HospitalCantWorkers { get; set; }
    }
}
