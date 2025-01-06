using Lancamento.Repository.Command;
using Lancamento.Repository.Handle;
using Lancamento.Services.Command;
using Lancamento.Services.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lancamento.API.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LancamentosController : ControllerBase
    {
        private readonly LancamentoCommandService _commandService;
        private readonly LancamentoQueryService _queryService;

        public LancamentosController(
            LancamentoCommandService commandService,
            LancamentoQueryService queryService)
        {
            _commandService = commandService;
            _queryService = queryService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Domain.Lancamento lancamento)
        {
            await _commandService.AddLancamentoAsync(lancamento);
            return Ok();
        }
               

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lancamentos = await _queryService.GetAllLancamentosAsync();
            return Ok(lancamentos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var lancamento = await _queryService.GetLancamentoByIdAsync(id);
            if (lancamento == null)
            {
                return NotFound();
            }

            return Ok(lancamento);
        }

        [HttpGet("saldo-diario")]
        public async Task<IActionResult> GetSaldoDiario([FromHeader] DateTime  data)
        {
            var saldo = await _queryService.GetSaldoDiarioAsync(data.ToShortDateString());
            return Ok(new { Data = data, Saldo = saldo });
        }
    }


}
