using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasAtak.Core.Context.Commands.Interfaces;
using TarefasAtak.Core.Context.Enums;
using TarefasAtak.Core.Context.Exceptions;
using TarefasAtak.Core.Context.ValueObjetcs;

namespace TarefasAtak.Core.Context.Commands
{
    public class TarefaCommand : ICommand
    {

        public Guid Id { get; set; } = Guid.Empty;
        [Required(ErrorMessage = "Campo obrigatorio")]
        public string Titulo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo obrigatorio")]
        public string Descricao { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo obrigatorio")]
        public Status Status { get; set; } = Status.Nova;

        public void Validar()
        {
            TarefaCommandInvalidaException.ThrowIfInvalid(Titulo, Status, Descricao);
        }
    }
}
