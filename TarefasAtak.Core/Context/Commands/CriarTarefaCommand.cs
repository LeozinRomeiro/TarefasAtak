using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasAtak.Core.Context.Commands.Interfaces;
using TarefasAtak.Core.Context.Enums;
using TarefasAtak.Core.Context.ValueObjetcs;

namespace TarefasAtak.Core.Context.Commands
{
    public class CriarTarefaCommand : ICommand
    {
        public CriarTarefaCommand(string titulo, Descricao descricao, Status status)
        {
            Titulo = titulo;
            Descricao = descricao;
            Status = status;
        }

        public string Titulo { get; set; }
        public Descricao Descricao { get; set; }
        public Status Status { get; set; }
    }
}
