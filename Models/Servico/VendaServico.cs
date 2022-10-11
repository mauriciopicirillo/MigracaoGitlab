using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.Context;
using tech_test_payment_api.Models.Enum;
using tech_test_payment_api.Models.Exceptions;
using tech_test_payment_api.Models.Repositorios;

namespace tech_test_payment_api.Models.Servico
{
    public class VendaServico
    {
        private readonly IRepositorioVenda _repositorioVenda;
        private readonly ApiDbContext _context;

        public VendaServico(IRepositorioVenda repositorioVenda, ApiDbContext context)
        {
            _repositorioVenda = repositorioVenda;
            _context = context;
        }

        

        // public async Task<Venda> BuscarPorId(int? id) 
        // {
        //     if ( id == null)
        //     {
        //         throw new ArgumentException("Deve ser informado o 'id' de venda.");
        //     }
                      
        //     var venda = await _repositorioVenda.ObterPorIdAsync(x => x.Id == id);
        //     if ( venda == null)
        //     {
        //         throw new Exception("Não existe venda com o 'id' informado.");
        //     }
        //     return venda;
        // } 

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