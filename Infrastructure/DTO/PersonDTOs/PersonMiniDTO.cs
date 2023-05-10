using Infrastructure.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.PersonDTOs
{
    public class PersonMiniDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname1 { get; set; }
        public string Surname2 { get; set; }
        public int Age { get; set; }
        public StatusTypesEnum Status { get; set; }
    }
}
