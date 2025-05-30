using interview_tallertechnologies.Domain.Shared.Models;
using MediatR;

namespace interview_tallertechnologies.Application.UseCases.User.v1.Queries
{
    public class GetUserByUserNameQuery : IRequest<QueryResult<GetUserByUserNameQueryResponse>>
    {
        public string Username { get; }
        public GetUserByUserNameQuery(string username)
        {
            Username = username;
        }
    }
}
