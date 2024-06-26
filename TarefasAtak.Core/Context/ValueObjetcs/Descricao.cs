﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasAtak.Core.Context.Exceptions;

namespace TarefasAtak.Core.Context.ValueObjetcs
{
    public class Descricao
    {
        public Descricao(string texto)
        {
            Texto = texto;
            TarefaInvalidaException.ThrowIfDescricaoInvalid(texto,200);
        }

        public string Texto { get; private set; }
    }
}
