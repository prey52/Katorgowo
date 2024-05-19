using JobOffers.Database;
using JobOffers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobOffers
{
    //localhost:7029
    [Route("api/[controller]")]
    [ApiController]
    public class OfertyPracyController : ControllerBase
    {
        private readonly OfertyPracyDBcontext _dbcontext;

        public OfertyPracyController(OfertyPracyDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        // GET: api/<OfertyPracyController>
        [HttpGet]
        public async Task<IEnumerable<OfertyPracyModel>> Get()
        {
            List<OfertyPracyModel> list = await _dbcontext.OfertyPracy.ToListAsync();

            return list;
        }



        // GET api/<OfertyPracyController>/5
        [HttpGet("{id}")]
        public async Task<OfertyPracyModel> Get(int id)
        {
            OfertyPracyModel result = await _dbcontext.OfertyPracy.FindAsync(id);
            return result;
        }

        // POST api/<OfertyPracyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OfertyPracyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OfertyPracyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
