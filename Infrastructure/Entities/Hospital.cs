using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Enum;

namespace Infrastructure.Entities
{
    public class Hospital
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public LocationTypesEnum Location { get; set; }
        public string Specialty{ get; set; }
        public int PatientCapacity { get; set; }
        public int CantWorkers { get; set; }
    }
}
