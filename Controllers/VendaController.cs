using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Context;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Controllers
{
    /// <summary>
    /// Api de Vendas
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class VendaController : ControllerBase
    {
        
        private readonly ApiDbContext _context;
        
        /// <summary>
        /// Ctor.
        /// </summary>
        public VendaController(ApiDbContext context)
        {  
            _context = context;  
        }

        /// <summary>
        /// Registra uma nova venda.
        /// </summary>
        /// <param name="venda">Objeto contendo os dados da venda.</param>
        /// <returns>200 caso a venda seja registrada com sucessso.</returns>
        /// <response code="200">Venda registrada.</response>
        /// <response code="400">Venda não registrada.</response>
        [HttpPost]
        public ActionResult Criar(Venda venda)
        {
            if (venda.DataVenda == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            _context.Add(venda);

            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = venda.Id }, venda);

        }
        
        /// <summary>
        /// Retorna a venda de id informado.
        /// </summary>
        /// <param name="id">Id da venda</param>
        /// <returns>Venda de id informado.</returns>
        /// <response code="200">Venda encontrada.</response>
        /// <response code="404">Venda não encontrada.</response>
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var venda = _context.Vendas.Find(id);

            if (venda == null)
                return NotFound();
            
            return Ok(venda);
        }
        
        /// <summary>
        /// Altera o status da venda.
        /// </summary>
        /// <param name="id">Id da venda.</param>
        /// <param name="status">
        /// Novo status da venda:
        /// 1 - Reservado não utilizar.
        /// 2 - Pagamento Aprovado.
        /// 3 - Enviado para transportadora.
        /// 4 - Entregue.
        /// 5 - Cancelada.
        /// </param>
        /// <returns>Nenhum conteúdo.</returns>
        /// <response code="204">Aleração realizada.</response>
        /// <response code="400">Alteração não realizada.</response>
        //Altera o status da venda.
        [HttpPut("{id}")]
        public IActionResult Put(int id, Venda venda, int? status)
        {
            var statusBanco = _context.Vendas.Find(id);
            
            if (statusBanco == null)
                return NotFound();


            statusBanco.Status = venda.Status;

            _context.Vendas.Update(statusBanco);
            _context.SaveChanges();

            return Ok(statusBanco);
        }

        
    }
}