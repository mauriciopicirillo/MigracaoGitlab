using System.Runtime.Serialization;


namespace tech_test_payment_api.Models
{
    [Serializable]
    internal class AlterarStatusException : Exception
    {
        public AlterarStatusException(string mensagem = null) : this(mensagem, null)
        {
            if (mensagem == null)
            {
                throw new AlterarStatusException("Alteração de status da venda não permitida.");
            }
        }

        
        public AlterarStatusException(string mensagem, Exception innerException) : base(mensagem, innerException) { }
    }
}