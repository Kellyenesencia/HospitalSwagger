using AutoMapper;
using Business;
using Data;
using Infrastructure.DTO.DoctorDTOs;
using Infrastructure.DTO.PersonDTOs;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly ILogger<DoctorController> _logger;
        private IMapper _mapper;

        private readonly DoctorServices doctorSV;

        public DoctorController(ILogger<DoctorController> logger, IMapper mapper, AppDbContext db)
        {
            _logger = logger;
            _mapper = mapper;
            doctorSV = new DoctorServices(db);
        }

        [HttpGet("GetListDoctor")] //LLamada en el http
        [ProducesResponseType(typeof(List<DoctorMiniDTO>), StatusCodes.Status200OK)] //Que el estado sea correcto

        public async Task<IActionResult> GetListDoctorAsync()
        {
            var result = await doctorSV.GetListAsync();
            var resultMap = _mapper.Map<List<DoctorMiniDTO>>(result);

            return Ok(resultMap);
        }

        [HttpGet("GetListDoctorWhoArePatients")] 
        [ProducesResponseType(typeof(List<DoctorMiniDTO>), StatusCodes.Status200OK)] 

        public async Task<IActionResult> GetListDoctorWhoArePatientsAsync()
        {
            var result = await doctorSV.DoctorsWhoArePatients();
            var resultMap = _mapper.Map<List<DoctorMiniDTO>>(result);

            return Ok(resultMap);
        }

        [HttpPost("GetDoctorById")]
        [ProducesResponseType(typeof(DoctorMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetDoctorByIdAsync(
            [FromBody] Guid id)
        {
            var result = await doctorSV.GetByIdAsync(id);
            var resultMap = _mapper.Map<DoctorMiniDTO>(result);

            return Ok(resultMap);
        }

        [HttpPost("AddEditDoctor")]
        [ProducesResponseType(typeof(DoctorMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> AddEditDoctorAsync(
            [FromBody] DoctorPostDTO doctor)
        {
            var result = await doctorSV.AddEditAsync(_mapper.Map<Doctor>(doctor));
            if (result == null)
            {
                return BadRequest("Error. No hay capacidad para añadir doctor");
            }
            var resultMap = _mapper.Map<DoctorMiniDTO>(result);
            return Ok(resultMap);
        }

        [HttpDelete("DeleteDoctorById")]
        [ProducesResponseType(typeof(DoctorMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> DeleteDoctorByIdAsync(
            [FromBody] Guid id)
        {
            var result = await doctorSV.DeleteAsync(id);
            var resultMap = _mapper.Map<DoctorMiniDTO>(result);

            return Ok(resultMap);
        }
    }
}
