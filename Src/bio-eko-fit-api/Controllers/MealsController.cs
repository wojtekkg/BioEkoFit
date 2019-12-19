using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace bio_eko_fit_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        public MealsController()
        {
        }

        // [HttpGet]
        // public async Task<ActionResult<ResponseMessage>> Get()
        // {
        //     return await _client.RequestAsync<GetMealsRequest, ResponseMessage>(new GetMealsRequest());
        // }

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
