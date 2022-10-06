using tech_test_payment_api.Models.Enum;

namespace tech_test_payment_api.Models
{
    public class Venda
    {
        public int VendaId { get; set; }
        public int VendedorId { get; set; }
        public DateTime DataVenda { get; set; }
        public Vendedor Vendedor { get; set; }
        public virtual List<ItemVenda> Itens { get; set; }
        public StatusVendaEnum Status { get; internal set; }

        public Vendedor ObterVendedor()
        {
            return new Vendedor
            {
                VendedorId = Vendedor.VendedorId,
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

        /// Adiciona um novo item na venda
        /// <param name="itemVenda">Item a ser adicionado</param>
        public void AdicionarItem(ItemVenda itemVenda)
        {
            Itens.Add(itemVenda);
        }

        /// Altera o status da venda para Aguardando Pagamento
        public void AlterarStatusPagamentoAprovado()
        {
            if (Status != StatusVendaEnum.AguardandoPagamento)
            {
                throw new AlterarStatusException();
            }
            Status = StatusVendaEnum.PagamentoAprovado;
        }

        /// Altera o status da venda para Enviado Para Transportadora
        public void AlterarStatusEnviarTransportadora()
        {
            if (Status != StatusVendaEnum.PagamentoAprovado)
            {
                throw new AlterarStatusException();
            }
            Status = StatusVendaEnum.EnviadoParaTransportadora;
        }

        /// Altera o status da venda para Entregue
        public void AlterarStatusEntregar()
        {
            if (Status != StatusVendaEnum.EnviadoParaTransportadora)
            {
                throw new AlterarStatusException();
            }
            Status = StatusVendaEnum.Entregue;
        }

        /// Altera o status da venda para Cancelada
        public void AlterarStatusCancelar()
        {
            Status = StatusVendaEnum.Cancelada;
        }

    }
}