using ExamplesEF.Manager;
using ExamplesEF.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamplesEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NorthwindController : ControllerBase
    {
        private readonly MangerEmployee mangerEmployee;
        public NorthwindController(MangerEmployee mangerEmployee)
        {
            this.mangerEmployee = mangerEmployee ?? throw new ArgumentNullException(nameof(mangerEmployee));
        }

        [HttpGet(Name = "UpdateEmploeesTitle")]
        public async Task<Boolean> UpdateEmploeeTitle([FromQuery, Required] int employeeID, [FromQuery, Required] string value)
        {           
          return await mangerEmployee.UpdateEmploeeTitle(employeeID, value);         
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
