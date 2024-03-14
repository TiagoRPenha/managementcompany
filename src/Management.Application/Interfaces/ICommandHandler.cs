using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Management.Application.Interfaces
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
