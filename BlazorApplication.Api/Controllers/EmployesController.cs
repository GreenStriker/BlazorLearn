using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApplication.Api.Models;
using Microsoft.AspNetCore.Http;
using Blazor.Models;

namespace BlazorApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployesController : ControllerBase
    {
        private readonly IEmployRepository _employ;
        public EmployesController(IEmployRepository emp)
        {

            _employ = emp;

        }
        [HttpGet]
        public async Task<ActionResult> GetEmploye()
        {
            try
            {
                return Ok(await _employ.GetEmployes());
            }
            catch(Exception ex)
            {


                return StatusCode(StatusCodes.Status500InternalServerError, "Server Problem");
            }
            }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employe>> GetEmploye(int id)
        {
            try
            {
                var result =   await _employ.GetEmploye(id);
            if(result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception ex)
            {


                return StatusCode(StatusCodes.Status500InternalServerError, "Server Problem");

            }

        }

       [HttpPost]
        public async Task<ActionResult<Employe>> CreateEmploye(Employe employ)
        {
            try
            {

                if(employ == null)
                {
                    return BadRequest();
                }
                var createEmp = await _employ.AddEmploye(employ);

                return CreatedAtAction(nameof(GetEmploye), new { id = createEmp.EmployeID, createEmp });
            
            
            }
            catch (Exception ex)
            {


                return StatusCode(StatusCodes.Status500InternalServerError, "Server Problem");
            }

        }

    }
}
