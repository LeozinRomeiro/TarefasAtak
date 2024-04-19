using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefasAtak.Core.Context.Exceptions
{
    public class TarefaInvalidaException : Exception
    {
        private const string MessagemPadrao = "Tarefa invalida";

        public TarefaInvalidaException(string message = MessagemPadrao)
            : base(message)
        {
        }

        public static void ThrowIfInvalid(string texto, string mensagem = MessagemPadrao)
        {
            if (string.IsNullOrEmpty(texto))
                throw new TarefaInvalidaException(mensagem);
        }
    }
}
