using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Models
{
    public class Vendedor
    {
        // Id do Vendedor
        public int VendedorId { get; set; }
        
        // Nome do Vendedor
        [Required(ErrorMessage = "Informe o nome do vendedor.", AllowEmptyStrings = false)]
        [MaxLength(200, ErrorMessage = "Tamanho máximo de {0} caracters.")]
        public string Nome { get; set; }

        // CPF do Vendedor
        [Required(ErrorMessage = "Informe o CPF do vendedor.", AllowEmptyStrings = false)]
        public string Cpf { get; set; }

        // e-mail do Vendedor
        [Required(ErrorMessage = "Informe o e-mail do vendedor.", AllowEmptyStrings = false)]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um e-mail válido.")]
        public string Email { get; set; }

        // telefone do Vendedor
        [Required(ErrorMessage = "Informe o DDD Telefone do vendedor.", AllowEmptyStrings = false)]
        public string Telefone { get; set; }
    }
}