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
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O titulo deve ter no mínimo 3 caracteres.")]
        public string Titulo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "A Descrição deve ter no mínimo 10 caracteres.")]
        public string Descricao { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo obrigatorio")]
        public Status Status { get; set; } = Status.Nova;

        public void Validar()
        {
            TarefaCommandInvalidaException.ThrowIfInvalid(Titulo, Status, Descricao);
        }
    }
}
