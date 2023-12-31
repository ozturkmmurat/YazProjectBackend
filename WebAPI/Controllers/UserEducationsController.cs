using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserEducationsController : ControllerBase
    {
        IUserEducationService _userEducationService;
        public UserEducationsController(IUserEducationService userEducationService)
        {
            _userEducationService = userEducationService;
        }


        [HttpGet("SelectUserEdApplicantDto")]
        public IActionResult SelectUserEdApplicantDto(int educationId)
        {
            var result = _userEducationService.GetAllEducationApplicant(educationId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllSelectUserEducation")]
        public IActionResult GetAllSelectUserEducation(int userId)
        {
            var result = _userEducationService.GetAllSelectUserEducation(userId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(UserEducation userEducation)
        {
            var result = _userEducationService.Add(userEducation);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(UserEducation userEducation)
        {
            var result = _userEducationService.Update(userEducation);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(UserEducation userEducation)
        {
            var result = _userEducationService.Delete(userEducation);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
