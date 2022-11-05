using CreditoApplication.Services.Interfaces;
using CreditoApplication.Shared.Creditos.ViewModels;
using CreditoApplication.Shared.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteCredito.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class FinanciamentoController : ControllerBase
    {
        private readonly ILogger<FinanciamentoController> _logger;
        private readonly ICreditoService _creditoService;

        public FinanciamentoController(ILogger<FinanciamentoController> logger, ICreditoService creditoService)
        {
            _logger = logger;
            _creditoService = creditoService;
        }

        [HttpPost]
        public IActionResult Requisitar([FromBody] FinanciamentoViewModel financiamento)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _creditoService.RequisitarFiancimento(financiamento);

                return Ok(result);
            }
            catch (ValidationErrorException e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest("Internal server error");
            }
        }
    }
}
