using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasAtak.Core.Context.Commands.Interfaces;

namespace TarefasAtak.Core.Context.Hanlers.Interfaces
{
    public interface IHanlers<T> where T : ICommand
    {
    }
}
