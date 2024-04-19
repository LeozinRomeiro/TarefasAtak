﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasAtak.Core.Context.Enums;

namespace TarefasAtak.Core.Context.Entities
{
    public class Tarefa
    {
        public Tarefa(string titulo, string descricao, Status status)
        {
            Titulo = titulo;
            Descricao = descricao;
            Status = status;
        }

        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public Status Status { get; private set; }
    }
}
