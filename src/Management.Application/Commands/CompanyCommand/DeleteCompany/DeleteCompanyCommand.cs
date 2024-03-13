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
