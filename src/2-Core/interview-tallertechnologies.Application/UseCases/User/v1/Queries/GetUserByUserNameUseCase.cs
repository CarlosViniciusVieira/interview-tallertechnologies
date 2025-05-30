using interview_tallertechnologies.Domain.Interfaces;
using interview_tallertechnologies.Domain.Shared.Models;
using MediatR;

namespace interview_tallertechnologies.Application.UseCases.User.v1.Queries
{
    public class GetUserByUserNameUseCase : IRequestHandler<GetUserByUserNameQuery, QueryResult<GetUserByUserNameQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserByUserNameUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;        
        }

        public Task<QueryResult<GetUserByUserNameQueryResponse>> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
