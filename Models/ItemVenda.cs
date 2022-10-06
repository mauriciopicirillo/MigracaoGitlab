using System.ComponentModel.DataAnnotations;


namespace tech_test_payment_api.Models
{
    public class ItemVenda
    {
        public const int TamanhoMaximoDescricao = 200;
        
        // Id do item de venda.
        public int ItemVendaId { get; set; }
        
        // Descrição do item da venda.
        [Required(ErrorMessage = "Informe uma descrição.", AllowEmptyStrings = false)]
        [MaxLength(200, ErrorMessage = "Limite máximo de {0} caracteres.")]
        public string Descricao { get; set; }

        // Quantidade do item da venda.
        public int? Quantidade { get; set; }

        // Preço do item da venda.
        [Required(ErrorMessage = "Informe o preço.")]
        public decimal? Preco { get; set; }
    }
}