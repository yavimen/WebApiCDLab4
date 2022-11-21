using Microsoft.AspNetCore.Mvc;
using WebApi.ModelViews;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Doctors")]
    [Produces("application/json")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService service;

        public DoctorsController(IDoctorService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<DoctorGetView>>> GetAllDoctor()
        {
            var doctors = await service.GetAllDoctors();

            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorGetView>> GetDoctorById([FromRoute] int id)
        {
            if (!await service.IsIdExist(id))
                return NotFound();

            return await service.GetDoctorById(id);
        }

        [HttpPost]
        public async Task<ActionResult> AddDoctor([FromBody] DoctorPostView newDoctor)
        {
            await service.AddNewDoctor(newDoctor);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDoctorById([FromRoute] int id)
        {
            if (!await service.IsIdExist(id))
                return NotFound();

            await service.DeleteDoctor(id);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDoctorById([FromRoute] int id, [FromBody] DoctorUpdateView doctorUpdate)
        {
            if (!await service.IsIdExist(id))
                return NotFound();

            return Ok(await service.UpdateDoctor(doctorUpdate, id));
        }
    }
}
