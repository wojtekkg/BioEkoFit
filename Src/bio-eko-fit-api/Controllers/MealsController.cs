using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;
using bio_eko_fit_dto;
using RawRabbit.Configuration;
using RawRabbit.vNext;
using Microsoft.Extensions.Configuration;
using RawRabbit;

namespace bio_eko_fit_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly IBusClient _client;
        public MealsController(IBusClient client)
        {
            _client = client;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetMeals()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetMeals(int id)
        {
            return "DUPA";
        }
        
        [HttpPost]
        public void CreateMeal([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void UpdateMeal(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void DeleteMeal(int id)
        {
        }
    }
}
