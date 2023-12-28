using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducatorsController : ControllerBase
    {
        IEducatorService _educatorService;
        public EducatorsController(IEducatorService educatorService)
        {
            _educatorService = educatorService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllSelectEducationDto()
        {
            var result = _educatorService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Educator educator)
        {
            var result = _educatorService.Add(educator);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Educator educator)
        {
            var result = _educatorService.Update(educator);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Educator educator)
        {
            var result = _educatorService.Delete(educator);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
