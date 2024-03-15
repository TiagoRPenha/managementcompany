// <summary> CompanyCreatedEvent, Class responsible for created company event </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using Management.Core.Entities;
using Management.Core.Events;

namespace Management.Application.Events
{
    public class CompanyCreatedEvent : IEvent
    {
        public CompanyCreatedEvent(Company company)
        {
            Company = company;
        }

        public Company Company { get; set; }
    }
}
