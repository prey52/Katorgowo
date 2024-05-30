using OfertyPracy.Database;
using JobOffers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfertyPracy.Database;

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
        public void Post([FromBody] OfertyPracyModel model)
        {
            /*public class OfertyPracyBenefity
            {
                public int Id { get; set; }
                public string Opis { get; set; }

                // Klucz obcy do ofert
                public int OfertaPracyId { get; set; }
                public OfertyPracyModel OfertaPracy { get; set; }
            }*/

            OfertyPracyWymagania Wtest = new OfertyPracyWymagania
            {
                Opis = "testowy benefit",
                OfertaPracyId = 0
            };

            OfertyPracyBenefity Btest = new OfertyPracyBenefity
            {
                Opis = "testowy opis",
                OfertaPracyId = 0
            };

            model.Wymagania.Add(Wtest);
            model.Benefity.Add(Btest);
            model.DataPublikacji = DateTime.Now;
            model.DataWaznosci = DateTime.Now;

            _dbcontext.Add(model);
            _dbcontext.SaveChangesAsync();
        }

        // PUT api/<OfertyPracyController>/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

            // DELETE api/<OfertyPracyController>/5
            [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
