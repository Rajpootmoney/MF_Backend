using MF_DataAccess.Data;
using MF_DataAccess.Repository;
using MF_DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MF_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderTypeController : ControllerBase
    {
        private readonly IGenderTypeRepository _genderTypeRepository;
        public GenderTypeController(IGenderTypeRepository genderTypeRepository)
        {
            _genderTypeRepository = genderTypeRepository;
        }
        [HttpGet]
        public IActionResult GetGenderTypes()
        {
            return Ok(_genderTypeRepository.GetGenderType());
        }

    }
}
