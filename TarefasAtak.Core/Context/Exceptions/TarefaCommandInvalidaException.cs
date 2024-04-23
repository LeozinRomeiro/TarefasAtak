using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasAtak.Core.Context.Enums;
using TarefasAtak.Core.Context.ValueObjetcs;

namespace TarefasAtak.Core.Context.Exceptions
{
    public class TarefaCommandInvalidaException : Exception
    {
        private const string MessagemPadrao = "Tarefa invalida";

        public TarefaCommandInvalidaException(string message = MessagemPadrao)
            : base(message)
        {
        }

        public static void ThrowIfInvalid(string titulo, Status status, string descricao, string mensagem = MessagemPadrao)
        {
            ThrowIfDescricaoInvalid(descricao, 200);
            ThrowIfTituloTamanhoInvalido(titulo, 2, 50);
            ThrowIfStatusInvalido(status);
        }
        public static void ThrowIfDescricaoInvalid(string texto, int tamanhoMaximo, string mensagem = MessagemPadrao)
        {
            if (string.IsNullOrEmpty(texto) || texto.Length > tamanhoMaximo)
                throw new TarefaInvalidaException($"A Descrição pode ter até {tamanhoMaximo} caracteres.");
        }

        public static void ThrowIfTituloTamanhoInvalido(string titulo, int tamanhoMinimo, int tamanhoMaximo, string mensagem = MessagemPadrao)
        {
            if (string.IsNullOrEmpty(titulo) || titulo.Length < tamanhoMinimo || titulo.Length > tamanhoMaximo)
            {
                throw new TarefaInvalidaException($"O título da tarefa deve ter entre {tamanhoMinimo} e {tamanhoMaximo} caracteres.");
            }
        }

        public static void ThrowIfStatusInvalido(Status status)
        {
            if (!Enum.IsDefined(typeof(Status), status))
            {
                throw new TarefaInvalidaException($"Status inválido: {status}");
            }
        }
    }
}
