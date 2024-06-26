﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TarefasAtak.Core.Context.Enums;
using TarefasAtak.Core.Context.Exceptions;
using TarefasAtak.Core.Context.ValueObjetcs;
using TarefasAtak.Core.SharedContext.Entities;

namespace TarefasAtak.Core.Context.Entities
{
    public class Tarefa : Entity
    {
        public Tarefa(string titulo, Descricao descricao, Status status)
        {
            Titulo = titulo;
            Descricao = descricao;
            Status = status;
            NewGuid();
            TarefaInvalidaException.ThrowIfInvalid(titulo,status,descricao);
        }

        public string Titulo { get; private set; }
        public Descricao Descricao { get; private set; }
        public Status Status { get; private set; }
    }
}
