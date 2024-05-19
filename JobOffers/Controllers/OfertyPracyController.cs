using JobOffers.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobOffers
{
    //localhost:7029
    [Route("api/[controller]")]
    [ApiController]
    public class OfertyPracyController : ControllerBase
    {
        // GET: api/<OfertyPracyController>
        /*[HttpGet]
        public IEnumerable<OfertyPracyModel> Get()
        {

            OfertyPracyModel test = new OfertyPracyModel(
                1,2,"oczekujacy","ARPJS","Informatyka","pracuj dla nas żebyś miał co żreć nierobie",DateTime.Now, DateTime.Now,
                DateTime.Now, "brak", "2137zł", "1/2", "UOP", "Owocowe czwartki");

            return test;
        }*/

        // GET: api/<OfertyPracyController>
        [HttpGet]
        public IEnumerable<OfertyPracyModel> Get()
        {
            List<OfertyPracyModel> result = new List<OfertyPracyModel>();

            OfertyPracyModel test = new OfertyPracyModel(
                1,2,"oczekujacy","ARPJS","Informatyka","pracuj dla nas żebyś miał co żreć nierobie",DateTime.Now, DateTime.Now,
                DateTime.Now, "brak", "420zł", "1/2", "UOP", "Owocowe czwartki");
            result.Add(test);

            OfertyPracyModel test2 = new OfertyPracyModel(
                1,2,"zatwierdzony","JP2GMD","Finanse","to nieludzkie okolice",DateTime.Now, DateTime.Now,
                DateTime.Now, "brak", "2137zł", "Pełen etat", "UOP", "kremówki");
            result.Add(test2);


            return result;
        }



        // GET api/<OfertyPracyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
