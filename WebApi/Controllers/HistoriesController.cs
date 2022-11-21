using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using WebApi.Models;
using WebApi.ModelViews;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("histories")]
    [Produces("application/json")]
    public class HistoriesController : ControllerBase
    {
        private readonly IHistoryService service;

        public HistoriesController(IHistoryService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<HistoryGetView>>> GetAllHistories()
        {
            var histories = await service.GetAllHistories();

            return Ok(histories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HistoryGetView>> GetHistoryById([FromRoute] int id)
        {
            if (!await service.IsIdExist(id))
                return NotFound();

            return await service.GetHistoryById(id);
        }

        [HttpPost]
        public async Task<ActionResult> AddHistory([FromBody] HistoryPostView newHistory)
        {
            await service.AddNewHistory(newHistory);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHistoryById([FromRoute] int id) 
        {
            if (!await service.IsIdExist(id))
                return NotFound();

            await service.DeleteHistory(id);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHistoryById([FromRoute] int id, [FromBody] HistoryUpdateView historyUpdate)
        {
            if (!await service.IsIdExist(id))
                return NotFound();

            return Ok(await service.UpdateHistory(historyUpdate, id)); 
        }
    }
}
