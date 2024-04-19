using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TarefasAtak.Core.Context.Hanlers.Interfaces
{
    public interface IHanlers<T> where T : ICommand
    {
    }
}
