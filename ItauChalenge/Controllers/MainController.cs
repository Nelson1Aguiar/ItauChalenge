using System.Text.Json;
using ItauChalenge.Interfaces;
using ItauChalenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace ItauChalenge.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly ITransactionsService _transactionsService;

        public MainController(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }

        [HttpPost("transacao")]
        public IActionResult SaveTransaction([FromBody] Transaction transaction)
        {
            if (transaction is not null)
            {
                try
                {
                    _transactionsService.SaveTransaction(transaction);

                    return Created();
                }
                catch (ApplicationException ex)
                {
                    return UnprocessableEntity();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { Success = false, Message = "Erro interno do servidor: " + ex.Message });
                }
            }
            else
                return BadRequest();
        }

        [HttpDelete("transacao")]
        public IActionResult DeleteTransaction()
        {
            try
            {
                _transactionsService.DeleteTransactions();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "Erro interno do servidor: " + ex.Message });
            }
        }

        [HttpGet("estatistica")]
        public IActionResult GetStatistics()
        {
            try
            {
                Statistics statistics = _transactionsService.GetStatistics();

                string jsonStatistics = JsonSerializer.Serialize(statistics);

                return Ok(jsonStatistics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "Erro interno do servidor: " + ex.Message });
            }
        }
    }
}
