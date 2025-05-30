using AutoMapper;
using interview_tallertechnologies.Domain.Interfaces;
using interview_tallertechnologies.Domain.Shared.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace interview_tallertechnologies.Application.UseCases.User.v1.Queries
{
    public class GetUserByUserNameUseCase : IRequestHandler<GetUserByUserNameQuery, QueryResult<GetUserByUserNameQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetUserByUserNameUseCase> _logger;
        private readonly IMapper _mapper;

        public GetUserByUserNameUseCase(IUnitOfWork unitOfWork,
                                        ILoggerFactory loggerFactory,
                                        IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = loggerFactory.CreateLogger<GetUserByUserNameUseCase>();
            _mapper = mapper;
        }

        public async Task<QueryResult<GetUserByUserNameQueryResponse>> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"[GetUserByUserNameUseCase].Handle - Started");

                var user = await _unitOfWork.Repository<Domain.Entities.User>()
                    .FindAsync(u => u.Username == request.Username);

                if (user is null)
                {
                    return new QueryResult<GetUserByUserNameQueryResponse>(
                        false,
                        "User not found.");
                }

                var userResponse = _mapper.Map<GetUserByUserNameQueryResponse>(user.First());


                _logger.LogInformation($"[GetUserByUserNameUseCase].Handle - Ended");

                return new QueryResult<GetUserByUserNameQueryResponse>(
                    true,
                    "User found successfully",
                    userResponse);


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[GetUserByUserNameUseCase].Handle - Ended");
                throw;
            }
        }
    }
}
