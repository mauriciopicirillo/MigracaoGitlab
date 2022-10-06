using System.Runtime.Serialization;


namespace tech_test_payment_api.Models
{
    [Serializable]
    internal class AlterarStatusException : Exception
    {
        // public AlterarStatusException()
        // {
        // }

        // public AlterarStatusException(string? message) : base(message)
        // {
        // }

        // public AlterarStatusException(string? message, Exception? innerException) : base(message, innerException)
        // {
        // }

        // protected AlterarStatusException(SerializationInfo info, StreamingContext context) : base(info, context)
        // {
        // }

        public AlterarStatusException(string mensagem = null) : this(mensagem, null)
        {
            if (mensagem == null)
            {
                throw new AlterarStatusException("Alteração de status da venda não permitida.");
            }
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="mensagem">Mensagem de erro</param>
        /// <param name="innerException">Inner exception</param>
        public AlterarStatusException(string mensagem, Exception innerException) : base(mensagem, innerException) { }
    }
}