using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefasAtak.Core.Context.ValueObjetcs
{
    public class Descricao
    {
        public Descricao(string texto)
        {
            Texto = texto;
        }

        public string Texto { get; private set; }
    }
}
