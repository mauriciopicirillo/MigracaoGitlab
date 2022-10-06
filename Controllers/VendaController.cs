using tech_test_payment_api.Servicos;
using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Models.Enum;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly VendaServico _vendaServico;
   
        
        public VendaController(VendaServico vendaServico)
        {
            _vendaServico = vendaServico;
        }

        // Retorna a venda de id informado.
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var venda = await _vendaServico.BuscarVenda(id);
                return Ok(venda);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // Altera o status da venda.
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int? id, int? status)
        {
            if (id == null || status == null || status > 5)
            {
                return BadRequest();
            }
            try
            {
                var statusVenda = (StatusVendaEnum)Enum.ToObject(typeof(StatusVendaEnum), status.Value);
                var venda = await _vendaServico.BuscarVenda(id);
                await _vendaServico.AtualizarVenda(venda, statusVenda);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // Registra uma nova venda.
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Venda model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var vendedor = model.ObterVendedor();
                var itensVenda = model.ObterItensVenda();
                await _vendaServico.RegistrarVenda(vendedor, itensVenda);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}