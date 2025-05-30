using AutoMapper;

namespace interview_tallertechnologies.Application.UseCases.User.v1.Queries
{
    public class GetUserByUserNameQueryProfile : Profile
    {
        public GetUserByUserNameQueryProfile()
        {
            CreateMap<Domain.Entities.User, GetUserByUserNameQueryResponse>().ReverseMap();
        }
    }
}
