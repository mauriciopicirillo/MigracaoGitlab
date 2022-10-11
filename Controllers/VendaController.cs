using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Context;
using tech_test_payment_api.Models;
using tech_test_payment_api.Models.Servico;

namespace tech_test_payment_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaController : ControllerBase
    {
        
        private readonly ApiDbContext _context;
        
        public VendaController(ApiDbContext context)
        {  
            _context = context;
      
            
        }


        [HttpPost]
        public ActionResult Criar(Venda venda)
        {
            if (venda.DataVenda == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            _context.Add(venda);

            _context.SaveChanges();

            return CreatedAtAction(nameof(BuscarPorId), new { id = venda.Id }, venda);

        }
        
        // Retorna a venda de id informado no banco utilizando o EF.
        [HttpGet("{id}")]
        public ActionResult BuscarPorId(int id)
        {
            var venda = _context.Vendas.Find(id);

            if (venda == null)
                return NotFound();
            
            return Ok(venda);
        }

        //Altera o status da venda.
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Venda venda, int? status)
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