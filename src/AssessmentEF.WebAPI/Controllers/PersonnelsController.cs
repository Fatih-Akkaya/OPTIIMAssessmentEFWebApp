using AssessmentEF.Business.Abstract;
using AssessmentEF.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentEF.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelsController : ControllerBase
    {
        IPersonnelService _personnelService;

        public PersonnelsController(IPersonnelService personnelService)
        {
            _personnelService = personnelService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {

            var personnels = await _personnelService.ListAllAsync();
            if (personnels== null)
            {
                return NotFound();
            }
            return Ok(personnels);
        }
        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var personnel = await _personnelService.GetPersonnelByIdAsync(id);
            if (personnel == null)
            {
                return NotFound();
            }
            return Ok(personnel);
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add(Personnel personnel)
        {            
            try
            {
                var result = await _personnelService.AddAsync(personnel);
                if (result.ID == null)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("edit")]
        public async Task<IActionResult> Edit(Personnel personnel)
        {
            try
            {
                var result = await _personnelService.UpdateAsync(personnel);
                if (result.ID == null)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
