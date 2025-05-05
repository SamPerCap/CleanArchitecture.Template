using Application.Common.DTOs;
using Application.Common.Interfaces.Repositories;
using Application.Common.Models;
using AutoMapper;
using MediatR;

namespace Application.Users.Queries.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserDto?>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Result<UserDto?>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetValueByIdAsync(request.Id, cancellationToken);

            if (user is null)
            {
                return Result<UserDto?>.Fail("User not found");
            }

            return Result<UserDto?>.Ok(_mapper.Map<UserDto>(user));
        }
    }
}
