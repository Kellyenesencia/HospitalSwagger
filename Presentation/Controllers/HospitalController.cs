using AutoMapper;
using Business;
using Data;
using Infrastructure.DTO.HospitalDTOs;
using Infrastructure.DTO.PersonDTOs;
using Infrastructure.Entities;
using Infrastructure.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HospitalController : ControllerBase
    {
        private readonly ILogger<HospitalController> _logger;
        private IMapper _mapper;

        private readonly HospitalServices hospitalSV;

        public HospitalController(ILogger<HospitalController> logger, IMapper mapper, AppDbContext db)
        {
            _logger = logger;
            _mapper = mapper;
            hospitalSV = new HospitalServices(db);
        }

        [HttpGet("GetListHospital")] //LLamada en el http
        [ProducesResponseType(typeof(List<HospitalMiniDTO>), StatusCodes.Status200OK)] //Que el estado sea correcto

        public async Task<IActionResult> GetListHospitalAsync()
        {
            var result = await hospitalSV.GetListAsync();
            var resultMap = _mapper.Map<List<HospitalMiniDTO>>(result);

            return Ok(resultMap);
        }

        [HttpGet("GetListHospitalsCapacity")]
        [ProducesResponseType(typeof(List<HospitalMiniDTO>), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetListHospitalsCapacityAsync()
        {
            var result = await hospitalSV.GetListHospitalsCapacityAsync();
            var resultMap = _mapper.Map<List<HospitalMiniDTO>>(result);

            return Ok(resultMap);
        }

        [HttpPost("GetHospitalById")]
        [ProducesResponseType(typeof(HospitalMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetHospitalByIdAsync(
            [FromBody] Guid id)
        {
            var result = await hospitalSV.GetByIdAsync(id);
            var resultMap = _mapper.Map<HospitalMiniDTO>(result);

            return Ok(resultMap);
        }

        [HttpPost("AddEditHospital")]
        [ProducesResponseType(typeof(HospitalMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> AddEditHospitalAsync(
            [FromBody] HospitalPostDTO hospital)
        {
            var result = await hospitalSV.AddEditAsync(_mapper.Map<Hospital>(hospital));
            var resultMap = _mapper.Map<HospitalMiniDTO>(result);

            return Ok(resultMap);
        }

        [HttpPost("GetListHospitalByPatientReason")]
        [ProducesResponseType(typeof(HospitalMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> GetListHospitalByPatientReasonAsync(
            [FromBody] ReasonPatientEnum reason)
        {
            var result = await hospitalSV.GetListHospitalByPatientReasonAsync(reason);
            var resultMap = _mapper.Map<List<HospitalMiniDTO>>(result);

            return Ok(resultMap);
        }

        [HttpDelete("DeleteHospitalById")]
        [ProducesResponseType(typeof(HospitalMiniDTO), StatusCodes.Status200OK)]

        public async Task<IActionResult> DeleteHospitalByIdAsync(
            [FromBody] Guid id)
        {
            var result = await hospitalSV.DeleteAsync(id);
            var resultMap = _mapper.Map<HospitalMiniDTO>(result);

            return Ok(resultMap);
        }
    }
}
