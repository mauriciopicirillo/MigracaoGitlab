using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.Models.Enum;

namespace tech_test_payment_api.Models
{
    public class Venda
    {
        public int VendaId { get; set; }
        public Vendedor VendedorId { get; set; }
        public DateTime DataVenda { get; set; }
        public Vendedor Vendedor { get; set; }
        public virtual List<ItemVenda> Itens { get; set; }
        public StatusVendaEnum Status { get; set; }

        public Vendedor ObterVendedor()
        {
            return new Vendedor
            {
                Nome = Vendedor.Nome,
                Cpf = Vendedor.Cpf,
                Email = Vendedor.Email,
                Telefone = Vendedor.Telefone
            };
        }

        public List<ItemVenda> ObterItensVenda()
        {
            return Itens.Select(x=> new ItemVenda
            {
                Descricao = x.Descricao,
                Preco = x.Preco,
                Quantidade = x.Quantidade
            }).ToList();
        }

        public Venda()
        {
            Itens = new List<ItemVenda>();
            DataVenda = DateTime.Now;
            Status = StatusVendaEnum.AguardandoPagamento;
        }

        /// <summary>
        /// Adiciona um novo item na venda
        /// </summary>
        /// <param name="itemVenda">Item a ser adicionado</param>
        public void AdicionarItem(ItemVenda itemVenda)
        {
            Itens.Add(itemVenda);
        }

        /// <summary>
        /// Altera o status da venda para Aguardando Pagamento
        /// </summary>
        public void AlterarStatusPagamentoAprovado()
        {
            if (Status != StatusVendaEnum.AguardandoPagamento)
            {
                throw new AlterarStatusException();
            }
            Status = StatusVendaEnum.PagamentoAprovado;
        }

        /// <summary>
        /// Altera o status da venda para Enviado Para Transportadora
        /// </summary>
        public void AlterarStatusEnviarTransportadora()
        {
            if (Status != StatusVendaEnum.PagamentoAprovado)
            {
                throw new AlterarStatusException();
            }
            Status = StatusVendaEnum.EnviadoParaTransportadora;
        }

        /// <summary>
        /// Altera o status da venda para Entregue
        /// </summary>
        public void AlterarStatusEntregar()
        {
            if (Status != StatusVendaEnum.EnviadoParaTransportadora)
            {
                throw new AlterarStatusException();
            }
            Status = StatusVendaEnum.Entregue;
        }

        /// <summary>
        /// Altera o status da venda para Cancelada
        /// </summary>
        public void AlterarStatusCancelar()
        {
            Status = StatusVendaEnum.Cancelada;
        }

    }
}