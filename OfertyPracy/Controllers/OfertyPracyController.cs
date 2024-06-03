using OfertyPracy.Database;
using JobOffers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfertyPracy.Database;
using System.Diagnostics.CodeAnalysis;

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
            var tmp = await _dbcontext.Wymagania.Where(x => x.OfertaPracyId == id).ToListAsync();
            OfertyPracyWymagania listaWymagan = new OfertyPracyWymagania();

            /*foreach (var item in tmp)
            {
                listaWymagan.Opis = item.Opis;
            }
            result.Wymagania = listaWymagan;*/
            return result;
        }

        // POST api/<OfertyPracyController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OfertyPracyModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Model jest null");
                }

                /*OfertyPracyModel saveModel = model;
                saveModel.Benefity = null;
                saveModel.Wymagania = null;

                OfertyPracyWymagania wymagania = new OfertyPracyWymagania()
                {
                    Opis = model.Opis,
                    OfertaPracyId = await _dbcontext.OfertyPracy.MaxAsync(x => x.Id)+1
                };*/



                _dbcontext.OfertyPracy.Add(model);
                //_dbcontext.Wymagania.Add(wymagania);

                await _dbcontext.SaveChangesAsync();

                return Ok("Model zapisany pomyślnie");
            }
            catch (Exception ex)
            {
                // Logowanie wyjątku
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Wystąpił błąd podczas zapisywania danych");
            }
        }

        // PUT api/<OfertyPracyController>/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<OfertyPracyController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var offer = await _dbcontext.OfertyPracy.FindAsync(id);

            if (offer == null)
            {
                return NotFound("Oferta nie została znaleziona");
            }

            var benefity = await _dbcontext.Benefity.Where(x => x.OfertaPracyId == id).ToListAsync();
            _dbcontext.Benefity.RemoveRange(benefity);

            var wymagania = await _dbcontext.Wymagania.Where(x => x.OfertaPracyId == id).ToListAsync();
            _dbcontext.Wymagania.RemoveRange(wymagania);

            _dbcontext.OfertyPracy.Remove(offer);

            await _dbcontext.SaveChangesAsync();

            return Ok("Usunięto pomyślnie");
        }
    }
}
