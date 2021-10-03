using DuckDuckGo.Application.Interfaces;
using DuckDuckGo.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace DuckDuckGoProxy.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class DuckDuckGoAPIController : ControllerBase
    {
 
        private readonly ILogger<DuckDuckGoAPIController> _logger;
        private readonly IDuckDuckGoAPIService _duckDuckGoAPIService;
        public DuckDuckGoAPIController(ILogger<DuckDuckGoAPIController> logger, IDuckDuckGoAPIService duckDuckGoAPIService)
        {
            _logger = logger;
            _duckDuckGoAPIService = duckDuckGoAPIService;
        }

        // GET: api/DuckDuckGoAPI/queryParam="{string}"  
        [HttpGet]
        public async Task<string> Get(string queryParam)
        {     
            var result = await _duckDuckGoAPIService.GetRelatedTopics(queryParam);
            return JsonSerializer.Serialize(result);
        }

        // POST: api/DuckDuckGoAPI 
        [HttpPost]
        public async Task<string> Post([FromBody] UserQuery userQuery)
        {

            var result = await _duckDuckGoAPIService.GetRelatedTopics(userQuery.QueryParam);
            return JsonSerializer.Serialize(result);
        }

        // GET: api/DuckDuckGoAPI/ 
        [HttpGet("GetQueriesHistory")]
        public async Task<List<UserQuery>> GetQueriesHistory()
        {
            return await _duckDuckGoAPIService.GetUserQueries();
        }

        // POST: api/DuckDuckGoAPI/ 
        [HttpPost("UpdateQueryHistory")]
        public async Task UpdateQueryHistory([FromBody] List<UserQuery> queryHistory)
        {
            await _duckDuckGoAPIService.SaveUserQueries(queryHistory);
        }


    }
}
