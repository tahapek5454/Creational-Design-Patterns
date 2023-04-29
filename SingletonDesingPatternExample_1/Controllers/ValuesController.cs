using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SingletonDesingPatternExample_1.Services;

namespace SingletonDesingPatternExample_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult X()
        {
            DataBaseService dbs = DataBaseService.GetInstance;
            dbs.Connection();
            dbs.DisConnection();

            return Ok(dbs.Count);
        }

        [HttpGet("[action]")]
        public IActionResult Y()
        {
            DataBaseService dbs = DataBaseService.GetInstance;
            dbs.Connection();
            dbs.DisConnection();

            return Ok(dbs.Count);
        }

    }
}
