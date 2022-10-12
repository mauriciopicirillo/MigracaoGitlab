using tech_test_payment_api.Models.Enum;
using tech_test_payment_api.Models.Exceptions;

namespace tech_test_payment_api.Models
{
    /// <summary>
    /// Venda
    /// </summary>
    public class Venda
    {
        /// <summary>
        /// Id da venda.
        /// </summary>
        public int Id { get; set; }
              
        
        //Dados do Vendedor
        /// <summary>
        /// Id do vendedor.
        /// </summary>
        public int VendedorId { get; set; }

        /// <summary>
        /// Nome do vendedor.
        /// </summary>
        public string NomeVendedor { get; set; }

        /// <summary>
        /// CPF do vendedor.
        /// </summary>
        public string VendedorCpf { get; set; }

        /// <summary>
        /// E-mail do vendedor.
        /// </summary>
        public string VendedorEmail { get; set; }

        /// <summary>
        /// DDD Telefone do vendedor.
        /// </summary>
        public string VendedorTelefone { get; set; }
        
       
        /// <summary>
        /// Descrição do item da venda.
        /// </summary>
        public string Produto { get; set; }

        /// <summary>
        /// Quantidade do item da venda.
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// Preço do item da venda.
        /// </summary>
        public int Preco { get; set; }

        /// <summary>
        /// Data da venda.
        /// </summary>
        public DateTime DataVenda { get; set; }

        /// <summary>
        /// Status da venda.
        /// </summary>
        public StatusVendaEnum Status { get; set; }

        /// <summary>
        /// Ctor.
        /// </summary>

        public Venda ObterVenda()
        {
            return new Venda
            {
                Id = Id,
                VendedorId = VendedorId,
                NomeVendedor = NomeVendedor,
                VendedorCpf = VendedorCpf,
                VendedorEmail = VendedorEmail,
                VendedorTelefone = VendedorTelefone,
                Produto = Produto,
                Quantidade = Quantidade,
                Preco = Preco,
                DataVenda = DataVenda,
                Status = Status,

            };
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