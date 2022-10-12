using tech_test_payment_api.Models.Enum;
using tech_test_payment_api.Models.Exceptions;
using tech_test_payment_api.Models.Repositorios;

namespace tech_test_payment_api.Models.Servico
{
    /// <summary>
    /// Venda Serviço
    /// </summary>
    public class VendaServico
    {
        private readonly IRepositorioVenda _repositorioVenda;
        
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="repositorioVenda">Repositório Venda</param>
        public VendaServico(IRepositorioVenda repositorioVenda)
        {
            _repositorioVenda = repositorioVenda;
            
        }

        // Atualizar venda: 

        /// <summary>
        /// Permite que seja atualizado o status da venda
        /// De: Aguardando pagamento Para: Pagamento Aprovado
        /// De: Aguardando pagamento Para: Cancelada
        /// De: Pagamento Aprovado Para: Enviado para Transportadora
        /// De: Pagamento Aprovado Para: Cancelada
        /// De: Enviado para Transportador.Para: Entregue
        /// </summary>
        /// <param name="venda">Dados da venda.</param>
        /// <param name="status">Novo status da venda.</param>
        /// <returns></returns>
        public async Task AtualizarVenda(Venda venda, StatusVendaEnum status)
        {
            switch (status)
            {
                case StatusVendaEnum.PagamentoAprovado:
                    venda.AlterarStatusPagamentoAprovado();
                    break;
                case StatusVendaEnum.EnviadoParaTransportadora:
                    venda.AlterarStatusEnviarTransportadora();
                    break;
                case StatusVendaEnum.Entregue:
                    venda.AlterarStatusEntregar();
                    break;
                case StatusVendaEnum.Cancelada:
                    venda.AlterarStatusCancelar();
                    break;
                default:
                    throw new AlterarStatusException();
            }
            await _repositorioVenda.EditarAsync(venda);
        }
    }
}