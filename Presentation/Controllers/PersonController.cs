using AutoMapper;
using Business;
using Data;
using Infrastructure.DTO.PersonDTOs;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IMapper _mapper;

        private readonly PersonServices personSV;

        public PersonController(ILogger<PersonController> logger, IMapper mapper, AppDbContext db)
        {
            _logger = logger;
            _mapper = mapper;
            personSV = new PersonServices(db);
        }

        [HttpGet("GetListPerson")] //LLamada en el http
        [ProducesResponseType(typeof(List<PersonMiniDTO>), StatusCodes.Status200OK)] //Que el estado sea correcto

        public async Task<IActionResult> GetListPersonAsync()
        {
            var result = await personSV.GetListAsync();
            var resultMap = _mapper.Map<List<PersonMiniDTO>>(result);

            return Ok(resultMap);
        }

        [HttpPost("GetPersonById")]
        [ProducesResponseType(typeof(PersonMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetPersonByIdAsync(
            [FromBody] Guid id)
        {
            var result = await personSV.GetByIdAsync(id);
            var resultMap = _mapper.Map<PersonMiniDTO>(result);

            return Ok(resultMap);
        }

        [HttpPost("AddEditPerson")]
        [ProducesResponseType(typeof(PersonMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> AddEditPersonAsync(
            [FromBody] PersonPostDTO person)
        {
            var result = await personSV.AddEditAsync(_mapper.Map<Person>(person));
            var resultMap = _mapper.Map<PersonMiniDTO>(result);

            return Ok(resultMap);
        }

        [HttpDelete("DeletePersonById")]
        [ProducesResponseType(typeof(PersonMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> DeletePersonByIdAsync(
            [FromBody] Guid id)
        {
            var result = await personSV.DeleteAsync(id);
            var resultMap = _mapper.Map<PersonMiniDTO>(result);

            return Ok(resultMap);
        }
    }
}
