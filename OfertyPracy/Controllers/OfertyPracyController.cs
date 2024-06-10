using OfertyPracy.Database;
using JobOffers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfertyPracy.Database;
using System.Diagnostics.CodeAnalysis;
using OfertyPracy.Models;

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
        public async Task<IEnumerable<ListaOfertDTO>> Get()
        {
            //List<OfertyPracyModel> list = await _dbcontext.OfertyPracy.ToListAsync();
            var list = await _dbcontext.OfertyPracy.Select(x => new ListaOfertDTO
                                                            {
                                                                Id = x.Id,
                                                                IdRektutera = x.IdRekrutera,
                                                                Tytul = x.Tytul,
                                                                Kategoria = x.Kategoria,
                                                                Status = x.Status,
                                                                DataWaznosci = x.DataWaznosci,
                                                                Wynagrodzenie = x.Wynagrodzenie,
                                                                WymiarPracy = x.WymiarPracy,
                                                                RodzajUmowy = x.RodzajUmowy
                                                            }).ToListAsync();
            return list;
        }

        // GET api/<OfertyPracyController>/5
        [HttpGet("{id}")]
        public async Task<OfertyPracyModel> Get(int id)
        {
            OfertyPracyModel result = await _dbcontext.OfertyPracy.FindAsync(id);
            //var tmp = await _dbcontext.Wymagania.Where(x => x.OfertaPracyId == id).ToListAsync();
            //OfertyPracyWymagania listaWymagan = new OfertyPracyWymagania();

            /*foreach (var item in tmp)
            {
                listaWymagan.Opis = item.Opis;
            }
            result.Wymagania = listaWymagan;*/
            return result;
        }

        // POST api/<OfertyPracyController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OfertyPracyDTO jobOfferDto)
        {
            try
            {
                if (jobOfferDto == null)
                {
                    return BadRequest("Model jest null");
                }

                var jobOffer = new OfertyPracyModel
                {
                    IdRekrutera = jobOfferDto.IdRekrutera,
                    Status = jobOfferDto.Status,
                    Tytul = jobOfferDto.Tytul,
                    Kategoria = jobOfferDto.Kategoria,
                    Opis = jobOfferDto.Opis,
                    DataStworzenia = jobOfferDto.DataStworzenia,
                    DataPublikacji = jobOfferDto.DataPublikacji,
                    DataWaznosci = jobOfferDto.DataWaznosci,
                    Wynagrodzenie = jobOfferDto.Wynagrodzenie,
                    WymiarPracy = jobOfferDto.WymiarPracy,
                    RodzajUmowy = jobOfferDto.RodzajUmowy,
                    Benefity = jobOfferDto.Benefity.Select(b => new OfertyPracyBenefity { Opis = b.Nazwa }).ToList(),
                    Wymagania = jobOfferDto.Wymagania.Select(r => new OfertyPracyWymagania { Opis = r.Nazwa }).ToList()
                };


                //Identity sam ogarnie zapis do odpowiednich tabel <3
                _dbcontext.OfertyPracy.Add(jobOffer);
                await _dbcontext.SaveChangesAsync();

                return Ok(jobOffer);
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
