using Microsoft.AspNetCore.Mvc;
using TallyConnector.Core.Models;
using TallyConnector.Services;


namespace TallyWebConnector.Controllers
{
    [Route("core")]
    [ApiController]
    public class CoreController : ControllerBase
    {
        private readonly IConfiguration config;
        private TallyService tally;
        public CoreController(IConfiguration configuration)
        {
            config = configuration;
            tally = new TallyService(config.GetSection("TallyHost").Value, int.Parse(config.GetSection("TallyPort").Value));
        }

        [HttpGet("check")]
        public async Task<bool> check()
        {
            return await tally.CheckAsync(); 
        }

        // GET: api/<LicenseController>
        [HttpGet("license")]
        public object license()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LicenseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LicenseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LicenseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LicenseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
