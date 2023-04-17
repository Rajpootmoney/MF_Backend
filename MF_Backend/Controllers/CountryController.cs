using Backend_Models.Models;
using MF_DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MF_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        [HttpGet]
        public IActionResult GetCountries()
        {
            return Ok(_countryRepository.GetContries());
        }
        [HttpPost]
        public IActionResult AddCountry(Country country)
        {
            if (country == null) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _countryRepository.AddCountry(country);
            return Ok(country);
        }

    }
}
