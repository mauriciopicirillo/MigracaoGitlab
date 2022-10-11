using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.Models.Enum;
using tech_test_payment_api.Models.Exceptions;

namespace tech_test_payment_api.Models
{
    public class Venda
    {
        // Id da Venda
        public int Id { get; set; }
              
        
         //Dados do Vendedor
        // Id do Vendedor
        public int VendedorId { get; set; }

        // Nome do Vendedor
        public string Nome { get; set; }

        // CPF do Vendedor
        public string Cpf { get; set; }

        // e-mail do Vendedor
        public string Email { get; set; }

        // telefone do Vendedor
        public string Telefone { get; set; }
        
       
        // Descrição do produto da venda.
        public string Produto { get; set; }

        // Quantidade do item da venda.
        public int Quantidade { get; set; }

        // Preço do item da venda.
        public int Preco { get; set; }

        //Data da Venda
        public DateTime DataVenda { get; set; }

        //Status da Venda
        public StatusVendaEnum Status { get; set; }


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