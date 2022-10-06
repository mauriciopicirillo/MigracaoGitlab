using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using tech_test_payment_api.Context;


namespace tech_test_payment_api.Repositorios
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        protected ApiDbContext _context;

        public RepositorioBase(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<T> ObterPorIdAsync(Expression<Func<T, bool>> predicado)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(predicado);
        }

        public async Task<IEnumerable<T>> ObterTodosAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task AdicionarAsync(T entidade)
        {
            await _context.Set<T>().AddAsync(entidade);
            await _context.SaveChangesAsync();
        }

        public async Task EditarAsync(T entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;
            _context.Set<T>().Update(entidade);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(T entidade)
        {
            _context.Entry(entidade).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}