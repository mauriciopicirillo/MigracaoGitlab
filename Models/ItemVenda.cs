using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace tech_test_payment_api.Models
{
    public class ItemVenda
    {
        public const int TamanhoMaximoDescricao = 200;
        
        /// Id do item de venda.
        public int ItemVendaId { get; set; }
        
        /// Descrição do item da venda.
        public string Descricao { get; set; }

        /// Quantidade do item da venda.
        public int? Quantidade { get; set; }

        /// Preço do item da venda.
        public decimal? Preco { get; set; }
    }
}