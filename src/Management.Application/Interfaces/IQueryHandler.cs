using Management.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Interfaces
{
    public interface IQueryHandler<in TQuery, TResponse> where TQuery : IQuery
    {
        Task<TResponse> HandleAsync(TQuery input);
    }
}
