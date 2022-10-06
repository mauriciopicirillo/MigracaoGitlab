using System.Linq.Expressions;
using tech_test_payment_api.Context;
using tech_test_payment_api.Models;
using Microsoft.EntityFrameworkCore;

namespace tech_test_payment_api.Repositorios
{
    public class RepositorioVenda : RepositorioBase<Venda>, IRepositorioVenda
    {
        public RepositorioVenda(ApiDbContext context) : base(context)
        {
        }

    //     public new async Task<Venda> ObterPorIdAsync(Expression<Func<Venda, bool>> predicado)
    //     {
    //         // return await _context.Set<Venda>()
    //         //     .Include("Vendedor")
    //         //     .Include("Itens")
    //         //     .SingleOrDefaultAsync(predicado);
    //     }
    // }
    // {
        
    }
}