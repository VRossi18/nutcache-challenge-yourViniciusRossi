using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleManagment.Data;
using PeopleManagment.Models;
using SQLitePCL;
using System.Reflection;

namespace PeopleManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly DataContext _context;
        public PeopleController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<People>>> GetPeople()
        {
            return Ok(await _context.peoples.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<People>>> AddPeople(People people)
        {
            _context.peoples.Add(people);
            await _context.SaveChangesAsync();

            return Ok(await _context.peoples.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<People>> GetPerson(int id)
        {
            try
            {
                var people = await _context.peoples.FindAsync(id);
                if (people == null)
                {
                    return BadRequest("Person not found");
                }
                return Ok(people);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<People>> DeletePeople(int id)
        {
            try
            {
                var person = await _context.peoples.FindAsync(id);
                if (person == null)
                {
                    return BadRequest("Person not found");
                }
                _context.peoples.Remove(person);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
