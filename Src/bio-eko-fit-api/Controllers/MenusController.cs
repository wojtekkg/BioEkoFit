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
    public class MenusController : ControllerBase
    {
        private readonly IBusClient _client;
        public MenusController(IBusClient client)
        {
            _client = client;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetMenus()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetMenus(int id)
        {
            return "DUPA";
        }
        
        [HttpPost]
        public void CreateMenu([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void UpdateMenu(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void DeleteMenu(int id)
        {
        }
    }
}
