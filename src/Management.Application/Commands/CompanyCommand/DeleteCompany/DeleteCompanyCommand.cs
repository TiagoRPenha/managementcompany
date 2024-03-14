// <summary> DeleteCompanyCommand, Class responsible for delete company </summary>
// <remarks>
// <para>author: <c>tiago.penha</c></para>
// <para>date: <c>2024-03-14</c></para>
// </remarks>
using MediatR;

namespace Management.Application.Commands.CompanyCommand.DeleteCompany
{
    public class DeleteCompanyCommand : IRequest<Unit>
    {
        public DeleteCompanyCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
