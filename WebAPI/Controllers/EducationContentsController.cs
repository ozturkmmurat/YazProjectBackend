using Business.Abstract;
using Entities.Concrete;
using Entities.EntityParameter.EducationContent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationContentsController : ControllerBase
    {
        IEducationContentService _educationContentService;
        public EducationContentsController(IEducationContentService educationContentService)
        {
            _educationContentService = educationContentService;
        }

        [HttpGet("GetAllEdContentByEdId")]
        public IActionResult GetAllEdContentByEdId(int educationId)
        {
            var result = _educationContentService.GetAllEdContentByEdId(educationId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("TsaAdd")]
        public IActionResult Add([FromForm] EducationContentFile educationContentFile)
        {
            var result = _educationContentService.TsaAdd(educationContentFile);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("TsaUpdate")]
        public IActionResult Update([FromForm] EducationContentFile educationContentFile)
        {
            var result = _educationContentService.TsaUpdate(educationContentFile);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(EducationContent educationContent)
        {
            var result = _educationContentService.Delete(educationContent);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
