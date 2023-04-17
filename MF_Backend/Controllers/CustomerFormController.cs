using AutoMapper;
using MF_DataAccess.DTOs;
using MF_DataAccess.Repository;
using MF_DataAccess.Repository.IRepository;
using MF_Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MF_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerFormController : ControllerBase
    {
        private readonly IUserFormRepositoy _userFormRepositoy;
        private readonly IMapper _mapper;
        public CustomerFormController(IUserFormRepositoy userFormRepositoy, IMapper mapper)
        {
            _userFormRepositoy = userFormRepositoy;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetCustomers()
        {
            return Ok(_userFormRepositoy.GetCustomerForms().ToList().Select(_mapper.Map<CustomerForm, CustomerFormDTO2>));
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerFormDTO customerDto)
        {
            if (customerDto == null) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var customer = _mapper.Map<CustomerForm>(customerDto);
            if (!_userFormRepositoy.AddCustomer(customer))
            {
                ModelState.AddModelError("", $"Error While inserting data ");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateTrail([FromBody] CustomerFormDTO customerDto)
        {
            if (customerDto == null) return BadRequest(ModelState);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var customer = _mapper.Map<CustomerForm>(customerDto);
            if (!_userFormRepositoy.UpdateCustomer(customer))
            {
                ModelState.AddModelError("", "Error while Updating database");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
            //return CreatedAtRoute("GetCustomers", new { customerId = customer.Id }, customer);
        }
        [HttpDelete("{customerId:int}")]
        public IActionResult DeleteCustomer(int customerId)
        {
            if (!_userFormRepositoy.CustomerExists(customerId)) return NotFound();
            var customerInDb = _userFormRepositoy.GetCustomerForm(customerId);
            if (customerInDb == null) return NotFound();
            if (!_userFormRepositoy.DeleteCustomer(customerInDb))
            {
                ModelState.AddModelError("", $"Error while deleting Trail {customerInDb.Name}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }
        //[Route("[action]")]
        //[HttpPut]
        //public IActionResult UpdateTrail2([FromBody] CustomerFormDTO2 customerDto)
        //{
        //    if (customerDto == null) return BadRequest(ModelState);
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    var customer = _mapper.Map<CustomerForm>(customerDto);
        //    if (!_userFormRepositoy.UpdateCustomer(customer))
        //    {
        //        ModelState.AddModelError("", "Error while Updating database");
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //    return Ok();
        //}
    }
}
