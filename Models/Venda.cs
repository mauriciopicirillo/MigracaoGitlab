using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.Models.Enum;

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
    }
}