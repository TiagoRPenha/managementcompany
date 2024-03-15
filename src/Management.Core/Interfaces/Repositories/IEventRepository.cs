// <summary> IEventRepository, Interface responsible for declaring method to publish events in Redis </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Management.Core.Events;

namespace Management.Core.Interfaces.Repositories
{
    public interface IEventRepository
    {
        Task PublishAsync(IEvent message);
    }
}
