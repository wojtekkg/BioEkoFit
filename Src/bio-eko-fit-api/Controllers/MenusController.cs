using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using bio_eko_fit_dto;
using Microsoft.Extensions.Configuration;

namespace bio_eko_fit_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        public MenusController()
        {
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
