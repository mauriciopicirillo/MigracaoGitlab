using System.Linq.Expressions;

namespace tech_test_payment_api.Repositorios
{
    public interface IRepositorioBase<T> where T : class
    {
      Task<T> ObterPorIdAsync(Expression<Func<T, bool>> predicado);
        Task<IEnumerable<T>> ObterTodosAsync();
        Task AdicionarAsync(T entidade);
        Task EditarAsync(T entidade);
        Task ExcluirAsync(T entidade);
    }
}