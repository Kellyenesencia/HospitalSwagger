using AutoMapper;
using Business;
using Data;
using Infrastructure.DTO.DoctorDTOs;
using Infrastructure.DTO.PatientDTOs;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private IMapper _mapper;

        private readonly PatientServices patientSV;

        public PatientController(ILogger<PatientController> logger, IMapper mapper, AppDbContext db)
        {
            _logger = logger;
            _mapper = mapper;
            patientSV = new PatientServices(db);
        }

        [HttpGet("GetListPatient")] //LLamada en el http
        [ProducesResponseType(typeof(List<PatientMiniDTO>), StatusCodes.Status200OK)] //Que el estado sea correcto

        public async Task<IActionResult> GetListPatientAsync()
        {
            var result = await patientSV.GetListAsync();
            var resultMap = _mapper.Map<List<PatientMiniDTO>>(result);

            return Ok(resultMap);
        }

        [HttpPost("GetPatientById")]
        [ProducesResponseType(typeof(PatientMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetPatientByIdAsync(
            [FromBody] Guid id)
        {
            var result = await patientSV.GetByIdAsync(id);
            var resultMap = _mapper.Map<PatientMiniDTO>(result);

            return Ok(resultMap);
        }

        [HttpPost("AddEditPatient")]
        [ProducesResponseType(typeof(PatientMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> AddEditPatientAsync(
            [FromBody] PatientPostDTO patient)
        {
            var result = await patientSV.AddEditAsync(_mapper.Map<Patient>(patient));
            if (result == null)
            {
                return BadRequest("Error. No hay capacidad para añadir paciente");
            }
            var resultMap = _mapper.Map<PatientMiniDTO>(result);

            return Ok(resultMap);
        }

        [HttpPost("RandomPatientByDoctor")]
        [ProducesResponseType(typeof(PatientMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> RandomPatientByDoctorAsync(
            [FromBody] Guid id)
        {
            var result = await patientSV.RandomPatient(id);
            var resultMap = _mapper.Map<PatientMiniDTO>(result);

            return Ok(resultMap);
        }

        [HttpDelete("DeletePatientById")]
        [ProducesResponseType(typeof(PatientMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> DeletePatientByIdAsync(
            [FromBody] Guid id)
        {
            var result = await patientSV.DeleteAsync(id);
            var resultMap = _mapper.Map<PatientMiniDTO>(result);

            return Ok(resultMap);
        }
    }
}
