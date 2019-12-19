using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using bio_eko_fit_dto;
using Microsoft.Extensions.Configuration;
using bio_eko_fit_dto.Common;
using bio_eko_fit_dto.Meals;

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
